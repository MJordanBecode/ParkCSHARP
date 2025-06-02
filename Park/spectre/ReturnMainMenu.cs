using Spectre.Console;
namespace Park.spectre;

public class ReturnMainMenu
{
    public static void ReturnMainmenu()
    {
        while (true)
        {
            // Affiche un petit menu ou un message
            AnsiConsole.MarkupLine("Press any key to return to the Main menu");
            

            // Lecture de l'entrée
            var key = Console.ReadKey(true);

            if (key.Key == ConsoleKey.D1)
            {
                Console.Clear();
                MultiSelection.Show();
                Thread.Sleep(1000);
                AnsiConsole.MarkupLine("Terminé. Appuyez sur une touche pour revenir.");

                Console.ReadKey(true); // Attend qu'une touche soit pressée
            }
        }
    }
}