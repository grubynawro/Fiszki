using System;
using System.Data.SQLite;
using System.Diagnostics;


namespace Fiszki.Data
{
    static class DatabaseConnection
    {
        private static SQLiteConnection _connection;


        

        public static void Connect()
        {
            if (_connection != null)
            {
                
                try
                {
                    _connection = new SQLiteConnection("Data Source=Fisz.s3db");
                    _connection.Open();
                    Debug.Print("połaczenie ok");
                }
                catch (Exception)
                {
                    Debug.Print("Bład połącznia z bazą danych");
                }
            }
        }

		public static SQLiteCommand Execute(string query)
        {
            return new SQLiteCommand(query,_connection);
        }

        public static void Disconnect()
        {
             _connection.Close();
        }

    }

}
