using Spectre.Console;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
namespace Park.Menu.MainMenu;

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
    }
}