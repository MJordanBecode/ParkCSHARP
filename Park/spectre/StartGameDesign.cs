using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Park.spectre
{
    public class StartGameDesign
    {
        private static bool stopTitleAnimation = false;

        public static void Show()
        {
            // Clear screen
            AnsiConsole.Clear();

            // Lancer l'animation du titre dans une Task parallèle
            var titleTask = Task.Run(() => AnimateTitle());

            // Texte tapé lentement (effet "machine à écrire")
            WriteSlow("\n[green]Initialisation du système Roller Coaster...[/]");
            Thread.Sleep(500);

            // Animation de chargement
            AnsiConsole.Status()
                .Spinner(Spinner.Known.Star)
                .SpinnerStyle(Style.Parse("yellow"))
                .Start("Démarrage de Parky Fun...", ctx =>
                {
                    Thread.Sleep(4000);
                    ctx.Status("[green]Chargement des Images...[/]");
                    Thread.Sleep(6000);
                    ctx.Status("[magenta]Chargement des Attractions...[/]");
                    Thread.Sleep(2000);
                    ctx.Status("[blue]Chargement du Shop..[/]");
                    Thread.Sleep(2000);
                    ctx.Status("[blue]Chargement de l'Inventaire..[/]");
                    Thread.Sleep(2000);
                    ctx.Status("[purple]Connexion au réseau Attraction...[/]");
                    Thread.Sleep(2000);
                    ctx.Status("[green]Système prêt ![/]");
                    Thread.Sleep(800);
                });

            // Stoppe l’animation du titre
            stopTitleAnimation = true;
            titleTask.Wait(); // Attend que le thread s'arrête

            // Affichage final
            AnsiConsole.Clear();
            AnsiConsole.Write(
                new FigletText("Parky Fun")
                    .Centered()
                    .Color(Color.Green));

            AnsiConsole.MarkupLine("\n[bold green]🚀 Lancement de la partie en cours...[/]");
            Thread.Sleep(1500);
            AnsiConsole.MarkupLine("[italic grey]Appuyez sur une touche pour commencer...[/]");
            Console.ReadKey(true);
        }

        static void AnimateTitle()
        {
            var colors = new[]
            {
                Color.Fuchsia, Color.Magenta1, Color.Purple,
                Color.HotPink, Color.GreenYellow, Color.OrangeRed1,
                Color.Aquamarine3, Color.Red1
            };

            int i = 0;
            while (!stopTitleAnimation)
            {
                var color = colors[i % colors.Length];
                AnsiConsole.Clear();
                AnsiConsole.Write(
                    new FigletText("Parky Fun")
                        .Centered()
                        .Color(color));
                Thread.Sleep(150);
                i++;
            }
        }

        static void WriteSlow(string message, int delay = 50)
        {
            bool isMarkup = false;

            foreach (char c in message)
            {
                if (c == '[') isMarkup = true;
                Console.Write(c);
                if (c == ']') isMarkup = false;

                if (!isMarkup) Thread.Sleep(delay);
            }
            Console.WriteLine();
        }
    }
}
