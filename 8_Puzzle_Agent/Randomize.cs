using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_Puzzle_Agent
{
    class Randomize
    {
        public static void EasyRandomArray(int[,] array)
        {
            int[,] arr = new int[3, 3] { { 3, 7, 1 }, { 4, 5, 6 }, { 2, 0, 8 } };

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    array[i, j] = arr[i, j];
                }
            }

        }
        public static void RandomizeArray(int [,] array)
        {
            int row, col;
            Random rand = new Random();

            for(int i=0; i<3; i++)
            {
                for(int j=0; j<3; j++)
                {
                    row = rand.Next() % 3;
                    col = rand.Next() % 3;
                    int temp = array[i,j];
                    array[i,j] = array[row,col];
                    array[row,col] = temp;
                }
            }
        
        }
    }
}
