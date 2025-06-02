using Spectre.Console;

namespace Park.spectre;

public class Header
{
    public static void Show()
    {
        AnsiConsole.Write(
            new FigletText("Amusement Park")
                .LeftJustified()
                .Color(Color.Green3));
    }
}