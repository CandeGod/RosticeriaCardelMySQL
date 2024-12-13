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
    public class DetalleVentaRepository
    {
        private readonly DatabaseConnection _databaseConnection;

        public DetalleVentaRepository(DatabaseConnection databaseConnection)
        {
            _databaseConnection = databaseConnection;
        }

        public void AddDetalleVenta(DetalleVenta detalle, int idVenta, MySqlConnection connection, MySqlTransaction transaction)
        {
            // Consulta para insertar el detalle de la venta
            string queryInsert = "INSERT INTO DetalleVenta (IdVenta, IdProducto, IdVariacion, Cantidad, Subtotal) " +
                                 "VALUES (@IdVenta, @IdProducto, @IdVariacion, @Cantidad, @Subtotal)";

            using (MySqlCommand commandInsert = new MySqlCommand(queryInsert, connection, transaction))
            {
                commandInsert.Parameters.AddWithValue("@IdVenta", idVenta);
                commandInsert.Parameters.AddWithValue("@IdProducto", detalle.IdProducto);
                commandInsert.Parameters.AddWithValue("@Cantidad", detalle.Cantidad);
                commandInsert.Parameters.AddWithValue("@Subtotal", detalle.Subtotal);

                // Si IdVariacionProducto es mayor que 0, lo insertamos; de lo contrario, ponemos NULL
                if (detalle.IdVariacionProducto > 0)
                {
                    commandInsert.Parameters.AddWithValue("@IdVariacion", detalle.IdVariacionProducto);
                }
                else
                {
                    commandInsert.Parameters.AddWithValue("@IdVariacion", DBNull.Value); // Inserta NULL si no hay variación
                }

                // Ejecutar la inserción del detalle de venta
                commandInsert.ExecuteNonQuery();
            }

            // Consulta para actualizar el campo 'Sincronizado' del producto asociado
            string queryUpdate = "UPDATE Productos SET Sincronizado = 0 WHERE IdProducto = @IdProducto";

            using (MySqlCommand commandUpdate = new MySqlCommand(queryUpdate, connection, transaction))
            {
                commandUpdate.Parameters.AddWithValue("@IdProducto", detalle.IdProducto);

                // Ejecutar la actualización del campo 'Sincronizado'
                commandUpdate.ExecuteNonQuery();
            }
        }


        public DataTable GetSaleDetails(int idVenta)
        {
            DataTable dt = new DataTable();

            try
            {
                using (MySqlConnection connection = _databaseConnection.GetConnection())
                {
                    connection.Open(); // Abrir la conexión dentro del bloque using
                    string query = @"
                    SELECT 
                        v.IdVenta,
                        v.Fecha,
                        v.MontoPagado, 
                        v.Cambio,
                        p.Nombre,
                        va.NombreVariacion,
                        SUM(dv.Cantidad) AS Cantidad, 
                        p.Precio,
                        SUM(dv.Subtotal) AS Subtotal 
                    FROM 
                        Ventas v
                    INNER JOIN 
                        DetalleVenta dv ON v.IdVenta = dv.IdVenta
                    INNER JOIN 
                        Productos p ON dv.IdProducto = p.IdProducto
                    LEFT JOIN
                        Variaciones va ON dv.IdVariacion = va.IdVariacion 
                    WHERE 
                        v.IdVenta = @IdVenta
                    GROUP BY 
                        v.IdVenta, v.Fecha, v.MontoPagado, v.Cambio, p.Nombre, va.NombreVariacion, p.Precio";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@IdVenta", idVenta);
                        MySqlDataAdapter da = new MySqlDataAdapter(command);
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar detalles de la venta: {ex.Message}");
            }

            return dt;
        }

        public DataTable GetSalesSummaryByMonth(int mes)
        {
            DataTable dt = new DataTable();

            try
            {
                using (MySqlConnection connection = _databaseConnection.GetConnection())
                {
                    connection.Open(); // Abrir la conexión dentro del bloque using
                    string query = @"
                    SELECT 
                        p.Nombre AS Producto,
                        va.NombreVariacion,
                        SUM(dv.Cantidad) AS CantidadVendida,
                        SUM(dv.Subtotal) AS Subtotal
                    FROM 
                        Ventas v
                    INNER JOIN 
                        DetalleVenta dv ON v.IdVenta = dv.IdVenta
                    INNER JOIN 
                        Productos p ON dv.IdProducto = p.IdProducto
                    LEFT JOIN 
                        Variaciones va ON dv.IdVariacion = va.IdVariacion  
                    WHERE 
                        MONTH(v.Fecha) = @Mes
                    GROUP BY 
                        p.Nombre, va.NombreVariacion";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Mes", mes);
                        MySqlDataAdapter da = new MySqlDataAdapter(command);
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar resumen de ventas: {ex.Message}");
            }

            return dt;
        }

        public DataTable GetSalesSummaryByFilter(string filtro)
        {
            DataTable dt = new DataTable();
            string condicionFecha = "";

            switch (filtro)
            {
                case "Hoy":
                    condicionFecha = "DATE(v.Fecha) = CURDATE()";
                    break;
                case "Ayer":
                    condicionFecha = "DATE(v.Fecha) = CURDATE() - INTERVAL 1 DAY";
                    break;
                case "Esta semana":
                    condicionFecha = "YEARWEEK(v.Fecha, 1) = YEARWEEK(CURDATE(), 1)";
                    break;
                case "Este mes":
                    condicionFecha = "MONTH(v.Fecha) = MONTH(CURDATE()) AND YEAR(v.Fecha) = YEAR(CURDATE())";
                    break;
                default:
                    condicionFecha = "1=1"; // Sin filtro específico
                    break;
            }

            string query = $@"
            SELECT 
                p.Nombre AS Producto, 
                va.NombreVariacion, 
                SUM(dv.Cantidad) AS CantidadVendida, 
                SUM(dv.Subtotal) AS Subtotal 
            FROM 
                Ventas v 
            INNER JOIN 
                DetalleVenta dv ON v.IdVenta = dv.IdVenta 
            INNER JOIN 
                Productos p ON dv.IdProducto = p.IdProducto 
            LEFT JOIN 
                Variaciones va ON dv.IdVariacion = va.IdVariacion 
            WHERE 
                {condicionFecha} 
            GROUP BY 
                p.Nombre, va.NombreVariacion";

            try
            {
                using (MySqlConnection connection = _databaseConnection.GetConnection())
                {
                    connection.Open(); // Abrir la conexión dentro del bloque using
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        MySqlDataAdapter da = new MySqlDataAdapter(command);
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar resumen de ventas: {ex.Message}");
            }

            return dt;
        }

        public DataTable GetSalesBySpecificDate(DateTime fecha)
        {
            DataTable dt = new DataTable();

            string query = @"
            SELECT 
                p.Nombre AS Producto, 
                va.NombreVariacion, 
                SUM(dv.Cantidad) AS CantidadVendida, 
                SUM(dv.Subtotal) AS Subtotal 
            FROM 
                Ventas v 
            INNER JOIN 
                DetalleVenta dv ON v.IdVenta = dv.IdVenta 
            INNER JOIN 
                Productos p ON dv.IdProducto = p.IdProducto 
            LEFT JOIN 
                Variaciones va ON dv.IdVariacion = va.IdVariacion 
            WHERE 
                DATE(v.Fecha) = @Fecha 
            GROUP BY 
                p.Nombre, va.NombreVariacion";

            try
            {
                using (MySqlConnection connection = _databaseConnection.GetConnection())
                {
                    connection.Open(); // Abrir la conexión dentro del bloque using
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Fecha", fecha.Date);

                        MySqlDataAdapter da = new MySqlDataAdapter(command);
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las ventas para la fecha seleccionada: {ex.Message}");
            }

            return dt;
        }

        public DataTable GetSalesSummaryByFilterdgv(string filtro)
        {
            DataTable dt = new DataTable();
            string condicionFecha = "";

            switch (filtro)
            {
                case "Hoy":
                    condicionFecha = "SELECT * FROM Ventas WHERE DATE(Fecha) = CURDATE()";
                    break;
                case "Ayer":
                    condicionFecha = "SELECT * FROM Ventas WHERE DATE(Fecha) = CURDATE() - INTERVAL 1 DAY";
                    break;
                case "Esta semana":
                    condicionFecha = "SELECT * FROM Ventas WHERE YEARWEEK(Fecha, 1) = YEARWEEK(CURDATE(), 1)";
                    break;
                case "Este mes":
                    condicionFecha = "SELECT * FROM Ventas WHERE YEAR(Fecha) = YEAR(CURDATE()) AND MONTH(Fecha) = MONTH(CURDATE())";
                    break;
                default:
                    condicionFecha = "SELECT * FROM Ventas;"; // Sin filtro específico
                    break;
            }

            string query = condicionFecha;

            try
            {
                using (MySqlConnection connection = _databaseConnection.GetConnection())
                {
                    connection.Open(); // Abrir la conexión dentro del bloque using
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        MySqlDataAdapter da = new MySqlDataAdapter(command);
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar resumen de ventas: {ex.Message}");
            }

            return dt;
        }
    }
}
