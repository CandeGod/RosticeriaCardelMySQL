using Microsoft.Data.SqlClient;
using RosticeriaCardel;
using RosticeriaCardelV2.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RosticeriaCardelV2.Contenedores
{
    public class ProductoRepository
    {
        private readonly DatabaseConnection _databaseConnection;

        public ProductoRepository(DatabaseConnection databaseConnection)
        {
            _databaseConnection = databaseConnection;
        }

        // Crear un nuevo producto
        public void AddProducto(Producto producto)
        {
            using (SqlConnection connection = _databaseConnection.GetConnection())
            {
                try
                {
                    string query = "INSERT INTO Productos (Nombre, Precio, Stock) VALUES (@Nombre, @Precio, @Stock)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Nombre", producto.Nombre);
                        command.Parameters.AddWithValue("@Precio", producto.Precio);
                        command.Parameters.AddWithValue("@Stock", producto.Stock);

                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al agregar el producto: " + ex.Message);
                }
                finally
                {
                    connection.Close(); // Asegurarse de cerrar la conexión
                }
            }
        }
        // Leer todos los productos
        public List<Producto> GetAllProductos()
        {
            List<Producto> productos = new List<Producto>();

            try
            {
                using (SqlConnection connection = _databaseConnection.GetConnection())
                {
                    string query = "SELECT * FROM Productos";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataAdapter da = new SqlDataAdapter(command);

                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    foreach (DataRow row in dt.Rows)
                    {
                        Producto producto = new Producto
                        {
                            IdProducto = row["IdProducto"] != DBNull.Value ? Convert.ToInt32(row["IdProducto"]) : 0,
                            Nombre = row["Nombre"] != DBNull.Value ? row["Nombre"].ToString() : string.Empty,
                            Precio = row["Precio"] != DBNull.Value ? Convert.ToDecimal(row["Precio"]) : 0m,
                            Stock = row["Stock"] != DBNull.Value ? Convert.ToDecimal(row["Stock"]) : 0
                        };
                        productos.Add(producto);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar productos: {ex.Message}");
            }

            return productos;
        }



        // Leer un producto por ID
        public Producto GetProductoById(int idProducto)
        {
            // Verifica que el idProducto sea válido
            if (idProducto <= 0)
            {
                throw new ArgumentException("El ID del producto debe ser mayor que cero.", nameof(idProducto));
            }

            try
            {
                using (SqlConnection connection = _databaseConnection.GetConnection())
                {
                    string query = "SELECT Nombre, Precio FROM Productos WHERE IdProducto = @IdProducto";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@IdProducto", idProducto);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string nombreProducto = reader["Nombre"].ToString();
                                decimal precio = reader["Precio"] != DBNull.Value ? Convert.ToDecimal(reader["Precio"]) : 0.0m;

                                // Crea y retorna una instancia de Producto con los datos obtenidos
                                return new Producto
                                {
                                    IdProducto = idProducto,
                                    Nombre = nombreProducto,
                                    Precio = precio
                                };
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                // Manejo de excepción SQL (por ejemplo, errores de conexión o consulta)
                // Puedes registrar el error o lanzar una excepción personalizada
                throw new Exception("Error al recuperar el producto desde la base de datos.", ex);
            }
            catch (Exception ex)
            {
                // Manejo de otras excepciones
                throw new Exception("Se produjo un error al recuperar el producto.", ex);
            }

            // Si el producto no existe, se retorna null
            return null;
        }

        // Actualizar un producto
        public void UpdateProducto(Producto producto)
        {
            using (SqlConnection connection = _databaseConnection.GetConnection())
            {
                try
                {
                    string query = "UPDATE Productos SET Nombre = @Nombre, Precio = @Precio, Stock = @Stock WHERE IdProducto = @IdProducto";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Nombre", producto.Nombre);
                        command.Parameters.AddWithValue("@Precio", producto.Precio);
                        command.Parameters.AddWithValue("@Stock", producto.Stock);
                        command.Parameters.AddWithValue("@IdProducto", producto.IdProducto);

                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al agregar el producto: " + ex.Message);
                }
                finally
                {
                    connection.Close(); // Asegurarse de cerrar la conexión
                }
            }
        }

        // Eliminar un producto
        public void DeleteProducto(int id)
        {
            using (SqlConnection connection = _databaseConnection.GetConnection())
            {
                try
                {
                    string query = "DELETE FROM Productos WHERE IdProducto = @IdProducto";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@IdProducto", id);
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al eliminar el producto: " + ex.Message);
                }
                finally
                {
                    connection.Close(); // Asegurarse de cerrar la conexión
                }
            }
        }

        public void DecreaseStock(int idProducto, decimal cantidad, SqlConnection connection, SqlTransaction transaction)
        {
            string query = "UPDATE Productos SET Stock = Stock - @Cantidad WHERE IdProducto = @IdProducto";
            using (SqlCommand command = new SqlCommand(query, connection, transaction))
            {
                command.Parameters.AddWithValue("@IdProducto", idProducto);
                command.Parameters.AddWithValue("@Cantidad", cantidad);

                command.ExecuteNonQuery();
            }
        }

        public bool HayStockSuficiente(int idProducto, decimal cantidadSolicitada, SqlConnection connection, SqlTransaction transaction)
        {
            string query = "SELECT Stock FROM Productos WHERE IdProducto = @IdProducto";
            using (SqlCommand command = new SqlCommand(query, connection, transaction))
            {
                command.Parameters.AddWithValue("@IdProducto", idProducto);
                decimal stockDisponible = (decimal)command.ExecuteScalar();

                return stockDisponible >= cantidadSolicitada;
            }
        }


    }
}
