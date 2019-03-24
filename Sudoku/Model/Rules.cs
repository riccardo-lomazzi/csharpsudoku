using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Model
{
    class Rules
    {
        //checks that an array has duplicates by copying all data into a Hashmap (that avoides duplicates automatically) and compparing the sizes
        public static bool ArrayHasDuplicates(int[] arr)
        {
            HashSet<int> temp = new HashSet<int>();
            for (int i = 0; i < arr.Length; i++)
            {
                temp.Add(arr[i]);
            }
            return (temp.Count < arr.Length) ? true : false;
        }

        //checks that a matrix has no duplicates values
        public static bool MatrixHasDuplicates(int[][] mat, int startingRow, int finalRow, int startingColumn, int finalColumn)
        {
            HashSet<int> temp = new HashSet<int>();
            int matSize = ((finalRow - startingRow) + 1) * ((finalColumn - startingColumn) + 1);
            for (int i = startingRow; i < finalRow; i++)
            {
                for (int j = startingColumn; j < finalColumn; j++)
                {
                    temp.Add(mat[i][j]);
                }
            }
            return (temp.Count < matSize) ? true : false;
        }

        //checks that the game grid has no duplicates in rows, columns, and subgrids
        public static bool IsSudokuValid(int[][] mat, int rows, int columns)
        {
            //rows check
            for (int i = 0; i < rows; i++)
                if (ArrayHasDuplicates(mat[i]))
                    return false;
            //columns check
            int[] column = new int[rows];
            for (int i = 0; i < columns; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    column[j] = mat[j][i];
                }
                if (ArrayHasDuplicates(column))
                    return false;
            }
            //subgrids check
            int region_size = 3; //number of subgrids per row / column
            for (int i = 0; i < region_size; ++i)
            {
                for (int j = 0; j < region_size; ++j)
                {
                    if (MatrixHasDuplicates(mat, region_size * i, region_size * (i + 1), region_size * j, region_size * (j + 1)))
                        return false;
                }
            }
            return true;
        }
    }
}
