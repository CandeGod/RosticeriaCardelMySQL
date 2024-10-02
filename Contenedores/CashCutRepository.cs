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

    public class CashCutRepository
    {
        private readonly DatabaseConnection _databaseConnection;


        public CashCutRepository()
        {
            _databaseConnection = new DatabaseConnection();
        }

        public void AddCashCut(CashCut cut)
        {
            using (MySqlConnection connection = _databaseConnection.GetConnection())
            {
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
                    connection.Close(); // Asegurarse de cerrar la conexión
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
