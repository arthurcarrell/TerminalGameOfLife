namespace GameOfLife;

public class Grid
{

    /* VARIABLES */
    private int WIDTH = 20;
    private int HEIGHT = 20;
    private Cell[,] cellGrid;

    /* GETTERS */
    public Cell[,] GetGrid() { return cellGrid; }
    public int GetWidth() { return WIDTH; }
    public int GetHeight() { return HEIGHT; }

    /* METHODS */
    private void DisplayCell(Cell cell) {
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
    private bool IsInBounds(int coordinate, int limit) {
        if (coordinate < 0) { return false; }
        if (coordinate > limit) { return false; }
        
        return true;
    } 
    public int GetNeighborAmount(Cell cell) {
        int amountOfNeighbors = 0;

        for (int y=0; y < 3; y++) {
            for (int x=0; x < 3; x++) {

                bool isAllowed = true;

                if (isAllowed) { isAllowed = IsInBounds(x, WIDTH); }
                if (isAllowed) { isAllowed = IsInBounds(y, HEIGHT); }

                if (isAllowed) {
                    // check if its alive
                    if (cellGrid[x-1,y-1].GetAlive()) {
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
