using Park;
using Park.spectre;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Park.Menu.MainMenus;
using Microsoft.Data.Sqlite;
using Park.Menu;


namespace Park
{
    public class Program
    {
        public static void Main(string[] args)
        {

             StartMenu.Show(); // Start menu of the program
             //Header.Show(); // Header of the program
            
             //MainMenu.Show(); // Main menu of the program

            
        }
    }
}


//creation of database sqlite  
/*string dbFile = "DB/park.sqlite"; // fichier base SQLite (binaire)
              string sqlFile = "DB/park.sql"; // fichier script SQL (texte)
  
              if (File.Exists(dbFile))
              {
                  File.Delete(dbFile);
                  Console.WriteLine("Ancienne base supprimée.");
              }
  
              string sqlScript = File.ReadAllText(sqlFile);
  
              using var connection = new SqliteConnection($"Data Source={dbFile}");
              connection.Open();
  
              using var command = connection.CreateCommand();
  
              var commands = sqlScript.Split(';');
              foreach (var cmd in commands)
              {
                  string commandText = cmd.Trim();
                  if (!string.IsNullOrWhiteSpace(commandText))
                  {
                      command.CommandText = commandText;
                      try
                      {
                          command.ExecuteNonQuery();
                      }
                      catch (Exception ex)
                      {
                          Console.WriteLine($"Erreur avec la commande : {commandText}");
                          Console.WriteLine(ex.Message);
                      }
                  }
              }
  
              Console.WriteLine($"Base '{dbFile}' créée avec succès !");*/