namespace GameOfLife;

/*

This really doesnt need to exist, but it does because I can and thats fun

*/
class Editor
{

    private static void WriteError(string errorText, int pos) {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("[!] ");
        Console.ResetColor();
        Console.Write("Position " + (pos+1) + ": " + errorText + "\n");
    }

    public static bool InterpretConstructionString(string constructionString, Grid grid) {
        /* Bracket coordinates of where you want cells to appear.
        (x,y)(x,y)
        */
        bool inBrackets = false;
        int currentCoordinate = 0; // 0 if x, 1 if y

        int storeX = 0;
        int storeY = 0;

        int stringPos = 0;
        for (int i=0; i < constructionString.Length;i++) {
            char chr = constructionString[i];
            switch (chr) {
                case '(':
                    if (inBrackets) {
                        WriteError("Already in coordinate definition, cannot declare another coordinate.",i);
                        return true;
                    }
                    inBrackets = true;
                    break;
                case ')':
                    if (!inBrackets) {
                        WriteError("Cannot end non-existant coordinate definition.",i);
                        return true;
                    }
                    inBrackets = false;
                    currentCoordinate = 0;
                    grid.SetAliveCell(storeX, storeY, true);
                    break;
                case ',':
                    if (!inBrackets) {
                        WriteError("Not in coordinate definition.",i);
                        return true;
                    }
                    if (currentCoordinate > 1) {
                        WriteError("Comma inserted when there are already coordinates defined.",i);
                        return true;
                    }
                    currentCoordinate++;
                    break;
                
                default:
                    if (int.TryParse(chr.ToString(), out _)) {

                        if (!inBrackets) {
                            WriteError("Unknown Integer.",i);
                            return true;
                        }


                        string currentNumberStr = "";
                        // character is the start of an integer, get the coords
                        while (int.TryParse(constructionString[i].ToString(), out _)) {
                            currentNumberStr += constructionString[i];
                            i++;
                        }
                        i--;

                        if (currentCoordinate == 0) {
                            storeX = int.Parse(currentNumberStr);
                        } else {
                            storeY = int.Parse(currentNumberStr);
                        }
                    }  else {
                        WriteError("Unknown character",i);
                        return true;
                    }
                    break;
            }
            stringPos++; 
        }
        return false;
    }
}