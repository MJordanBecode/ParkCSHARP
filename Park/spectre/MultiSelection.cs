using Park.Menu.MainMenus;
using Spectre.Console;
using Park.spectre;
using Park.DB;
using Park.utils;
using System.Globalization; // Already there, but good to keep for TryParse

namespace Park.spectre;

public class MultiSelection
{
    private int _i;
    public int i { get => _i; set => _i = value; }

    public static void Show()
    {
        string dbPath = "./DB/park.sqlite"; // ou le chemin vers ta base
        DatabaseManager dbManager = new DatabaseManager(dbPath);
        List<Attraction> attractions = dbManager.LireAttractions();

        // Create a dictionary to easily map formatted string to Attraction object
        var attractionChoices = new Dictionary<string, Attraction>();
        foreach (var attraction in attractions)
        {
            string formattedString = $"🎢  {attraction.Name_attraction}\n" +
                                     $"    🧩  Niveau      : {attraction.Level_attraction}\n" +
                                     $"    😊  Bonheur     : {attraction.Happiness_attraction}\n" +
                                     $"    💰  Prix        : {attraction.Price_attraction} 💲";
            attractionChoices.Add(formattedString, attraction);
        }

        List<string> displayChoices = attractionChoices.Keys.ToList();
        displayChoices.Add("🔙 Retour au menu principal");
        displayChoices.Add("❌ Quitter");

        var coasterChoice = AnsiConsole.Prompt(
        new MultiSelectionPrompt<string>()
            .Title("Which [green]Coaster(s)[/] would you like to buy ?")
            .NotRequired()
            .PageSize(8)
            .HighlightStyle(new Style(foreground: Color.Green1))
            .MoreChoicesText("[blue](Move up and down to reveal more choices)[/]")
            .InstructionsText("[grey](Press [blue]<space>[/] to toggle a choice, " +
                              "[green]<enter>[/] to accept)[/]")
            .AddChoices(displayChoices));

        if (coasterChoice.Count == 0)
        {
            throw new Exception("No coaster selected");
        }
        else
        {
            AnsiConsole.MarkupLine("[bold yellow]🎟️  Vous avez sélectionné les attractions suivantes :[/]\n");

            // Change totalCost to int
            int totalCost = 0;
            int index = 1;
            string id_attraction = "";
            foreach (var choice in coasterChoice)
            {
                // Check if the choice is an actual attraction
                if (attractionChoices.TryGetValue(choice, out Attraction? selectedAttraction))
                {
                    AnsiConsole.MarkupLine($"[green]{index}.[/] {choice} ");

                    // Try to parse the price string to an integer
                    if (int.TryParse(selectedAttraction.Price_attraction, NumberStyles.Any, CultureInfo.InvariantCulture, out int attractionPrice))
                    {
                        totalCost += attractionPrice; // Add the parsed integer price to the total
                        id_attraction = selectedAttraction.Id_attraction;
                        Console.WriteLine("l'id de l'attraction : "+id_attraction);
                    }
                    else
                    {
                        // Handle cases where the price string is not a valid number
                        AnsiConsole.MarkupLine($"[red]Warning: Could not parse price for '{selectedAttraction.Name_attraction}'. Price might be invalid or not an integer: {selectedAttraction.Price_attraction}[/]");
                    }

                    index++;
                }
            }

            AnsiConsole.MarkupLine($"\n[bold yellow]Coût total de votre sélection : {totalCost} 💲[/]\n attraction_id = {id_attraction}");
            
            
            AnsiConsole.MarkupLine("[italic grey]Merci pour votre sélection ![/]\n");

            Money money = new Money();
            money.decreaseMoney(totalCost); // This should now correctly accept an int
            dbManager.updateInventory(id_attraction); //insertion du manège dans l'inventaire
        }

        // Handle "Retour au menu principal" and "Quitter" selections
        foreach (var choice in coasterChoice)
        {
            switch (choice)
            {
                case "🔙 Retour au menu principal":
                    Console.Clear();
                    MainMenu.Show();
                    break;
                case "❌ Quitter":
                    Environment.Exit(0);
                    break;
                default:
                    // This case will be for the actual attractions, which are already handled
                    break;
            }
        }

        ReturnMainMenu.ReturnMainmenu();
    }
}