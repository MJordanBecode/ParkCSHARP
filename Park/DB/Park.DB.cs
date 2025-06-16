using System;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;
using Microsoft.Data.Sqlite;
using Park.spectre;

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
    int quantity = 1;

    using (var connection = new SqliteConnection(_connectionString))
    {
        try
        {
            connection.Open();

            // Vérifie si l'attraction est déjà dans l'inventaire
            var checkCommand = connection.CreateCommand();
            checkCommand.CommandText = "SELECT quantity FROM inventaire WHERE id_attraction = @id_attraction";
            checkCommand.Parameters.AddWithValue("@id_attraction", id_attraction);

            using (var reader = checkCommand.ExecuteReader())
            {
                if (reader.Read())
                {
                    // Attraction existe déjà => mettre à jour le quantity
                    int currentQuantity = reader.GetInt32(0);
                    reader.Close(); // Fermer le reader avant d’exécuter une autre commande sur la même connexion

                    var updateCommand = connection.CreateCommand();
                    updateCommand.CommandText = "UPDATE inventaire SET quantity = @newQuantity WHERE id_attraction = @id_attraction";
                    updateCommand.Parameters.AddWithValue("@newQuantity", currentQuantity + 1);
                    updateCommand.Parameters.AddWithValue("@id_attraction", id_attraction);
                    updateCommand.ExecuteNonQuery();

                    Console.WriteLine($"[yellow]L'attraction '{id_attraction}' existait déjà. Quantité mise à jour à {currentQuantity + 1}.[/]");
                }
                else
                {
                    // Nouvelle attraction => insérer
                    reader.Close(); // bonne pratique au cas où

                    var insertCommand = connection.CreateCommand();
                    insertCommand.CommandText = "INSERT INTO inventaire (id_attraction, quantity) VALUES (@id_attraction, @quantity)";
                    insertCommand.Parameters.AddWithValue("@id_attraction", id_attraction);
                    insertCommand.Parameters.AddWithValue("@quantity", quantity);
                    insertCommand.ExecuteNonQuery();

                    Console.WriteLine($"[green]Attraction '{id_attraction}' ajoutée à l'inventaire avec quantité = {quantity}.[/]");
                }
            }
        }
        catch (SqliteException ex)
        {
            Console.WriteLine($"[red]Erreur SQLite : {ex.Message}[/]");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[red]Erreur générale : {ex.Message}[/]");
        }
    }
}

public void getInventory()
{
    using (var connection = new SqliteConnection(_connectionString))
    {
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = @"
            SELECT 
                i.id_attraction, 
                i.id_item, 
                i.quantity, 
                a.name_attraction,
                a.level_attraction,
                h.happiness,
                p.visitor_price
            FROM inventaire i
            JOIN attraction a ON i.id_attraction = a.id_attraction
            JOIN happiness h ON a.happiness = h.happiness
            JOIN price p ON a.attraction_price = p.attraction_price";

        using (var reader = command.ExecuteReader())
        {
            if (!reader.HasRows)
            {
                AnsiConsole.MarkupLine("[yellow]🔍 Aucun élément trouvé dans l'inventaire.[/]");
                return;
            }

            var table = new Table();
            table.Border = TableBorder.Rounded;
            table.Title("[bold green]📦 Inventaire complet[/]");

            table.AddColumn("[blue]* ID Attraction[/]");
            table.AddColumn("[cyan]* Nom[/]");
            table.AddColumn("[purple]* ID Inventaire[/]");
            table.AddColumn("[green]* Quantité[/]");
            table.AddColumn("[orange1]* Niveau[/]");
            table.AddColumn("[yellow]* Bonheur[/]");


            while (reader.Read())
            {
                string id = reader.GetString(0);
                int idInventaire = reader.GetInt32(1);
                int quantity = reader.GetInt32(2);
                string name = reader.GetString(3);
                int level = reader.GetInt32(4);
                int happiness = reader.GetInt32(5);
    

                table.AddRow(
                    $"[blue]{id}[/]",
                    $"[cyan]{name}[/]",
                    $"[purple]{idInventaire}[/]",
                    $"[green]{quantity}[/]",
                    $"[orange1]{level}[/]",
                    $"[yellow]{happiness}[/]" 
                    
                );
            }

            AnsiConsole.Write(table);
        }
    }
}

public void LoadGridToMemory()
{
    using (var connection = new SqliteConnection(_connectionString))
    {
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = @"
            SELECT g.position_x, g.position_y, a.name_attraction
            FROM grid g
            JOIN inventaire i ON g.id_item = i.id_item
            JOIN attraction a ON i.id_attraction = a.id_attraction";

        using (var reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                int x = reader.GetInt32(0);
                int y = reader.GetInt32(1);
                string name = reader.GetString(2);

                // Remplace par un emoji personnalisé ou une abréviation si besoin
                Gridpark.SetCellContent(x, y, $":roller_coaster:"); 
            }
        }
    }
}





 } 
}