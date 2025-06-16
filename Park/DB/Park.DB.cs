using System;
using System.Numerics;
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
      
          // // ✅ Affichage une seule fois après la lecture
          // foreach (var attraction in attractions)
          // {
          //     Console.WriteLine($"Attraction : {attraction.Id_attraction} - {attraction.Name_attraction} - lvl : {attraction.Level_attraction} - {attraction.Happiness_attraction} - {attraction.Price_attraction} ");
          // }
      
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
       
                       // Console.WriteLine($"Attraction trouvée : ID={id}, Nom={name}, Niveau={level}, Joie={happiness}, Prix={price}€");
                   }
                   else
                   {
                       Console.WriteLine("Attraction non trouvée.");
                   }
               }
           }
       }
       
       
              public void DisplayBank()
              {
                  int safeBank = 0;
                  using (var connection = new SqliteConnection(_connectionString))
                  {
                      connection.Open();
              
                      var command = connection.CreateCommand();
                      command.CommandText = "SELECT capital FROM bank";
                      
              
                      using (var reader = command.ExecuteReader())
                      {
                          if (reader.Read())
                          {
                              
                              // lecture de la colonne capital
                              safeBank = reader.GetInt32(0);
                             

                          }
                          else
                          {
                              Console.WriteLine("Error 505");
                          }
                      }
                  }
              }

                            public int GetDataBank()
                            {
                                int safeBank = 0;
                                using (var connection = new SqliteConnection(_connectionString))
                                {
                                    connection.Open();

                                    var command = connection.CreateCommand();
                                    command.CommandText = "SELECT capital FROM bank";


                                    using (var reader = command.ExecuteReader())
                                    {
                                        if (reader.Read())
                                        {

                                            // lecture de la colonne capital
                                            safeBank = reader.GetInt32(0);


                                        }
                                        else
                                        {
                                            Console.WriteLine("Error 505");
                                        }
                                    }
                                }

                                return safeBank;
                            }

                            public void UpdateDataBank(int newCapital)
                            {
                                using (var connection = new SqliteConnection(_connectionString))
                                {
                                    connection.Open();
                                    var command = connection.CreateCommand();
                                    command.CommandText = "UPDATE bank SET capital = @capital";
        
                                    // Paramètre pour éviter l'injection SQL
                                    command.Parameters.AddWithValue("@capital", newCapital);
        
                                    int rowsAffected = command.ExecuteNonQuery();
        
                                    if (rowsAffected == 0)
                                    {
                                        Console.WriteLine("Error: Aucune ligne mise à jour");
                                    }
                                }
                            }

                            public void updateInventory(string id_attraction)
                            {
                                int quantity = 1; // Always inserting with a quantity of 1 for a new entry

                                using (var connection = new SqliteConnection(_connectionString))
                                {
                                    try
                                    {
                                        connection.Open();
                                        var command = connection.CreateCommand();

                                        // Corrected INSERT statement: specify columns and remove trailing parenthesis
                                        command.CommandText = "INSERT INTO inventaire (id_attraction, quantity) VALUES (@id_attraction, @quantity);";
                                        command.Parameters.AddWithValue("@id_attraction", id_attraction);
                                        command.Parameters.AddWithValue("@quantity", quantity);

                                        int rowsAffected = command.ExecuteNonQuery();

                                        if (rowsAffected > 0)
                                        {
                                            Console.WriteLine($"added to inventory.[/]");
                                        }
                                        else
                                        {
                                            Console.WriteLine($"not add to inventory.[/]");
                                        }
                                    }
                                    catch (SqliteException ex)
                                    {
                                        // This catch block is important if id_attraction could be unique,
                                        // or if you hit other database constraints.
                                        Console.WriteLine($"[red]Error adding '{id_attraction}' to inventory: {ex.Message}[/]");
                                        // You might want to log the full exception or handle specific error codes
                                    }
                                }
                            }

 } 
}