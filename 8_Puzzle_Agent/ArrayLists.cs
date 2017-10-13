using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_Puzzle_Agent
{
    class ArrayLists
    {
        int counter;
        int[][,] jaggedArray;

        public ArrayLists()
        {
            counter = 0;
            jaggedArray = new int[100][,];
        }

        public void Add(int[,] arr)
        {
            jaggedArray[counter] = new int[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    jaggedArray[counter][i, j] = arr[i, j];
                }
            }

            counter++;
        }

        public int[,] Get(int index)
        {
            return jaggedArray[index];
        }

        public int GetCounter()
        {
            return counter;
        }
    }
}
