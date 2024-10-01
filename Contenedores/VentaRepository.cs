using Microsoft.Data.SqlClient;
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
    public class VentaRepository
    {
        private readonly DatabaseConnection _databaseConnection;

        public VentaRepository(DatabaseConnection databaseConnection)
        {
            _databaseConnection = databaseConnection;
        }

        // Crear una nueva venta y devolver el ID generado
        public int AddVenta(Venta venta, SqlConnection connection, SqlTransaction transaction)
        {
            string query = "INSERT INTO Ventas (Fecha, Total, MontoPagado, Cambio) OUTPUT INSERTED.IdVenta VALUES (@Fecha, @Total, @MontoPagado, @Cambio)";
            using (SqlCommand command = new SqlCommand(query, connection, transaction))
            {
                command.Parameters.AddWithValue("@Fecha", venta.Fecha);
                command.Parameters.AddWithValue("@Total", venta.Total);
                command.Parameters.AddWithValue("@MontoPagado", (object)venta.MontoPagado ?? DBNull.Value);
                command.Parameters.AddWithValue("@Cambio", (object)venta.Cambio ?? DBNull.Value);

                return (int)command.ExecuteScalar();
            }
        }




        public DataTable GetAllSales()
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = _databaseConnection.GetConnection())
                {
                    string query = "SELECT * FROM Ventas";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataAdapter da = new SqlDataAdapter(command);

                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las ventas: {ex.Message}");
            }

            return dt;
        }

        public Venta GetVentaById(int id)
        {
            Venta venta = null;

            using (SqlConnection connection = _databaseConnection.GetConnection())
            {
                connection.Open();
                string query = "SELECT * FROM Ventas WHERE IdVenta = @IdVenta";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdVenta", id);

                    using (SqlDataReader reader = command.ExecuteReader())
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

        public void UpdateVenta(Venta venta)
        {
            using (SqlConnection connection = _databaseConnection.GetConnection())
            {
                connection.Open();
                string query = "UPDATE Ventas SET Fecha = @Fecha, Total = @Total, MontoPagado = @MontoPagado, Cambio = @Cambio WHERE IdVenta = @IdVenta";
                using (SqlCommand command = new SqlCommand(query, connection))
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

        public void DeleteVenta(int id)
        {
            using (SqlConnection connection = _databaseConnection.GetConnection())
            {
                connection.Open();
                string query = "DELETE FROM Ventas WHERE IdVenta = @IdVenta";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdVenta", id);

                    command.ExecuteNonQuery();
                }
            }
        }


        public DataTable GetSalesByMounth(int mes)
        {
            DataTable dtVentas = new DataTable();
            string query = "SELECT IdVenta, Fecha, Total, MontoPagado, Cambio FROM Ventas WHERE MONTH(Fecha) = @Mes";

            using (SqlConnection conn = _databaseConnection.GetConnection())
            {

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Mes", mes);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        dtVentas.Load(reader);
                    }
                }
            }
            return dtVentas;
        }

        public DataTable GetSalesBySpecificDate(DateTime fecha)
        {
            DataTable dtVentas = new DataTable();
            string query = "SELECT IdVenta, Fecha, Total, MontoPagado, Cambio FROM Ventas WHERE CAST(Fecha AS DATE) = @Fecha";

            using (SqlConnection conn = _databaseConnection.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Fecha", fecha.Date); // Asegúrate de comparar solo la parte de la fecha, sin la hora
                    
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        dtVentas.Load(reader);
                    }
                }
            }
            return dtVentas;
        }




    }

}

