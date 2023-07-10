using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBoardConsoleApp;

public class Board
{
    public int Size { get; set; }
    public Cell[,] theGrid { get; set; }

    public Board(int size)
    {
        Size = size;
        theGrid = new Cell[size, size];
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                theGrid[i, j] = new Cell(i, j);
            }
        }
    }

    public void MarkNextLegalMoves(Cell currentCell, string chessPiece)
    {
        for (int i = 0; i < Size; i++)
        {
            for (int j = 0; j < Size; j++)
            {
                theGrid[i, j].LegalNextMove = false;
                theGrid[i, j].CurrentlyOccupied = false;
            }
        }

        if (currentCell.RowNumber >= 0 && currentCell.RowNumber < Size && currentCell.ColumnNumber >= 0 && currentCell.ColumnNumber < Size)
        {
            theGrid[currentCell.RowNumber, currentCell.ColumnNumber].CurrentlyOccupied = true;

            switch (chessPiece)
            {
                case "Knight":
                    if (currentCell.RowNumber - 2 >= 0 && currentCell.RowNumber - 2 < Size && currentCell.ColumnNumber - 1 >= 0 && currentCell.ColumnNumber - 1 < Size)
                        theGrid[currentCell.RowNumber - 2, currentCell.ColumnNumber - 1].LegalNextMove = true;
                    if (currentCell.RowNumber - 2 >= 0 && currentCell.RowNumber - 2 < Size && currentCell.ColumnNumber + 1 >= 0 && currentCell.ColumnNumber + 1 < Size)
                        theGrid[currentCell.RowNumber - 2, currentCell.ColumnNumber + 1].LegalNextMove = true;
                    if (currentCell.RowNumber - 1 >= 0 && currentCell.RowNumber - 1 < Size && currentCell.ColumnNumber + 2 >= 0 && currentCell.ColumnNumber + 2 < Size)
                        theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber + 2].LegalNextMove = true;
                    if (currentCell.RowNumber + 1 >= 0 && currentCell.RowNumber + 1 < Size && currentCell.ColumnNumber + 2 >= 0 && currentCell.ColumnNumber + 2 < Size)
                        theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber + 2].LegalNextMove = true;
                    if (currentCell.RowNumber + 2 >= 0 && currentCell.RowNumber + 2 < Size && currentCell.ColumnNumber + 1 >= 0 && currentCell.ColumnNumber + 1 < Size)
                        theGrid[currentCell.RowNumber + 2, currentCell.ColumnNumber + 1].LegalNextMove = true;
                    if (currentCell.RowNumber + 2 >= 0 && currentCell.RowNumber + 2 < Size && currentCell.ColumnNumber - 1 >= 0 && currentCell.ColumnNumber - 1 < Size)
                        theGrid[currentCell.RowNumber + 2, currentCell.ColumnNumber - 1].LegalNextMove = true;
                    if (currentCell.RowNumber + 1 >= 0 && currentCell.RowNumber + 1 < Size && currentCell.ColumnNumber - 2 >= 0 && currentCell.ColumnNumber - 2 < Size)
                        theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber - 2].LegalNextMove = true;
                    if (currentCell.RowNumber - 1 >= 0 && currentCell.RowNumber - 1 < Size && currentCell.ColumnNumber - 2 >= 0 && currentCell.ColumnNumber - 2 < Size)
                        theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber - 2].LegalNextMove = true;
                    break;
                case "King":
                    if (currentCell.RowNumber - 1 >= 0 && currentCell.RowNumber - 1 < Size && currentCell.ColumnNumber - 1 >= 0 && currentCell.ColumnNumber - 1 < Size)
                        theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber - 1].LegalNextMove = true;
                    if (currentCell.RowNumber - 1 >= 0 && currentCell.RowNumber - 1 < Size && currentCell.ColumnNumber >= 0 && currentCell.ColumnNumber < Size)
                        theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber].LegalNextMove = true;
                    if (currentCell.RowNumber - 1 >= 0 && currentCell.RowNumber - 1 < Size && currentCell.ColumnNumber + 1 >= 0 && currentCell.ColumnNumber + 1 < Size)
                        theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber + 1].LegalNextMove = true;
                    if (currentCell.RowNumber >= 0 && currentCell.RowNumber < Size && currentCell.ColumnNumber - 1 >= 0 && currentCell.ColumnNumber - 1 < Size)
                        theGrid[currentCell.RowNumber, currentCell.ColumnNumber - 1].LegalNextMove = true;
                    if (currentCell.RowNumber >= 0 && currentCell.RowNumber < Size && currentCell.ColumnNumber + 1 >= 0 && currentCell.ColumnNumber + 1 < Size)
                        theGrid[currentCell.RowNumber, currentCell.ColumnNumber + 1].LegalNextMove = true;
                    if (currentCell.RowNumber + 1 >= 0 && currentCell.RowNumber + 1 < Size && currentCell.ColumnNumber - 1 >= 0 && currentCell.ColumnNumber - 1 < Size)
                        theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber - 1].LegalNextMove = true;
                    if (currentCell.RowNumber + 1 >= 0 && currentCell.RowNumber + 1 < Size && currentCell.ColumnNumber >= 0 && currentCell.ColumnNumber < Size)
                        theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber].LegalNextMove = true;
                    if (currentCell.RowNumber + 1 >= 0 && currentCell.RowNumber + 1 < Size && currentCell.ColumnNumber + 1 >= 0 && currentCell.ColumnNumber + 1 < Size)
                        theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber + 1].LegalNextMove = true;
                    break;
                case "Rook":
                    if (currentCell.RowNumber >= 0 && currentCell.RowNumber < Size && currentCell.ColumnNumber >= 0 && currentCell.ColumnNumber < Size)
                    {
                        theGrid[currentCell.RowNumber, currentCell.ColumnNumber].CurrentlyOccupied = true;

                        // Rook-like moves
                        for (int i = currentCell.RowNumber - 1; i >= 0; i--)
                        {
                            if (!theGrid[i, currentCell.ColumnNumber].CurrentlyOccupied)
                                theGrid[i, currentCell.ColumnNumber].LegalNextMove = true;
                            else
                                break;
                        }

                        for (int i = currentCell.RowNumber + 1; i < Size; i++)
                        {
                            if (!theGrid[i, currentCell.ColumnNumber].CurrentlyOccupied)
                                theGrid[i, currentCell.ColumnNumber].LegalNextMove = true;
                            else
                                break;
                        }

                        for (int j = currentCell.ColumnNumber - 1; j >= 0; j--)
                        {
                            if (!theGrid[currentCell.RowNumber, j].CurrentlyOccupied)
                                theGrid[currentCell.RowNumber, j].LegalNextMove = true;
                            else
                                break;
                        }

                        for (int j = currentCell.ColumnNumber + 1; j < Size; j++)
                        {
                            if (!theGrid[currentCell.RowNumber, j].CurrentlyOccupied)
                                theGrid[currentCell.RowNumber, j].LegalNextMove = true;
                            else
                                break;
                        }
                    }
                    break;

                case "Bishop":
                    if (currentCell.RowNumber >= 0 && currentCell.RowNumber < Size && currentCell.ColumnNumber >= 0 && currentCell.ColumnNumber < Size)
                    {
                        theGrid[currentCell.RowNumber, currentCell.ColumnNumber].CurrentlyOccupied = true;

                        // Bishop-like moves
                        for (int i = currentCell.RowNumber - 1, j = currentCell.ColumnNumber - 1; i >= 0 && j >= 0; i--, j--)
                        {
                            if (!theGrid[i, j].CurrentlyOccupied)
                                theGrid[i, j].LegalNextMove = true;
                            else
                                break;
                        }

                        for (int i = currentCell.RowNumber - 1, j = currentCell.ColumnNumber + 1; i >= 0 && j < Size; i--, j++)
                        {
                            if (!theGrid[i, j].CurrentlyOccupied)
                                theGrid[i, j].LegalNextMove = true;
                            else
                                break;
                        }

                        for (int i = currentCell.RowNumber + 1, j = currentCell.ColumnNumber - 1; i < Size && j >= 0; i++, j--)
                        {
                            if (!theGrid[i, j].CurrentlyOccupied)
                                theGrid[i, j].LegalNextMove = true;
                            else
                                break;
                        }

                        for (int i = currentCell.RowNumber + 1, j = currentCell.ColumnNumber + 1; i < Size && j < Size; i++, j++)
                        {
                            if (!theGrid[i, j].CurrentlyOccupied)
                                theGrid[i, j].LegalNextMove = true;
                            else
                                break;
                        }
                    }
                    break;

                case "Queen":
                    if (currentCell.RowNumber >= 0 && currentCell.RowNumber < Size && currentCell.ColumnNumber >= 0 && currentCell.ColumnNumber < Size)
                    {
                        theGrid[currentCell.RowNumber, currentCell.ColumnNumber].CurrentlyOccupied = true;

                        // Rook-like moves
                        for (int i = currentCell.RowNumber - 1; i >= 0; i--)
                        {
                            if (!theGrid[i, currentCell.ColumnNumber].CurrentlyOccupied)
                                theGrid[i, currentCell.ColumnNumber].LegalNextMove = true;
                            else
                                break;
                        }

                        for (int i = currentCell.RowNumber + 1; i < Size; i++)
                        {
                            if (!theGrid[i, currentCell.ColumnNumber].CurrentlyOccupied)
                                theGrid[i, currentCell.ColumnNumber].LegalNextMove = true;
                            else
                                break;
                        }

                        for (int j = currentCell.ColumnNumber - 1; j >= 0; j--)
                        {
                            if (!theGrid[currentCell.RowNumber, j].CurrentlyOccupied)
                                theGrid[currentCell.RowNumber, j].LegalNextMove = true;
                            else
                                break;
                        }

                        for (int j = currentCell.ColumnNumber + 1; j < Size; j++)
                        {
                            if (!theGrid[currentCell.RowNumber, j].CurrentlyOccupied)
                                theGrid[currentCell.RowNumber, j].LegalNextMove = true;
                            else
                                break;
                        }

                        // Bishop-like moves
                        for (int i = currentCell.RowNumber - 1, j = currentCell.ColumnNumber - 1; i >= 0 && j >= 0; i--, j--)
                        {
                            if (!theGrid[i, j].CurrentlyOccupied)
                                theGrid[i, j].LegalNextMove = true;
                            else
                                break;
                        }

                        for (int i = currentCell.RowNumber - 1, j = currentCell.ColumnNumber + 1; i >= 0 && j < Size; i--, j++)
                        {
                            if (!theGrid[i, j].CurrentlyOccupied)
                                theGrid[i, j].LegalNextMove = true;
                            else
                                break;
                        }

                        for (int i = currentCell.RowNumber + 1, j = currentCell.ColumnNumber - 1; i < Size && j >= 0; i++, j--)
                        {
                            if (!theGrid[i, j].CurrentlyOccupied)
                                theGrid[i, j].LegalNextMove = true;
                            else
                                break;
                        }

                        for (int i = currentCell.RowNumber + 1, j = currentCell.ColumnNumber + 1; i < Size && j < Size; i++, j++)
                        {
                            if (!theGrid[i, j].CurrentlyOccupied)
                                theGrid[i, j].LegalNextMove = true;
                            else
                                break;
                        }
                    }
                    break;

                default:
                    break;
            }
        }
    }
}