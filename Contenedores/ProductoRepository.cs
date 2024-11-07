using MySql.Data.MySqlClient;
using RosticeriaCardel;
using RosticeriaCardelV2.Clases;
using System;
using System.Collections.Generic;
using System.Data;

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
            using (MySqlConnection connection = _databaseConnection.GetConnection())
            {
                try
                {
                    string query = "INSERT INTO Productos (Nombre, Precio, Stock, Activo, Imagen) VALUES (@Nombre, @Precio, @Stock, @Activo, @Imagen)";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Nombre", producto.Nombre);
                        command.Parameters.AddWithValue("@Precio", producto.Precio);
                        command.Parameters.AddWithValue("@Stock", producto.Stock);
                        command.Parameters.AddWithValue("@Activo", producto.Activo);
                        command.Parameters.AddWithValue("@Imagen", producto.Imagen);
                        connection.Open(); // Abrir la conexión aquí
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al agregar el producto: " + ex.Message);
                }
            }
        }

        // Leer todos los productos
        public List<Producto> GetAllProductos()
        {
            List<Producto> productos = new List<Producto>();

            try
            {
                using (MySqlConnection connection = _databaseConnection.GetConnection())
                {
                    string query = "SELECT * FROM Productos";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        connection.Open(); // Abrir la conexión aquí
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Producto producto = new Producto
                                {
                                    IdProducto = reader["IdProducto"] != DBNull.Value ? Convert.ToInt32(reader["IdProducto"]) : 0,
                                    Nombre = reader["Nombre"] != DBNull.Value ? reader["Nombre"].ToString() : string.Empty,
                                    Precio = reader["Precio"] != DBNull.Value ? Convert.ToDecimal(reader["Precio"]) : 0m,
                                    Stock = reader["Stock"] != DBNull.Value ? Convert.ToDecimal(reader["Stock"]) : 0,
                                    Activo = reader["Activo"] != DBNull.Value ? Convert.ToBoolean(reader["Activo"]) : false,
                                    Imagen = reader["Imagen"] != DBNull.Value ? (byte[])reader["Imagen"] : null
                                };
                                productos.Add(producto);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al cargar productos: {ex.Message}");
            }

            return productos;
        }

        // Leer un producto por ID
        public Producto GetProductoById(int idProducto)
        {
            if (idProducto <= 0)
            {
                throw new ArgumentException("El ID del producto debe ser mayor que cero.", nameof(idProducto));
            }

            try
            {
                using (MySqlConnection connection = _databaseConnection.GetConnection())
                {
                    string query = "SELECT Nombre, Precio, Activo FROM Productos WHERE IdProducto = @IdProducto";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@IdProducto", idProducto);
                        connection.Open(); // Abrir la conexión aquí
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Producto
                                {
                                    IdProducto = idProducto,
                                    Nombre = reader["Nombre"].ToString(),
                                    Precio = reader["Precio"] != DBNull.Value ? Convert.ToDecimal(reader["Precio"]) : 0.0m,
                                    Activo = reader["Activo"] != DBNull.Value ? Convert.ToBoolean(reader["Activo"]) : false
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Se produjo un error al recuperar el producto.", ex);
            }

            return null;
        }

        // Actualizar un producto
        public void UpdateProducto(Producto producto)
        {
            using (MySqlConnection connection = _databaseConnection.GetConnection())
            {
                try
                {
                    string query = "UPDATE Productos SET Nombre = @Nombre, Precio = @Precio, Stock = @Stock, Activo = @Activo, Imagen = @Imagen WHERE IdProducto = @IdProducto";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Nombre", producto.Nombre);
                        command.Parameters.AddWithValue("@Precio", producto.Precio);
                        command.Parameters.AddWithValue("@Stock", producto.Stock);
                        command.Parameters.AddWithValue("@Activo", producto.Activo);
                        command.Parameters.AddWithValue("@IdProducto", producto.IdProducto);

                        if (producto.Imagen != null)
                        {
                            command.Parameters.AddWithValue("@Imagen", producto.Imagen);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@Imagen", DBNull.Value);
                        }

                        connection.Open(); // Abrir la conexión aquí
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al actualizar el producto: " + ex.Message);
                }
            }
        }

        // Eliminar un producto
        public void DeleteProducto(int id)
        {
            using (MySqlConnection connection = _databaseConnection.GetConnection())
            {
                try
                {
                    string query = "UPDATE Productos SET Activo = 0 WHERE IdProducto = @IdProducto";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@IdProducto", id);
                        connection.Open(); // Abrir la conexión aquí
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al eliminar el producto: " + ex.Message);
                }
            }
        }

        public void DecreaseStock(int idProducto, decimal cantidad, MySqlConnection connection, MySqlTransaction transaction)
        {
            string query = "UPDATE Productos SET Stock = Stock - @Cantidad WHERE IdProducto = @IdProducto";
            using (MySqlCommand command = new MySqlCommand(query, connection, transaction))
            {
                command.Parameters.AddWithValue("@IdProducto", idProducto);
                command.Parameters.AddWithValue("@Cantidad", cantidad);
                command.ExecuteNonQuery();
            }
        }

        public bool HayStockSuficiente(int idProducto, decimal cantidadSolicitada, MySqlConnection connection, MySqlTransaction transaction)
        {
            string query = "SELECT Stock FROM Productos WHERE IdProducto = @IdProducto";
            using (MySqlCommand command = new MySqlCommand(query, connection, transaction))
            {
                command.Parameters.AddWithValue("@IdProducto", idProducto);
                decimal stockDisponible = Convert.ToDecimal(command.ExecuteScalar());
                return stockDisponible >= cantidadSolicitada;
            }
        }

        public byte[] GetImagenById(int idProducto)
        {
            byte[] imagen = null;

            try
            {
                using (MySqlConnection connection = _databaseConnection.GetConnection())
                {
                    string query = "SELECT Imagen FROM Productos WHERE IdProducto = @IdProducto";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@IdProducto", idProducto);
                        connection.Open(); // Abrir la conexión aquí
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read() && reader["Imagen"] != DBNull.Value)
                            {
                                imagen = (byte[])reader["Imagen"];
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener la imagen del producto: {ex.Message}");
            }

            return imagen;
        }
    }
}
