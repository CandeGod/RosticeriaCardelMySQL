using RosticeriaCardel;
using RosticeriaCardelV2.Conexion;
using RosticeriaCardelV2.Contenedores;
using RosticeriaCardelV2.Formularios;
using System.Globalization;

namespace RosticeriaCardelV2
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        static SyncService _syncService;
        [STAThread]
        static void Main()
        {

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            CultureInfo culture = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
            ApplicationConfiguration.Initialize();

            // Configura el servicio de sincronización
            var databaseConnection = new DatabaseConnection();
            var productoRepository = new ProductoRepository(databaseConnection);
            var ventaRepository = new VentaRepository(databaseConnection);
            _syncService = new SyncService(productoRepository, ventaRepository);

            // Inicia el servicio de sincronización
            _syncService.Start();
            Application.Run(new FrmStart());

            Application.ApplicationExit += (sender, args) =>
            {
                _syncService?.Stop();
            };

        }
    }
}