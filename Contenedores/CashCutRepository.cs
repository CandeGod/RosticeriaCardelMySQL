﻿using MySql.Data.MySqlClient;
using RosticeriaCardel;
using RosticeriaCardelV2.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RosticeriaCardelV2.Contenedores
{
    public class CashCutRepository
    {
        private readonly DatabaseConnection _databaseConnection;

        public CashCutRepository(DatabaseConnection databaseConnection)
        {
            _databaseConnection = databaseConnection;
        }

        //Obtener cortes de caja no sincronizados

        public DataTable GetUnsycCashCuts()
        {
            DataTable dt =new DataTable();

            try
            {
                using (MySqlConnection connection = _databaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT * FROM CorteCaja WHERE Sincronizado = 0";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    using (MySqlDataAdapter da = new MySqlDataAdapter(command))
                    {
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los cortes de caja no sincronizados:" + ex.Message);
            }

            return dt;
        }

        // Obtener cortes de caja no sincronizados
        public DataTable GetUnsyncedCashCuts()
        {
            DataTable dt = new DataTable();

            try
            {
                using (MySqlConnection connection = _databaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT * FROM CorteCaja WHERE Sincronizado = 0";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    using (MySqlDataAdapter da = new MySqlDataAdapter(command))
                    {
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los cortes de caja no sincronizados: " + ex.Message);
            }

            return dt;
        }

        // Marcar los cortes de caja como sincronizados
        public void MarkCashCutsAsSynced(int[] cashCutIds)
        {
            try
            {
                using (MySqlConnection connection = _databaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = "UPDATE CorteCaja SET Sincronizado = 1 WHERE IdCorte IN (" + string.Join(",", cashCutIds) + ")";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al marcar los cortes de caja como sincronizados: {ex.Message}");
            }
        }

        // Sincronización asíncrona de cortes de caja
        public async Task SyncCashCutsToCloudAsync()
        {
            try
            {
                var unsyncedCashCuts = GetUnsyncedCashCuts();

                if (unsyncedCashCuts.Rows.Count == 0)
                    return;

                using (MySqlConnection cloudConnection = _databaseConnection.GetCloudConnection())
                {
                    await cloudConnection.OpenAsync();

                    List<int> syncedIds = new List<int>();

                    foreach (DataRow row in unsyncedCashCuts.Rows)
                    {
                        // Comprobar si el corte de caja ya existe en la base de datos en la nube
                        var checkQuery = "SELECT COUNT(*) FROM CorteCaja WHERE IdCorte = @IdCorte";
                        using (MySqlCommand checkCommand = new MySqlCommand(checkQuery, cloudConnection))
                        {
                            checkCommand.Parameters.AddWithValue("@IdCorte", row["IdCorte"]);
                            int exists = Convert.ToInt32(await checkCommand.ExecuteScalarAsync());

                            if (exists > 0)
                            {
                                // Actualizar corte de caja existente
                                var updateQuery = "UPDATE CorteCaja SET Fecha = @Fecha, MontoInicial = @MontoInicial, MontoFinal = @MontoFinal WHERE IdCorte = @IdCorte";
                                using (MySqlCommand updateCommand = new MySqlCommand(updateQuery, cloudConnection))
                                {
                                    updateCommand.Parameters.AddWithValue("@IdCorte", row["IdCorte"]);
                                    updateCommand.Parameters.AddWithValue("@Fecha", row["Fecha"]);
                                    updateCommand.Parameters.AddWithValue("@MontoInicial", row["MontoInicial"]);
                                    updateCommand.Parameters.AddWithValue("@MontoFinal", row["MontoFinal"]);

                                    await updateCommand.ExecuteNonQueryAsync();
                                }
                            }
                            else
                            {
                                // Insertar nuevo corte de caja
                                var insertQuery = "INSERT INTO CorteCaja (IdCorte, Fecha, MontoInicial, MontoFinal) VALUES (@IdCorte, @Fecha, @MontoInicial, @MontoFinal)";
                                using (MySqlCommand insertCommand = new MySqlCommand(insertQuery, cloudConnection))
                                {
                                    insertCommand.Parameters.AddWithValue("@IdCorte", row["IdCorte"]);
                                    insertCommand.Parameters.AddWithValue("@Fecha", row["Fecha"]);
                                    insertCommand.Parameters.AddWithValue("@MontoInicial", row["MontoInicial"]);
                                    insertCommand.Parameters.AddWithValue("@MontoFinal", row["MontoFinal"]);

                                    await insertCommand.ExecuteNonQueryAsync();
                                }
                            }
                        }

                        // Agregar el ID del corte de caja sincronizado
                        syncedIds.Add(Convert.ToInt32(row["IdCorte"]));
                    }

                    // Marcar los cortes de caja como sincronizados en la base local
                    MarkCashCutsAsSynced(syncedIds.ToArray());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al sincronizar los cortes de caja: {ex.Message}");
            }
        }

        public void AddCashCut(CashCut cut)
        {
            using (MySqlConnection connection = _databaseConnection.GetConnection())
            {
                connection.Open(); // Abre la conexión aquí dentro del bloque using
                try
                {
                    string query = "INSERT INTO CorteCaja (Fecha, MontoInicial, MontoFinal) VALUES (@Fecha, @MontoInicial, @MontoFinal)";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Fecha", cut.Fecha);
                        command.Parameters.AddWithValue("@MontoInicial", cut.MontoInicial);
                        command.Parameters.AddWithValue("@MontoFinal", cut.MontoFinal);

                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al agregar el corte de caja: " + ex.Message);
                }
                finally
                {
                    connection.Close(); // Cierra la conexión
                }
            }
        }

        public List<CashCut> GetCashCut()
        {
            List<CashCut> cortes = new List<CashCut>();

            try
            {
                using (MySqlConnection connection = _databaseConnection.GetConnection())
                {
                    connection.Open(); // Abre la conexión aquí dentro del bloque using
                    string query = "SELECT * FROM CorteCaja";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                CashCut corte = new CashCut
                                {
                                    IdCorte = reader["IdCorte"] != DBNull.Value ? Convert.ToInt32(reader["IdCorte"]) : 0,
                                    Fecha = reader["Fecha"] != DBNull.Value ? Convert.ToDateTime(reader["Fecha"]) : DateTime.MinValue,
                                    MontoInicial = reader["MontoInicial"] != DBNull.Value ? Convert.ToDecimal(reader["MontoInicial"]) : 0m,
                                    MontoFinal = reader["MontoFinal"] != DBNull.Value ? Convert.ToDecimal(reader["MontoFinal"]) : 0m
                                };
                                cortes.Add(corte);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al cargar cortes de caja: {ex.Message}");
            }

            return cortes;
        }

        public decimal GetTotalSalesOfTheDay(DateTime fecha)
        {
            decimal totalVentas = 0;

            try
            {
                using (MySqlConnection connection = _databaseConnection.GetConnection())
                {
                    connection.Open(); // Abre la conexión aquí dentro del bloque using
                    string query = "SELECT SUM(Total) FROM Ventas WHERE DATE(Fecha) = @Fecha";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Fecha", fecha.Date);
                        totalVentas = Convert.ToDecimal(command.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener las ventas del día: " + ex.Message);
            }

            return totalVentas;
        }

        public bool ThereIsCashCutForDate(DateTime fecha)
        {
            bool existe = false;

            try
            {
                using (MySqlConnection connection = _databaseConnection.GetConnection())
                {
                    connection.Open(); // Abre la conexión aquí dentro del bloque using
                    string query = "SELECT COUNT(*) FROM CorteCaja WHERE DATE(Fecha) = @Fecha";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Fecha", fecha.Date);
                        existe = Convert.ToInt32(command.ExecuteScalar()) > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al verificar el corte de caja: " + ex.Message);
            }

            return existe;
        }
    }
}
