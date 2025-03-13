// Console template
using System;

namespace GameOfLife
{
    class Program
    {
        static void Main()
        {
            // Here is your empty program!
            Console.Clear();

            Grid grid = new Grid();
            grid.PopulateGrid();
            Random random = new Random();
            
            foreach (Cell cell in grid.GetGrid()) {
                bool randomBool = random.Next(0,2) == 1;
                if (randomBool) {
                    grid.SetAliveCell(cell.GetX(), cell.GetY(), true);
                }
            }

            while (true) {
                Console.Clear();
                grid.DisplayGrid();
                grid.DoGridUpdate();
                Console.ReadKey();
                
            }
        }
    }
}

