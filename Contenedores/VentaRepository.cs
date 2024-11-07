using MySql.Data.MySqlClient;
using RosticeriaCardel;
using RosticeriaCardelV2.Clases;
using System;
using System.Data;
using System.Windows.Forms;

namespace RosticeriaCardelV2.Contenedores
{
    public class VentaRepository
    {
        private readonly DatabaseConnection _databaseConnection;

        public VentaRepository(DatabaseConnection databaseConnection)
        {
            _databaseConnection = databaseConnection;
        }

        // Crear una nueva venta y devolver el ID generado
        public int AddVenta(Venta venta, MySqlConnection connection, MySqlTransaction transaction)
        {
            string query = "INSERT INTO Ventas (Fecha, Total, MontoPagado, Cambio) VALUES (@Fecha, @Total, @MontoPagado, @Cambio); SELECT LAST_INSERT_ID();";
            using (MySqlCommand command = new MySqlCommand(query, connection, transaction))
            {
                command.Parameters.AddWithValue("@Fecha", venta.Fecha);
                command.Parameters.AddWithValue("@Total", venta.Total);
                command.Parameters.AddWithValue("@MontoPagado", (object)venta.MontoPagado ?? DBNull.Value);
                command.Parameters.AddWithValue("@Cambio", (object)venta.Cambio ?? DBNull.Value);

                return Convert.ToInt32(command.ExecuteScalar());
            }
        }

        // Obtener todas las ventas
        public DataTable GetAllSales()
        {
            DataTable dt = new DataTable();

            try
            {
                using (MySqlConnection connection = _databaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT * FROM Ventas";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    MySqlDataAdapter da = new MySqlDataAdapter(command);

                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las ventas: {ex.Message}");
            }

            return dt;
        }

        // Obtener venta por ID
        public Venta GetVentaById(int id)
        {
            Venta venta = null;

            using (MySqlConnection connection = _databaseConnection.GetConnection())
            {
                connection.Open();
                string query = "SELECT * FROM Ventas WHERE IdVenta = @IdVenta";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdVenta", id);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            venta = new Venta
                            {
                                IdVenta = Convert.ToInt32(reader["IdVenta"]),
                                Fecha = Convert.ToDateTime(reader["Fecha"]),
                                Total = Convert.ToDecimal(reader["Total"]),
                                MontoPagado = reader["MontoPagado"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(reader["MontoPagado"]),
                                Cambio = reader["Cambio"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(reader["Cambio"])
                            };
                        }
                    }
                }
            }

            return venta;
        }

        // Actualizar una venta
        public void UpdateVenta(Venta venta)
        {
            using (MySqlConnection connection = _databaseConnection.GetConnection())
            {
                connection.Open();
                string query = "UPDATE Ventas SET Fecha = @Fecha, Total = @Total, MontoPagado = @MontoPagado, Cambio = @Cambio WHERE IdVenta = @IdVenta";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Fecha", venta.Fecha);
                    command.Parameters.AddWithValue("@Total", venta.Total);
                    command.Parameters.AddWithValue("@MontoPagado", (object)venta.MontoPagado ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Cambio", (object)venta.Cambio ?? DBNull.Value);
                    command.Parameters.AddWithValue("@IdVenta", venta.IdVenta);

                    command.ExecuteNonQuery();
                }
            }
        }

        // Eliminar una venta
        public void DeleteVenta(int id)
        {
            using (MySqlConnection connection = _databaseConnection.GetConnection())
            {
                connection.Open();
                string query = "DELETE FROM Ventas WHERE IdVenta = @IdVenta";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdVenta", id);

                    command.ExecuteNonQuery();
                }
            }
        }

        // Obtener ventas por mes
        public DataTable GetSalesByMonth(int mes)
        {
            DataTable dtVentas = new DataTable();
            string query = "SELECT IdVenta, Fecha, Total, MontoPagado, Cambio FROM Ventas WHERE MONTH(Fecha) = @Mes";

            using (MySqlConnection conn = _databaseConnection.GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Mes", mes);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        dtVentas.Load(reader);
                    }
                }
            }
            return dtVentas;
        }

        // Obtener ventas por fecha específica
        public DataTable GetSalesBySpecificDate(DateTime fecha)
        {
            DataTable dtVentas = new DataTable();
            string query = "SELECT IdVenta, Fecha, Total, MontoPagado, Cambio FROM Ventas WHERE DATE(Fecha) = @Fecha";

            using (MySqlConnection conn = _databaseConnection.GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Fecha", fecha.Date); // Asegúrate de comparar solo la parte de la fecha, sin la hora
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        dtVentas.Load(reader);
                    }
                }
            }
            return dtVentas;
        }

        public DataTable GetSalesByMounth(int mes)
        {
            DataTable dtVentas = new DataTable();
            string query = "SELECT IdVenta, Fecha, Total, MontoPagado, Cambio FROM Ventas WHERE MONTH(Fecha) = @Mes";

            using (MySqlConnection conn = _databaseConnection.GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Mes", mes);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        dtVentas.Load(reader);
                    }
                }
            }
            return dtVentas;
        }
    }
}
