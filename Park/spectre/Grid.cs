using Spectre.Console;
using System;
using System.Collections.Generic;
using Spectre.Console;

namespace Park.spectre
{
    public static class Gridpark
    {
        private static string[,] grid;
        private static int width = 10;   // ajuster selon la taille réelle de ta grille
        private static int height = 10;
    
        public static void Initialize(int w, int h)
        {
            width = w;
            height = h;
            grid = new string[width, height];
        }
    
        public static void SetCellContent(int x, int y, string content)
        {
            if (x >= 0 && x < width && y >= 0 && y < height)
            {
                grid[x, y] = content;
            }
        }
    
        public static void ShowGrid()
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Console.Write(grid[x, y] ?? ".");
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
    }

}
