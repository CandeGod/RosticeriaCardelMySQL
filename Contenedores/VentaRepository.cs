using MySql.Data.MySqlClient;
using RosticeriaCardel;
using RosticeriaCardelV2.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
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
            string query = @"INSERT INTO Ventas (Fecha, Total, MontoPagado, Cambio, Sincronizado) 
                             VALUES (@Fecha, @Total, @MontoPagado, @Cambio, 0); 
                             SELECT LAST_INSERT_ID();";
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

        // Obtener ventas no sincronizadas
        public DataTable GetUnsyncedSales()
        {
            DataTable dt = new DataTable();

            try
            {
                using (MySqlConnection connection = _databaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT * FROM Ventas WHERE Sincronizado = 0";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    MySqlDataAdapter da = new MySqlDataAdapter(command);

                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las ventas no sincronizadas: {ex.Message}");
            }

            return dt;
        }

        // Marcar ventas como sincronizadas
        public void MarkSalesAsSynced(int[] ventaIds)
        {
            try
            {
                using (MySqlConnection connection = _databaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = "UPDATE Ventas SET Sincronizado = 1 WHERE IdVenta IN (" + string.Join(",", ventaIds) + ")";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al marcar ventas como sincronizadas: {ex.Message}");
            }
        }

        // Sincronización asíncrona de ventas
        public async Task SyncSalesToCloudAsync()
        {
            try
            {
                var unsyncedSales = GetUnsyncedSales();

                if (unsyncedSales.Rows.Count == 0)
                    return;

                using (MySqlConnection cloudConnection = _databaseConnection.GetCloudConnection())
                {
                    await cloudConnection.OpenAsync();

                    List<int> syncedIds = new List<int>();

                    foreach (DataRow row in unsyncedSales.Rows)
                    {
                        var query = "INSERT INTO Ventas (IdVenta, Fecha, Total, MontoPagado, Cambio) " +
                                    "VALUES (@IdVenta, @Fecha, @Total, @MontoPagado, @Cambio)";
                        using (MySqlCommand command = new MySqlCommand(query, cloudConnection))
                        {
                            command.Parameters.AddWithValue("@IdVenta", row["IdVenta"]);
                            command.Parameters.AddWithValue("@Fecha", row["Fecha"]);
                            command.Parameters.AddWithValue("@Total", row["Total"]);
                            command.Parameters.AddWithValue("@MontoPagado", row["MontoPagado"] == DBNull.Value ? null : row["MontoPagado"]);
                            command.Parameters.AddWithValue("@Cambio", row["Cambio"] == DBNull.Value ? null : row["Cambio"]);

                            await command.ExecuteNonQueryAsync();
                            syncedIds.Add(Convert.ToInt32(row["IdVenta"]));
                        }
                    }

                    // Marcar las ventas como sincronizadas en la base local
                    MarkSalesAsSynced(syncedIds.ToArray());
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show($"Error al sincronizar ventas: {ex.Message}");
                Console.WriteLine("Error al sincronizar productos: " + ex.Message);
            }
        }

        // Otros métodos: Actualizar, eliminar y obtener ventas por criterios
        public void UpdateVenta(Venta venta)
        {
            using (MySqlConnection connection = _databaseConnection.GetConnection())
            {
                connection.Open();
                string query = @"UPDATE Ventas 
                                 SET Fecha = @Fecha, Total = @Total, MontoPagado = @MontoPagado, Cambio = @Cambio, Sincronizado = 0 
                                 WHERE IdVenta = @IdVenta";
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
    }
}
