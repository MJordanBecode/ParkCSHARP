using System;
using System.Data.SQLite;
using System.IO;

namespace Park.DB
{
    public class DatabaseManager
    {
        private string _dbPath;
        private SQLiteConnection _connection;

       public DatabaseManager(string dbFileName)
       {
           // Ajoute le dossier "DB" dans le chemin de base
           string dbDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DB");
       
           // Combine le chemin du dossier "DB" avec le nom du fichier
           _dbPath = Path.Combine(dbDirectory, dbFileName);
       
           // Initialise la connexion SQLite
           _connection = new SQLiteConnection($"Data Source={_dbPath};Version=3;");
       }

        public void Open()
        {
            if (_connection.State != System.Data.ConnectionState.Open)
                _connection.Open();
        }

        public void Close()
        {
            if (_connection.State != System.Data.ConnectionState.Closed)
                _connection.Close();
        }

        
    }
}
