namespace ChessBoardConsoleApp
{
    class Program
    {
        static Board myBoard = new Board(8);
        static void Main(string[] args)
        {
            //Show empty chessboard
            printGrid(myBoard);

            //get location of chess piece
            Cell myLocation = setCurrentCell();

            //get user input on which piece to move
            string piece = "";
            Console.WriteLine("Which piece would you like to move");
            piece = Console.ReadLine();

            //calculate & mark cells where legal moves are possible
            myBoard.MarkNextLegalMoves(myLocation, "Knight");

            //show chessboard and use "." for empty square, "X" for piece location
            //"+" for possible legal move
            printGrid(myBoard);

            //wait for another return key to exit program
            Console.ReadLine();
        }

        static public void printGrid(Board board)
        {
            for (int i = 0; i < board.Size; i++)
            {
                string row = "";
                for (int j = 0; j < board.Size; j++)
                {
                    if (board.theGrid[i, j].CurrentlyOccupied)
                        row += "X ";
                    else if (board.theGrid[i, j].LegalNextMove)
                        row += "+ ";
                    else
                        row += ". ";
                }
                Console.WriteLine(row);
            }
            Console.WriteLine("=================================");
        }


        static public Cell setCurrentCell()
        {
            Console.WriteLine("Enter your current row number ");
            int currentRow = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter your current column number ");
            int currentCol = int.Parse(Console.ReadLine());

            while(currentRow > myBoard.Size || currentCol > myBoard.Size || myBoard.theGrid[currentRow, currentCol].CurrentlyOccupied)
            {
                setCurrentCell();
            }
            
            myBoard.theGrid[currentRow, currentCol].CurrentlyOccupied = true;
            return myBoard.theGrid[currentRow, currentCol];
        }
    }
}