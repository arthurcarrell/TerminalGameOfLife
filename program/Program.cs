// Console template
using System;
using System.Drawing;
using System.Threading.Channels;

namespace GameOfLife
{
    class Program
    {

        static void Main()
        {
            // Here is your empty program!
            Console.Clear();

            Grid grid = new Grid();
            Editor editor = new Editor();
            grid.PopulateGrid();
            Random random = new Random();
            
            Console.WriteLine("Editor? (y/n)");
            bool shouldBuildLife = Console.ReadLine()?.ToLower() == "y";
            
            if (!shouldBuildLife) {
                foreach (Cell cell in grid.GetGrid()) {
                    bool randomBool = random.Next(0,2) == 1;
                    if (randomBool) {
                        grid.SetAliveCell(cell.GetX(), cell.GetY(), true);
                    }
                }
            } else {
                Console.WriteLine("Enter construction string:");
                string? constructionString = Console.ReadLine();
                if (constructionString != null) {
                    bool hasErrored = Editor.InterpretConstructionString(constructionString, grid);
                    if (hasErrored) {
                        return;
                    }
                }
            }

            // inital:
            Console.Clear();
            grid.DisplayGrid();
            Console.ReadLine();

            // loop:
            while (true) {
                Console.Clear();
                grid.DisplayGrid();
                grid.DoGridUpdate();
                //Thread.Sleep(500);
                Console.ReadLine();
            }
        }
    }
}

