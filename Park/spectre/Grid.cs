using Spectre.Console;
namespace Park.spectre;

public class Gridpark
{
    public static void ShowGrid()
    {
        var table = new Table();

// Colonne "X/Y"
        table.AddColumn("X/Y").ShowRowSeparators().Border(TableBorder.Rounded);

// Colonnes 1 à 5
        for (int i = 0; i < 5; i++)
        {
            table.AddColumn($"{i + 1}").ShowRowSeparators().Border(TableBorder.Rounded);
        }

// Lignes avec identifiant en 1re colonne
        for (int row = 1; row <= 5; row++) // de 1 à 5
        {
            var cells = new List<string>();

            // Première colonne : numéro de ligne
            cells.Add(row.ToString());

            // 5 colonnes restantes : carrés verts
            for (int col = 0; col < 5; col++)
            {
                cells.Add(":green_square:");
            }

            table.AddRow(cells.ToArray()).ShowRowSeparators().Border(TableBorder.Rounded);
        }

// Affichage dans le terminal
        AnsiConsole.Write(table);
    }
}