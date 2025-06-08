using System;
using Microsoft.Data.Sqlite;

namespace Park.DB
{
    public class Attraction
    {
        public string Id_attraction { get; set; }
        public string Name_attraction { get; set; }
        public string Level_attraction { get; set; }
        public string Happiness_attraction { get; set; }
        public string Price_attraction { get; set; }
    }
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
       
      public List<Attraction> LireAttractions()
      {
          var attractions = new List<Attraction>();
      
          using (var connection = new SqliteConnection(_connectionString))
          {
              connection.Open();
      
              var command = connection.CreateCommand();
              command.CommandText = "SELECT * FROM attraction";
      
              using (var reader = command.ExecuteReader())
              {
                  while (reader.Read())
                  {
                      var attraction = new Attraction
                      {
                          Id_attraction = reader.GetString(0),
                          Name_attraction = reader.GetString(1),
                          Level_attraction = reader.GetString(2),
                          Happiness_attraction = reader.GetString(3),
                          Price_attraction = reader.GetString(4)
                      };
      
                      attractions.Add(attraction);
                  }
              }
          }
      
          // ✅ Affichage une seule fois après la lecture
          foreach (var attraction in attractions)
          {
              Console.WriteLine($"Attraction : {attraction.Id_attraction} - {attraction.Name_attraction} - lvl : {attraction.Level_attraction} - {attraction.Happiness_attraction} - {attraction.Price_attraction} ");
          }
      
          return attractions;
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