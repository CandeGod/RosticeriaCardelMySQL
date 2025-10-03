using MySql.Data.MySqlClient;
using RosticeriaCardel;
using RosticeriaCardelV2.Clases;
using System;
using System.Collections.Generic;
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
