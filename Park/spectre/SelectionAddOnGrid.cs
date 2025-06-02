using Spectre.Console;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Park.spectre;
namespace Park.Menu.MainMenu;

public class SelectionAddOnGrid
{
    public static void Show()
    {
        var choiceAdd = AnsiConsole.Prompt(
        new SelectionPrompt<string>()
            .Title("[white]What do [green]you[/] want to do?[/]")
            .PageSize(20)
            .HighlightStyle(new Style(foreground: Color.Green1))
            .AddChoices(new[] {
            "Exit",//foreach de inventaire pas placer

            }));


        AnsiConsole.MarkupLine($"[white]You have chosen [red]{choiceAdd}[/].[/]");

        switch (choiceAdd)
        {
            case "":
                // Appeler une méthode pour afficher les statistiques
                // DisplayStatistics();
                break;

            case "Exit":
                // Sortir de l'application ou retourner au menu précédent
                // ExitApplication();
                break;
        }
    }
}