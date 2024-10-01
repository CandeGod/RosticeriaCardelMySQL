using RosticeriaCardelV2.Formularios;
using System.Globalization;

namespace RosticeriaCardelV2
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            CultureInfo culture = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
            ApplicationConfiguration.Initialize();
            Application.Run(new FrmStart());
        }
    }
}