using Spectre.Console;

namespace Park.spectre;



public interface IHeader
{
    void Show();
}

public abstract class BasicHeader : IHeader
{
    public abstract void Show();

    protected void ShowWithColor(string title, Color color)
    {
        AnsiConsole.Write(
            new FigletText(title)
                .Centered()
                .Color(color));
    }
}
public class GameHeader : BasicHeader
{
    public override void Show()
    {
        ShowWithColor("The Debugging Madness", Color.Green3);
    }

    public void ShowWithCustomColor(Color color)
    {
        ShowWithColor("The Debugging Madness", color);
    }
}

// Classe statique pour compatibilité avec votre code existant
public static class Header
{
    private static readonly GameHeader _gameHeader = new GameHeader();

    public static void Show()
    {
        _gameHeader.Show();
    }

    public static void ShowWithColor(Color color)
    {
        _gameHeader.ShowWithCustomColor(color);
    }
}








// public static void Show()
//     {

//          AnsiConsole.Write(
//              new FigletText("The Debugging Madness")
//                  .Centered()
//                  .Color(Color.Green3));
//         // Affichage du titre/logo
//         AnsiConsole.Write(
//                 new FigletText("The Debugging Madness")
//                     .Centered()
//                     .Color(Color.Red3));


//     }