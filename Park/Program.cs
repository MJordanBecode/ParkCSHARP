using Park;
using Park.spectre;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Park.Menu.MainMenus;
using Park.utils;
using Park.DB;
using Microsoft.Data.Sqlite;
using Park.Menu;


namespace Park
{
    public class Program
    {
        public static void Main(string[] args) //si async, devoir mettre " Task " à la place de void
        {
            // Faire en sorte de mettre async tout le code ! chaque get, post etc 
              StartMenu.Show(); // Start menu of the program
             
             string dbPath = "./DB/park.sqlite"; // ou le chemin vers ta base
                    DatabaseManager db = new DatabaseManager(dbPath);
                    db.Connect();
                    // db.DisplayBank(); => display l'argent 
                    Console.WriteLine("Gestion de l'argent ici : ");
                    Money money = new Money();
                    Console.WriteLine("Argent de base :");
                    db.DisplayBank(); 
                    Console.WriteLine("Capital après retrait :  ");
                    Console.WriteLine(money.decreaseMoney(509));
                    // Console.WriteLine("Capital après ajout :  ");
                    // Console.WriteLine(money.increaseMoney(5000));
                    // db.LireAttractions();
                    // db.SearchOneAttraction("Auto Tamponeuse");
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