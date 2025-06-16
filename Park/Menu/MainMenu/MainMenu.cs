using Spectre.Console;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Park.Menu.showInventory;
using Park.DB;
using Park.spectre;

namespace Park.Menu.MainMenus;

public class MainMenu
{
    public static void Show()
    {
        var choice = AnsiConsole.Prompt(
        new SelectionPrompt<string>()
            .Title("[white]What do [green]you[/] want to do?[/]")
            .PageSize(20)
            .HighlightStyle(new Style(foreground: Color.Blue1))
            .AddChoices(new[] {
            "Statistics", "Show my park", "See my inventory",
            "Buy a new coaster", "Add on grid", "Remove on grid", "Exit",

            }));


        AnsiConsole.MarkupLine($"[white]You have chosen [red]{choice}[/].[/]");

        switch (choice)
        {
            case "Statistics":
                // Appeler une méthode pour afficher les statistiques
                // DisplayStatistics();
                break;
            case "Show my park":
                Gridpark.Initialize(10, 10);  // ou la taille de ta grille réelle
                Gridpark.ShowGrid();
                break;
            case "See my inventory":
                // Appeler une méthode pour voir l'inventaire
                ShowInventory displayInventory = new ShowInventory();
                displayInventory.DisplayInventory();
                break;
            case "Buy a new coaster":
                // Appeler une méthode pour acheter un nouveau coaster
                MultiSelection.Show(); // Assuming this method handles the coaster selection
                // BuyNewCoaster();
                break;
            case "Add on grid":

                break;
            case "Remove on grid":
                // Appeler une méthode pour retirer de la grille
                // RemoveFromGrid();
                break;
            case "Exit":
                // Sortir de l'application ou retourner au menu précédent
                // ExitApplication();
                break;
        }
    }
}