using MySql.Data.MySqlClient;
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
    public class GastoRepository
    {
        private readonly DatabaseConnection _databaseConnection;
        public GastoRepository(DatabaseConnection databaseConnection)
        {
            _databaseConnection = databaseConnection;
        }


        // Obtener los gastos no sincronizados
        public DataTable getUnsyncedGastos()
        {
            DataTable dt = new DataTable();

            try
            {
                using(MySqlConnection connection = _databaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT * FROM Gastos WHERE Sincronizado = 0";
                    using(MySqlCommand commnad = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataAdapter da = new MySqlDataAdapter(commnad))
                        {
                            da.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los gastos no sincronizados");
            }

            return dt;
        }

        // Marcar los gastos como sincronizados una vez que se obtuvieron los no sincronizados.

        public void MarkGastosAsSynced(int[] gastosId)
        {
            try
            {
                using (MySqlConnection connection = _databaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = "UPDATE Gastos SET Sincronizado = 1 WHERE IdGasto IN (" + string.Join(",", gastosId) + ")";
                    using(MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al marcar los gastos como sincronizados: {ex.Message}");
            }
        }


        // Sincronización asíncrona de gastos
        public async Task SyncGastosToCloudAsync()
        {
            try
            {
                var unsyncedGastos = getUnsyncedGastos();
                if(unsyncedGastos.Rows.Count == 0)
                {
                    return;
                }

                using(MySqlConnection cloudConnection = _databaseConnection.GetCloudConnection())
                {
                    await cloudConnection.OpenAsync();

                    List<int> syncedIds = new List<int>();

                    foreach (DataRow row in unsyncedGastos.Rows)
                    {
                        // Comprobar si el gasto ya existe en la base de datos en la nube
                        var checkQuery = "SELECT COUNT(*) FROM Gastos WHERE IdGasto = @IdGasto";
                        using(MySqlCommand checkCommand = new MySqlCommand(checkQuery, cloudConnection))
                        {
                            checkCommand.Parameters.AddWithValue("@IdGasto", row["IdGasto"]);
                            int exist = Convert.ToInt32(await checkCommand.ExecuteScalarAsync());

                            if (exist > 0)
                            {
                                // Actualizar el gasto existente
                                var updateQuery = "UPDATE Gastos SET IdCorte = @IdCorte, Concepto = @Concepto, Monto = @Monto, Fecha = @Fecha WHERE IdGasto = @IdGasto";
                                using(MySqlCommand updateCommand = new MySqlCommand(updateQuery, cloudConnection))
                                {
                                    updateCommand.Parameters.AddWithValue("@IdGasto", row["IdGasto"]);
                                    updateCommand.Parameters.AddWithValue("@IdCorte", row["IdCorte"]);
                                    updateCommand.Parameters.AddWithValue("@Concepto", row["Concepto"]);
                                    updateCommand.Parameters.AddWithValue("@Monto", row["Monto"]);
                                    updateCommand.Parameters.AddWithValue("@Fecha", row["Fecha"]);

                                    await updateCommand.ExecuteNonQueryAsync();
                                }
                            }

                            else
                            {
                                // Insertar nuevo gasto
                                var insertQuery = "INSERT INTO Gastos (IdGasto, IdCorte, Concepto, Monto, Fecha) VALUES (@IdGasto, @IdCorte, @Concepto, @Monto, @Fecha)";
                                using (MySqlCommand insertCommand =  new MySqlCommand(insertQuery, cloudConnection))
                                {
                                    insertCommand.Parameters.AddWithValue("@IdGasto", row["IdGasto"]);
                                    insertCommand.Parameters.AddWithValue("@IdCorte", row["IdCorte"]);
                                    insertCommand.Parameters.AddWithValue("@Concepto", row["Concepto"]);
                                    insertCommand.Parameters.AddWithValue("@Monto", row["Monto"]);
                                    insertCommand.Parameters.AddWithValue("@Fecha", row["Fecha"]);

                                    await insertCommand.ExecuteNonQueryAsync();
                                }
                            }
                        }
                        // Agregar el Id del Gasto sincronizado
                        syncedIds.Add(Convert.ToInt32(row["IdGasto"]));
                    }

                    // Marcar los Gastos como sincronizados en la base de datos local
                    MarkGastosAsSynced(syncedIds.ToArray());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al sincronizar los gastos: {ex.Message}");
                Console.WriteLine("Error al sincronizar los gastos: " + ex.Message);
            }
        }


        public void AddExpense(Gasto gasto)
        {
             using (MySqlConnection connection = _databaseConnection.GetConnection())
            {
                connection.Open();
                try
                {
                    string query = @"INSERT INTO Gastos (IdCorte, Concepto, Monto, Fecha)
                                     VALUES (@IdCorte, @Concepto, @Monto, @Fecha)";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@IdCorte", gasto.IdCorte);
                        command.Parameters.AddWithValue("@Concepto", gasto.Concepto);
                        command.Parameters.AddWithValue("@Monto", gasto.Monto);
                        command.Parameters.AddWithValue("@Fecha", gasto.Fecha);

                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al agregar el gasto: " + ex.Message);
                }
            }
        }
        public List<Gasto> GetGastosByCorteId(int idCorte)
        {
            List<Gasto> gastos = new List<Gasto>();

            try
            {
                using (MySqlConnection connection = _databaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT * FROM Gastos WHERE IdCorte = @IdCorte";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@IdCorte", idCorte);
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Gasto gasto = new Gasto
                                {
                                    IdGasto = Convert.ToInt32(reader["IdGasto"]),
                                    IdCorte = Convert.ToInt32(reader["IdCorte"]),
                                    Concepto = reader["Concepto"].ToString(),
                                    Monto = Convert.ToDecimal(reader["Monto"]),
                                    Fecha = Convert.ToDateTime(reader["Fecha"])
                                };
                                gastos.Add(gasto);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al cargar gastos: {ex.Message}");
            }

            return gastos;
        }

        public void DeleteGasto(int idGasto)
        {
            using (MySqlConnection connection = _databaseConnection.GetConnection())
            {
                connection.Open();
                try
                {
                    string query = "DELETE FROM Gastos WHERE IdGasto = @IdGasto";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@IdGasto", idGasto);
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al eliminar el gasto: " + ex.Message);
                }
            }
        }


       

        public List<Gasto>GastosPorFecha(DateTime fecha)
        {
            List<Gasto> gastos = new List<Gasto>();

            try
            {
                using(MySqlConnection connection = _databaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT IdGasto, IdCorte, Concepto, Monto, Fecha " +
                        "FROM Gastos WHERE DATE(Fecha) = DATE(@Fecha)";

                    using(MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Fecha", fecha.Date);
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Gasto gasto = new Gasto
                                {
                                    IdGasto = Convert.ToInt32(reader["IdGasto"]),
                                    IdCorte = Convert.ToInt32(reader["IdCorte"]),
                                    Concepto = reader["Concepto"].ToString(),
                                    Monto = Convert.ToDecimal(reader["Monto"]),
                                    Fecha = Convert.ToDateTime(reader["Fecha"]),

                                };
                                gastos.Add(gasto);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al cargar los gastos de la fecha seleccionada: {ex.Message}");
            }


            return gastos;
        }

        
    }
}
