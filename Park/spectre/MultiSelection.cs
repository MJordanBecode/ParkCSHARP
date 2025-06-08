using Park.Menu.MainMenu;
using Spectre.Console;
using Park.DB;

namespace Park.spectre;

public class MultiSelection
{
    
    private int _i;
    public int i {get => _i; set => _i = value;} 
    
    public static void Show()
    {
        int i = 0;
        int max = 2;

         string dbPath = "./DB/park.sqlite"; // ou le chemin vers ta base
         DatabaseManager dbManager = new DatabaseManager(dbPath);
         List<Attraction> attractions = dbManager.LireAttractions();
        
        List<string> coasterChoiceName = attractions.Select(a => a.Name_attraction).ToList();

        
        var coasterChoice = AnsiConsole.Prompt(
        new MultiSelectionPrompt<string>()
            .Title("Which [green]Coaster(s)[/] would you like to buy ?")
            .NotRequired()
            .PageSize(8)
            .MoreChoicesText("[blue](Move up and down to reveal more choices)[/]")
            .InstructionsText("[grey](Press [blue]<space>[/] to toggle a choicesSelection, " + 
                              "[green]<enter>[/] to accept)[/]")
             .AddChoices(coasterChoiceName));
            
        
        if (coasterChoice.Count == 0)
        {
            throw new Exception("No coaster selected");
        }
        else
        {
            // Display the selected choices
            AnsiConsole.MarkupLine($"You selected: [green]{string.Join(", ", coasterChoice)}[/]");
            // Visitor.ShowNumberOfVisitor()
        }
        // Display the selected choices
        foreach (var choice in coasterChoice)
        {
            switch (choice)
            {
                case "Auto Tamponeuse":
                    break;
                
                
                case "Return to Main Menu":
                    // Clear the terminal
                    Console.Clear();

                    // Call to the Main Menu
                    MainMenu.Show();

                    break; // 

                case "Exit":
                    Environment.Exit(0);
                    break;

                default:
                    break;
            }
        }

        ReturnMainMenu.ReturnMainmenu();


    }
    

}