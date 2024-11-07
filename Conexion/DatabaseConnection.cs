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
            return new MySqlConnection("Server=b43pdopm39vxyqhdhvne-mysql.services.clever-cloud.com;Database=b43pdopm39vxyqhdhvne;Uid=ultjvjsxnryp45yf;Pwd=1l20eGFJNbDjJCWwK4Nd;");
        }

    }
}
