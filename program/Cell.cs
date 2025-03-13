namespace GameOfLife;

public class Cell 
{
    /* VARIABLES */
    private bool isAlive = false;
    private int x;
    private int y;
    
    /* GETTERS */
    public bool GetAlive() { return isAlive; }
    public int GetX() { return x; }
    public int GetY() { return y; }

    /* SETTERS */
    public void SetAlive(bool setAlive) { isAlive = setAlive; }

    /* CONSTRUCTOR */
    public Cell(int setX, int setY) {
        x = setX;
        y = setY;
    } 
}
