using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;

namespace RosticeriaCardel
{
    public class DatabaseConnection
    {
       

        public SqlConnection GetConnection()
        {
            SqlConnection conexion = new SqlConnection("SERVER=DELL\\CANDE;DATABASE=RosticeriaCardelV2;Integrated Security=True;TrustServerCertificate=True;");

            conexion.Open();

            return conexion;
        }

        public bool ExecRespaldoBD()
{
    bool result = true;
    
    // Ruta de OneDrive
    string backupPath = @"C:\Users\Cristian\OneDrive\Pruebasql\";
    
    try
    {
        string spSQL = "sp_BackupFullDatabase";
        using (SqlConnection connection = GetConnection())
        {
            using (SqlCommand command = new SqlCommand(spSQL, connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@BackupPath", SqlDbType.NVarChar, 255)
                {
                    Value = backupPath
                });
                command.ExecuteNonQuery();
            }
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show("Error: " + ex.Message);
        result = false;
    }

    return result;
}

    }
}
