using System;
using Microsoft.Data.Sqlite;

namespace Park.DB
{
   public class DatabaseManager
   {
       private string _connectionString;
   
       public DatabaseManager(string dbPath)
       {
           _connectionString = $"Data Source={dbPath}";
       }
   
       public void Connect()
       {
           using (var connection = new SqliteConnection(_connectionString))
           {
               try
               {
                   connection.Open();
                   Console.WriteLine("Connexion réussie à la base SQLite !");
               }
               catch (Exception ex)
               {
                   Console.WriteLine($"Erreur de connexion : {ex.Message}");
               }
           }
       }
       
      public void LireAttractions()
      {
          using (var connection = new SqliteConnection(_connectionString))
          {
              connection.Open();
      
              var command = connection.CreateCommand();
              command.CommandText = "SELECT * FROM attraction";
      
              using (var reader = command.ExecuteReader())
              {
                  Console.WriteLine("Liste des attractions :");
      
                  while (reader.Read())
                  {
                      string id_attraction = reader.GetString(0); // Index corrigé ici
                      string name_attraction = reader.GetString(1); // Index corrigé ici
                      string level_attraction = reader.GetString(2); // Index corrigé ici
                      string happiness = reader.GetString(3); // Index corrigé ici
                      string attraction_price = reader.GetString(4); // Index corrigé ici
                      Console.WriteLine($"Attraction : {id_attraction} -   {name_attraction} - lvl : {level_attraction} - {happiness}😍 - {attraction_price} 💲");
                  }
              }
          }
      }
      
       public void SearchOneAttraction(string attraction_name)
       {
           using (var connection = new SqliteConnection(_connectionString))
           {
               connection.Open();
       
               var command = connection.CreateCommand();
               command.CommandText = "SELECT * FROM attraction WHERE name_attraction = @name";
               command.Parameters.AddWithValue("@name", $"{attraction_name}");
       
               using (var reader = command.ExecuteReader())
               {
                   if (reader.Read())
                   {
                       // Lecture de toutes les colonnes
                       int id = reader.GetInt32(0);
                       string name = reader.GetString(1);
                       string level = reader.GetString(2);
                       string happiness = reader.GetString(3);
                       double price = reader.GetDouble(4);
       
                       Console.WriteLine($"Attraction trouvée : ID={id}, Nom={name}, Niveau={level}, Joie={happiness}, Prix={price}€");
                   }
                   else
                   {
                       Console.WriteLine("Attraction non trouvée.");
                   }
               }
           }
       }

 } 
}