using Spectre.Console;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Park.spectre;
using Park.Menu.MainMenus;
using Park.Menu;

namespace Park.Menu;

public class StartMenu
{
    public static void Show()
    {
        bool showMainMenu = false;

        while (!showMainMenu)
        {
            Console.Clear();

            Header.ShowWithColor(Color.Red3);


            // Instructions
            AnsiConsole.MarkupLine("[bold yellow]Bienvenue dans votre parc d'attractions ![/]");
            AnsiConsole.WriteLine();
            AnsiConsole.MarkupLine("[white]Appuyez sur [green]ENTER[/] pour commencer[/]");
            AnsiConsole.MarkupLine("[white]Appuyez sur [red]ESPACE[/] pour quitter[/]");

            // Lecture de la touche
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            switch (keyInfo.Key)
            {
                case ConsoleKey.Enter:
                    showMainMenu = true;
                    Console.Clear();
                    Header.ShowWithColor(Color.Green3);
                    MainMenu.Show();


                    break;

                case ConsoleKey.Spacebar:
                    AnsiConsole.MarkupLine("\n[red]Au revoir ![/]");
                    Environment.Exit(0);
                    break;
            }
        }

        // Votre menu principal existant
        // Console.Clear();


    }
}
