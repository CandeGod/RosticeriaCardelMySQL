using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace RosticeriaCardel
{
    public class DatabaseConnection
    {


        public MySqlConnection GetConnection()
        {
            
            MySqlConnection conexion = new MySqlConnection("Server=localhost;Database=rosticeriacardel;Uid=root;Pwd=Cande213apo$;");

            
            conexion.Open();

            return conexion;
        }

        /*
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
}*/

    }
}
