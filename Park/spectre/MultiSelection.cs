using Park.Menu.MainMenu;
using Spectre.Console;

namespace Park.spectre;

public class MultiSelection
{
    public static void Show()
    {
        var coasterChoice = AnsiConsole.Prompt(
        new MultiSelectionPrompt<string>()
            .Title("Which [green]Coaster(s)[/] would you like to buy ?")
            .NotRequired()
            .PageSize(8)
            .MoreChoicesText("[blue](Move up and down to reveal more choices)[/]")
            .InstructionsText("[grey](Press [blue]<space>[/] to toggle a choicesSelection, " + 
                              "[green]<enter>[/] to accept)[/]")
             .AddChoices(new[] {
            "Auto Tamponeuse", "Bateau à Bascule", "Bateau Tamponneur",
            "Bowling", "Carrousel", "Chaises Volantes",
            "Chamboule Tout", "Grande Roue", "HighStriker",
            "Machine à Piece","Manege Gyroscopique","Mongol Fière",
            "Montagnes Russes","Pedalo Cygne","StandTir",
            "Tasses Tournantes","Test De Force","Train Mignature",
            "Return to Main Menu", "Exit"
        }));
            
        
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