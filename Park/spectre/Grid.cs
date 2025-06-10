using Spectre.Console;
using System;
using System.Collections.Generic;
using Spectre.Console;

namespace Park.spectre
{
    public class Gridpark
    {
        // Grille pour stocker l'état des cases
        private static string[,] grid = new string[5, 5];

        // Initialisation de la grille
        static Gridpark()
        {
            for (int row = 0; row < 5; row++)
            {
                for (int col = 0; col < 5; col++)
                {
                    grid[row, col] = ":green_square:";
                }
            }
        }

        // Affichage de la grille
        public static void ShowGrid()
        {
            var table = new Table();

            // Ajout de la première colonne
            table.AddColumn("X/Y").ShowRowSeparators().Border(TableBorder.Rounded);

            // Ajout des colonnes supplémentaires
            for (int i = 0; i < 5; i++)
            {
                table.AddColumn($"{i + 1}").ShowRowSeparators().Border(TableBorder.Rounded);
            }

            // Ajout des lignes à la table
            for (int row = 0; row < 5; row++)
            {
                var cells = new List<string> { (row + 1).ToString() };

                for (int col = 0; col < 5; col++)
                {
                    cells.Add(grid[row, col]);
                }

                table.AddRow(cells.ToArray()).ShowRowSeparators().Border(TableBorder.Rounded);
            }

            // Affichage de la table
            AnsiConsole.Write(table);
        }

        // Récupération du contenu d'une case
        public static string GetCellContent(int x, int y)
        {
            // Vérification des limites
            if (x < 1 || x > 5 || y < 1 || y > 5)
            {
                throw new ArgumentOutOfRangeException("Coordonnées invalides.");
            }

            return grid[x - 1, y - 1];
        }

        // Mise à jour du contenu d'une case
        public static void SetCellContent(int x, int y, string content)
        {
            // Vérification des limites
            if (x < 1 || x > 5 || y < 1 || y > 5)
            {
                throw new ArgumentOutOfRangeException("Coordonnées invalides.");
            }

            grid[x - 1, y - 1] = content;
        }
    }
}
