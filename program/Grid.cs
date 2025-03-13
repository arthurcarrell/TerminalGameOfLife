namespace GameOfLife;

public class Grid
{

    /* VARIABLES */
    private int WIDTH = 50;
    private int HEIGHT = 30;
    private Cell[,] cellGrid;

    /* GETTERS */
    public Cell[,] GetGrid() { return cellGrid; }
    public int GetWidth() { return WIDTH; }
    public int GetHeight() { return HEIGHT; }

    /* METHODS */
    private static void DisplayCell(Cell cell) {
        if (cell.GetAlive()) {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("■");
            Console.ResetColor();
        } else {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write(".");
            Console.ResetColor();
        }
    }
    private bool IsInBounds(int x, int y) {
        //Console.WriteLine($"x: {x}, y: {y}");
        if (x < 0 || y < 0) {
            return false;
        } 

        if (x >= WIDTH || y >= HEIGHT) {
            return false;
        }

        return true;
    } 
    public int GetNeighborAmount(Cell cell) {
        int amountOfNeighbors = 0;

        for (int y=0; y < 3; y++) {
            for (int x=0; x < 3; x++) {

                bool isAllowed = IsInBounds(cell.GetX()+x-1, cell.GetY()+y-1);

                if (isAllowed) {
                    // check if its alive
                    if (cellGrid[cell.GetX()+x-1,cell.GetY()+y-1].GetAlive()) {
                        amountOfNeighbors++;
                    }
                }
    
            }
        }

        return amountOfNeighbors;
    }

    public void UpdateCell(Cell cell) {
        int neighborAmount = GetNeighborAmount(cell);

        // do live cell stuff
        if (cell.GetAlive()) {

            // <2 neighbors
            if (neighborAmount < 2) {
                cell.SetAlive(false);
            }

            // >3 neighbors
            if (neighborAmount > 3) {
                cell.SetAlive(false);
            }

        } else {
            // do dead cell stuff
            if (neighborAmount == 3) {
                cell.SetAlive(true);
            }
        }
    }
    public void DisplayGrid() {

        for (int y=0; y < HEIGHT;y++) {
            for (int x=0; x < WIDTH;x++) {
                DisplayCell(cellGrid[x,y]);
            }
            Console.Write("\n");
        }
    }

    public void DoGridUpdate() {
        for (int y=0; y < HEIGHT;y++) {
            for (int x=0; x < WIDTH;x++) {
                UpdateCell(cellGrid[x,y]);
            }
        }
    }



    public void PopulateGrid() {
        
        for (int y=0; y < HEIGHT;y++) {
            for (int x=0; x < WIDTH;x++) {
                cellGrid[x,y] = new Cell(x, y);
            }
        }
    }

    public void SetAliveCell(int x, int y, bool alive) {
        cellGrid[x,y].SetAlive(alive);
    }
    /* CONSTRUCTOR */
    public Grid() {
        cellGrid = new Cell[WIDTH, HEIGHT];
    }

}
