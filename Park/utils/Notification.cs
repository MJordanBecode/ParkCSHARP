
using Spectre.Console;
using System;
using System.Threading.Tasks;

namespace Park.utils;
public class NotificationSystem
{
    public static async Task ShowNotification(string message, string color = "green", int durationMs = 3000)
    {
        var panel = new Panel(new Markup($"[{color}]{message}[/]"))
            .Border(BoxBorder.Double)
            .BorderStyle(Style.Parse(color))
            .Padding(1, 1)
            .Header("[bold]Notification[/]", Justify.Center);

        AnsiConsole.Live(panel)
            .Start(ctx =>
            {
                ctx.Refresh();
                Thread.Sleep(durationMs);
            });
    }
}
