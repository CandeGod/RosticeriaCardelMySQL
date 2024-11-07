using MySql.Data.MySqlClient;
using RosticeriaCardel;
using RosticeriaCardelV2.Clases;
using System;
using System.Collections.Generic;

namespace RosticeriaCardelV2.Contenedores
{
    public class VariacionProductoRepository
    {
        private readonly DatabaseConnection _databaseConnection;

        public VariacionProductoRepository(DatabaseConnection databaseConnection)
        {
            _databaseConnection = databaseConnection;
        }

        public void AddVariacion(VariacionProducto variacion)
        {
            using (MySqlConnection connection = _databaseConnection.GetConnection())
            {
                try
                {
                    connection.Open(); // Asegura que la conexión se abre aquí
                    string query = "INSERT INTO Variaciones (IdProducto, NombreVariacion, Precio, Activo) VALUES (@IdProducto, @NombreVariacion, @Precio, @Activo)";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@IdProducto", variacion.IdProducto);
                        command.Parameters.AddWithValue("@NombreVariacion", variacion.NombreVariacion);
                        command.Parameters.AddWithValue("@Precio", variacion.Precio);
                        command.Parameters.AddWithValue("@Activo", variacion.Activo);

                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al agregar la variación: " + ex.Message);
                }
            }
        }

        public List<VariacionProducto> GetAllVariacionesByProductoId(int idProducto)
        {
            List<VariacionProducto> variaciones = new List<VariacionProducto>();

            try
            {
                using (MySqlConnection connection = _databaseConnection.GetConnection())
                {
                    connection.Open(); // Asegura que la conexión se abre aquí
                    string query = "SELECT * FROM Variaciones WHERE IdProducto = @IdProducto";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@IdProducto", idProducto);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                VariacionProducto variacion = new VariacionProducto
                                (
                                    reader["IdVariacion"] != DBNull.Value ? Convert.ToInt32(reader["IdVariacion"]) : 0,
                                    idProducto,
                                    reader["NombreVariacion"].ToString(),
                                    reader["Precio"] != DBNull.Value ? Convert.ToDecimal(reader["Precio"]) : 0m,
                                    reader["Activo"] != DBNull.Value ? Convert.ToBoolean(reader["Activo"]) : false
                                );
                                variaciones.Add(variacion);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al cargar las variaciones: {ex.Message}");
            }

            return variaciones;
        }

        public VariacionProducto GetVariacionById(int idVariacion)
        {
            if (idVariacion <= 0)
            {
                return null;
            }

            try
            {
                using (MySqlConnection connection = _databaseConnection.GetConnection())
                {
                    connection.Open(); // Asegura que la conexión se abre aquí
                    string query = "SELECT * FROM Variaciones WHERE IdVariacion = @IdVariacion";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@IdVariacion", idVariacion);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new VariacionProducto
                                (
                                    idVariacion,
                                    reader["IdProducto"] != DBNull.Value ? Convert.ToInt32(reader["IdProducto"]) : 0,
                                    reader["NombreVariacion"].ToString(),
                                    reader["Precio"] != DBNull.Value ? Convert.ToDecimal(reader["Precio"]) : 0.0m,
                                    reader["Activo"] != DBNull.Value ? Convert.ToBoolean(reader["Activo"]) : false
                                );
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Se produjo un error al recuperar la variación.", ex);
            }

            return null;
        }

        public void UpdateVariacion(VariacionProducto variacion)
        {
            using (MySqlConnection connection = _databaseConnection.GetConnection())
            {
                try
                {
                    connection.Open(); // Asegura que la conexión se abre aquí
                    string query = "UPDATE Variaciones SET NombreVariacion = @NombreVariacion, Precio = @Precio, Activo = @Activo WHERE IdVariacion = @IdVariacion";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@NombreVariacion", variacion.NombreVariacion);
                        command.Parameters.AddWithValue("@Precio", variacion.Precio);
                        command.Parameters.AddWithValue("@Activo", variacion.Activo);
                        command.Parameters.AddWithValue("@IdVariacion", variacion.IdVariacion);

                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al actualizar la variación: " + ex.Message);
                }
            }
        }

        public void DeleteVariacion(int id)
        {
            using (MySqlConnection connection = _databaseConnection.GetConnection())
            {
                try
                {
                    connection.Open(); // Asegura que la conexión se abre aquí
                    string query = "UPDATE Variaciones SET Activo = 0 WHERE IdVariacion = @IdVariacion"; // Marcar como inactiva
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@IdVariacion", id);
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al eliminar la variación: " + ex.Message);
                }
            }
        }

        public void DisminuirStockProducto(int idProducto)
        {
            using (MySqlConnection connection = _databaseConnection.GetConnection())
            {
                try
                {
                    connection.Open(); // Asegura que la conexión se abre aquí

                    // Recuperar el producto de la base de datos
                    string selectQuery = "SELECT Stock FROM Productos WHERE IdProducto = @IdProducto";
                    using (MySqlCommand selectCommand = new MySqlCommand(selectQuery, connection))
                    {
                        selectCommand.Parameters.AddWithValue("@IdProducto", idProducto);

                        var stock = selectCommand.ExecuteScalar();
                        if (stock != null && decimal.TryParse(stock.ToString(), out decimal currentStock))
                        {
                            // Reducir el stock
                            currentStock -= 1;

                            // Actualizar el stock en la base de datos
                            string updateQuery = "UPDATE Productos SET Stock = @Stock WHERE IdProducto = @IdProducto";
                            using (MySqlCommand updateCommand = new MySqlCommand(updateQuery, connection))
                            {
                                updateCommand.Parameters.AddWithValue("@Stock", currentStock);
                                updateCommand.Parameters.AddWithValue("@IdProducto", idProducto);
                                updateCommand.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            throw new Exception("No se encontró el producto o el stock no es válido.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al disminuir el stock del producto: " + ex.Message);
                }
            }
        }
    }
}
