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
    public class DetalleVentaRepository
    {
        private readonly DatabaseConnection _databaseConnection;

        public DetalleVentaRepository(DatabaseConnection databaseConnection)
        {
            _databaseConnection = databaseConnection;
        }
        public void AddDetalleVenta(DetalleVenta detalle, int idVenta, SqlConnection connection, SqlTransaction transaction)
        {
            string query = "INSERT INTO DetalleVenta (IdVenta, IdProducto, Cantidad, Subtotal) VALUES (@IdVenta, @IdProducto, @Cantidad, @Subtotal)";
            using (SqlCommand command = new SqlCommand(query, connection, transaction))
            {
                command.Parameters.AddWithValue("@IdVenta", idVenta);
                command.Parameters.AddWithValue("@IdProducto", detalle.IdProducto);
                command.Parameters.AddWithValue("@Cantidad", detalle.Cantidad);
                command.Parameters.AddWithValue("@Subtotal", detalle.Subtotal); // Actualizado aquí

                command.ExecuteNonQuery();
            }
        }

        public DataTable GetSaleDetails(int idVenta)
{
    DataTable dt = new DataTable();

    try
    {
        using (SqlConnection connection = _databaseConnection.GetConnection())
        {
            string query = @"
SELECT 
    v.IdVenta,
    v.Fecha,
    v.MontoPagado, 
    v.Cambio,
    p.Nombre, 
    dv.Cantidad, 
    p.Precio,
    dv.Subtotal 
FROM 
    Ventas v
INNER JOIN 
    DetalleVenta dv ON v.IdVenta = dv.IdVenta
INNER JOIN 
    Productos p ON dv.IdProducto = p.IdProducto
WHERE 
    v.IdVenta = @IdVenta";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@IdVenta", idVenta);
                SqlDataAdapter da = new SqlDataAdapter(command);
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
                using (SqlConnection connection = _databaseConnection.GetConnection())
                {
                    string query = @"
            SELECT 
                p.Nombre AS Producto,
                SUM(dv.Cantidad) AS CantidadVendida,
                SUM(dv.Subtotal) AS Subtotal
            FROM 
                Ventas v
            INNER JOIN 
                DetalleVenta dv ON v.IdVenta = dv.IdVenta
            INNER JOIN 
                Productos p ON dv.IdProducto = p.IdProducto
            WHERE 
                MONTH(v.Fecha) = @Mes
            GROUP BY 
                p.Nombre";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Mes", mes);
                        SqlDataAdapter da = new SqlDataAdapter(command);
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
                    condicionFecha = "CONVERT(date, v.Fecha) = CONVERT(date, GETDATE())";
                    break;
                case "Ayer":
                    condicionFecha = "CONVERT(date, v.Fecha) = CONVERT(date, DATEADD(day, -1, GETDATE()))";
                    break;
                case "Esta semana":
                    condicionFecha = "v.Fecha >= DATEADD(day, 1 - DATEPART(dw, GETDATE()), CONVERT(date, GETDATE()))" +
                                     " AND v.Fecha < DATEADD(day, 8 - DATEPART(dw, GETDATE()), CONVERT(date, GETDATE()))";
                    break;
                case "Este mes":
                    condicionFecha = "v.Fecha >= CONVERT(date, DATEADD(month, DATEDIFF(month, 0, GETDATE()), 0))" +
                                     " AND v.Fecha < CONVERT(date, DATEADD(month, DATEDIFF(month, 0, GETDATE()) + 1, 0))";
                    break;
                default:
                    condicionFecha = "1=1"; // Sin filtro específico
                    break;
            }

            string query = $@"
    SELECT 
        p.Nombre AS Producto, 
        SUM(dv.Cantidad) AS CantidadVendida, 
        SUM(dv.Subtotal) AS Subtotal 
    FROM 
        Ventas v 
    INNER JOIN 
        DetalleVenta dv ON v.IdVenta = dv.IdVenta 
    INNER JOIN 
        Productos p ON dv.IdProducto = p.IdProducto 
    WHERE 
        {condicionFecha} 
    GROUP BY 
        p.Nombre";

            try
            {
                using (SqlConnection connection = _databaseConnection.GetConnection())
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(command);
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


        public DataTable GetSalesSummaryByFilterdgv(string filtro)
        {
            DataTable dt = new DataTable();
            string condicionFecha = "";

            switch (filtro)
            {
                case "Hoy":
                    condicionFecha = "SELECT * FROM Ventas WHERE CONVERT(date, Fecha) =" +
                        "CONVERT (date,GETDATE())";
                    break;
                case "Ayer":
                    condicionFecha = "SELECT * FROM Ventas WHERE CONVERT(date, Fecha) =" +
                        "CONVERT(date,DATEADD(day, -1, GETDATE()))";
                    break;
                case "Esta semana":
                    condicionFecha = "SELECT * " +
                        "FROM Ventas " +
                        "WHERE Fecha >= DATEADD(day, 1 - DATEPART(dw, GETDATE()), CONVERT(date, GETDATE()))" +
                        " AND Fecha < DATEADD(day, 8 - DATEPART(dw, GETDATE()), CONVERT(date, GETDATE()));";
                    break;
                case "Este mes":
                    condicionFecha = "SELECT * " +
                        "FROM Ventas " +
                        "WHERE Fecha >= CONVERT(date, DATEADD(month, DATEDIFF(month, 0, GETDATE()), 0))" +
                        " AND Fecha < CONVERT(date, DATEADD(month, DATEDIFF(month, 0, GETDATE()) + 1, 0));";
                    break;
                default:
                    condicionFecha = "SELECT * FROM Ventas;"; // Sin filtro específico
                    break;
            }

            string query = condicionFecha;

            try
            {
                using (SqlConnection connection = _databaseConnection.GetConnection())
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(command);
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

            string query = "SELECT p.Nombre AS Producto, SUM(dv.Cantidad) AS CantidadVendida, SUM(dv.Subtotal) AS Subtotal " +
                           "FROM Ventas v " +
                           "INNER JOIN DetalleVenta dv ON v.IdVenta = dv.IdVenta " +
                           "INNER JOIN Productos p ON dv.IdProducto = p.IdProducto " +
                           "WHERE CONVERT(date, v.Fecha) = @Fecha " +
                           "GROUP BY p.Nombre";

            try
            {
                using (SqlConnection connection = _databaseConnection.GetConnection())
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Fecha", fecha.Date);

                        SqlDataAdapter da = new SqlDataAdapter(command);
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


    }
}
