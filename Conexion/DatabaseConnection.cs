using System;
using System.Data;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace RosticeriaCardel
{
    public class DatabaseConnection
    {
        private readonly string cloudConnectionString = "Server=b43pdopm39vxyqhdhvne-mysql.services.clever-cloud.com;Database=b43pdopm39vxyqhdhvne;Uid=ultjvjsxnryp45yf;Pwd=1l20eGFJNbDjJCWwK4Nd;";
        private readonly string localConnectionString = "Server=localhost;Database=rosticeriacardel;Uid=root;Pwd=Cande213apo$;";

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(localConnectionString);
        }

        public MySqlConnection GetCloudConnection()
        {
            return new MySqlConnection(cloudConnectionString);
        }

        public async Task SyncToCloudAsync()
        {
            try
            {
                using (var localConnection = GetConnection())
                using (var cloudConnection = GetCloudConnection())
                {
                    await localConnection.OpenAsync();
                    await cloudConnection.OpenAsync();

                    // Leer datos locales pendientes de sincronizar
                    var queryLocal = "SELECT * FROM ventas WHERE sincronizado = 0";
                    var commandLocal = new MySqlCommand(queryLocal, localConnection);
                    var reader = await commandLocal.ExecuteReaderAsync();

                    while (await reader.ReadAsync())
                    {
                        // Inserta datos en la base de datos en la nube
                        var queryCloud = "INSERT INTO ventas (IdVenta, Fecha, Total) VALUES (@IdVenta, @Fecha, @Total)";
                        var commandCloud = new MySqlCommand(queryCloud, cloudConnection);

                        commandCloud.Parameters.AddWithValue("@IdVenta", reader["IdVenta"]);
                        commandCloud.Parameters.AddWithValue("@Fecha", reader["Fecha"]);
                        commandCloud.Parameters.AddWithValue("@Total", reader["Total"]);

                        await commandCloud.ExecuteNonQueryAsync();

                        // Actualiza el estado de sincronización local
                        var updateLocal = "UPDATE ventas SET sincronizado = 1 WHERE IdVenta = @IdVenta";
                        var commandUpdate = new MySqlCommand(updateLocal, localConnection);
                        commandUpdate.Parameters.AddWithValue("@IdVenta", reader["IdVenta"]);
                        await commandUpdate.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores
                Console.WriteLine("Error al sincronizar: " + ex.Message);
            }
        }

        public async Task SyncProductosToCloudAsync()
        {
            try
            {
                using (var localConnection = GetConnection())
                using (var cloudConnection = GetCloudConnection())
                {
                    await localConnection.OpenAsync();
                    await cloudConnection.OpenAsync();

                    // Leer productos locales pendientes de sincronizar
                    var queryLocal = "SELECT * FROM Productos WHERE sincronizado = 0";
                    var commandLocal = new MySqlCommand(queryLocal, localConnection);
                    var reader = await commandLocal.ExecuteReaderAsync();

                    while (await reader.ReadAsync())
                    {
                        // Inserta datos en la base de datos en la nube
                        var queryCloud = "INSERT INTO Productos (IdProducto, Nombre, Precio, Stock, Activo, Imagen) VALUES (@IdProducto, @Nombre, @Precio, @Stock, @Activo, @Imagen)";
                        var commandCloud = new MySqlCommand(queryCloud, cloudConnection);

                        commandCloud.Parameters.AddWithValue("@IdProducto", reader["IdProducto"]);
                        commandCloud.Parameters.AddWithValue("@Nombre", reader["Nombre"]);
                        commandCloud.Parameters.AddWithValue("@Precio", reader["Precio"]);
                        commandCloud.Parameters.AddWithValue("@Stock", reader["Stock"]);
                        commandCloud.Parameters.AddWithValue("@Activo", reader["Activo"]);
                        commandCloud.Parameters.AddWithValue("@Imagen", reader["Imagen"] != DBNull.Value ? reader["Imagen"] : null);

                        await commandCloud.ExecuteNonQueryAsync();

                        // Actualiza el estado de sincronización local
                        var updateLocal = "UPDATE Productos SET sincronizado = 1 WHERE IdProducto = @IdProducto";
                        var commandUpdate = new MySqlCommand(updateLocal, localConnection);
                        commandUpdate.Parameters.AddWithValue("@IdProducto", reader["IdProducto"]);
                        await commandUpdate.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores
                Console.WriteLine("Error al sincronizar productos: " + ex.Message);
            }
        }

    }
}
