using Park.Menu.MainMenu;
using Spectre.Console;
namespace Park.spectre;

public class ReturnMainMenu
{
    public static void ReturnMainmenu()
    {
        // Affiche un message
        AnsiConsole.MarkupLine("[yellow]Press any key to return to the Main menu...[/]");

        // Attend une touche (n'importe laquelle)
        Console.ReadKey(true);
        
        // Efface l'écran ou effectue une action
        Console.Clear();
        
        // Ici, tu peux rappeler ton menu principal, par exemple :
        MainMenu.Show(); 
    }
}