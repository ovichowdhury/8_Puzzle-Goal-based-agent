using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_Puzzle_Agent
{
    class Agent1
    {
        // int one, two;
        int[,] state1;
        int[,] state2;
        int[,] state3;
        int[,] state4;
        int[,] previousState;
        int[,] formArray;
        int[,] desiredState;


        public Agent1(int[,] array)
        {
            formArray = array;
            state1 = new int[3, 3];
            state2 = new int[3, 3];
            state3 = new int[3, 3];
            state4 = new int[3, 3];
            previousState = new int[3, 3];

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    previousState[i, j] = array[i, j];
                }
            }

            desiredState = new int[3, 3] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 0 } };
        }


        private int distance;

        private int Calculate(int curX, int curY, int goalX, int goalY)
        {
            return Math.Abs(goalX - curX) + Math.Abs(goalY - curY);
        }
        private int GetManhattanDistance(int[,] arr)
        {
            distance = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    switch (arr[i, j])
                    {
                        case 1:
                            distance = distance + this.Calculate(i, j, 0, 0);
                            break;
                        case 2:
                            distance = distance + this.Calculate(i, j, 0, 1);
                            break;
                        case 3:
                            distance = distance + this.Calculate(i, j, 0, 2);
                            break;
                        case 4:
                            distance = distance + this.Calculate(i, j, 1, 0);
                            break;
                        case 5:
                            distance = distance + this.Calculate(i, j, 1, 1);
                            break;
                        case 6:
                            distance = distance + this.Calculate(i, j, 1, 2);
                            break;
                        case 7:
                            distance = distance + this.Calculate(i, j, 2, 0);
                            break;
                        case 8:
                            distance = distance + this.Calculate(i, j, 2, 1);
                            break;
                    }
                }
            }
            return distance;
        }


        private bool Equal(int[,] arr1, int[,] arr2)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (arr1[i, j] == arr2[i, j])
                        continue;
                    else
                        return false;
                }
            }
            return true;
        }
        private int GetMissMatched(int[,] arr1, int[,] arr2)
        {
            int count = 0;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (arr1[i, j] == arr2[i, j] || arr1[i, j] == 0)
                        continue;
                    else
                        count++;
                }
            }

            return count;
        }

        /*public void RunSolution()
        {
            while(!formArray.Equals(desiredState))
            {
                this.NextMove();
                
                //Program.mainForm.UpdateLabel();
                
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        previousState[i, j] = formArray[i, j];
                    }
                }
                //Task.Delay(1000);
            }
        }*/

        public void Display()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(formArray[i, j] + "  ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public int NextMove()
        {
            if (Equal(formArray, desiredState) == true)
            {
                Console.WriteLine("Solved");
                return 1;
            }
            else
            {
                int row, col;
                this.TrackZero(out row, out col);

                if (row == 0 && col == 0)
                    this.MoveFor00();
                else if (row == 0 && col == 1)
                    this.MoveFor01();
                else if (row == 0 && col == 2)
                    this.MoveFor02();
                else if (row == 1 && col == 0)
                    this.MoveFor10();
                else if (row == 1 && col == 1)
                    this.MoveFor11();
                else if (row == 1 && col == 2)
                    this.MoveFor12();
                else if (row == 2 && col == 0)
                    this.MoveFor20();
                else if (row == 2 && col == 1)
                    this.MoveFor21();
                else if (row == 2 && col == 2)
                    this.MoveFor22();
            }
            return 0;

        }

        private void ModifyPreviousState()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    previousState[i, j] = formArray[i, j];
                }
            }
        }

        private void MoveFor11()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    state1[i, j] = formArray[i, j];
                }
            }
            state1[1, 1] = state1[0, 1];
            state1[0, 1] = 0;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    state2[i, j] = formArray[i, j];
                }
            }
            state2[1, 1] = state2[1, 0];
            state2[1, 0] = 0;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    state3[i, j] = formArray[i, j];
                }
            }
            state3[1, 1] = state3[1, 2];
            state3[1, 2] = 0;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    state4[i, j] = formArray[i, j];
                }
            }
            state4[1, 1] = state4[2, 1];
            state4[2, 1] = 0;

            int one = this.GetMissMatched(state1, desiredState) + this.GetManhattanDistance(state1);
            int two = this.GetMissMatched(state2, desiredState) + this.GetManhattanDistance(state2);
            int three = this.GetMissMatched(state3, desiredState) + this.GetManhattanDistance(state3);
            int four = this.GetMissMatched(state4, desiredState) + this.GetManhattanDistance(state4);

            if (Equal(state1, previousState) == true)
                one = 100;
            else if (Equal(state2, previousState) == true)
                two = 100;
            else if (Equal(state3, previousState) == true)
                three = 100;
            else if (Equal(state4, previousState) == true)
                four = 100;

            int min = GetMin(new int[4] { one, two, three, four });

            Console.WriteLine(one + " " + two + " " + three + " " + four + " " + min);

            if (min == one)
                this.AssingState1();
            else if (min == two)
                this.AssingState2();
            else if (min == three)
                this.AssingState3();
            else if (min == four)
                this.AssingState4();
        }

        private void MoveFor21()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    state1[i, j] = formArray[i, j];
                }
            }
            state1[2, 1] = state1[1, 1];
            state1[1, 1] = 0;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    state2[i, j] = formArray[i, j];
                }
            }
            state2[2, 1] = state2[2, 0];
            state2[2, 0] = 0;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    state3[i, j] = formArray[i, j];
                }
            }
            state3[2, 1] = state3[2, 2];
            state3[2, 2] = 0;

            int one = this.GetMissMatched(state1, desiredState) + this.GetManhattanDistance(state1);
            int two = this.GetMissMatched(state2, desiredState) + this.GetManhattanDistance(state2);
            int three = this.GetMissMatched(state3, desiredState) + this.GetManhattanDistance(state3);

            if (Equal(state1, previousState) == true)
                one = 100;
            else if (Equal(state2, previousState) == true)
                two = 100;
            else if (Equal(state3, previousState) == true)
                three = 100;

            int min = GetMin(new int[3] { one, two, three });

            Console.WriteLine(one + " " + two + " " + three + " " + min);

            if (min == one)
                this.AssingState1();
            else if (min == two)
                this.AssingState2();
            else if (min == three)
                this.AssingState3();

        }

        private void MoveFor12()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    state1[i, j] = formArray[i, j];
                }
            }
            state1[1, 2] = state1[0, 2];
            state1[0, 2] = 0;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    state2[i, j] = formArray[i, j];
                }
            }
            state2[1, 2] = state2[1, 1];
            state2[1, 1] = 0;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    state3[i, j] = formArray[i, j];
                }
            }
            state3[1, 2] = state3[2, 2];
            state3[2, 2] = 0;

            int one = this.GetMissMatched(state1, desiredState) + this.GetManhattanDistance(state1);
            int two = this.GetMissMatched(state2, desiredState) + this.GetManhattanDistance(state2);
            int three = this.GetMissMatched(state3, desiredState) + this.GetManhattanDistance(state3);

            if (Equal(state1, previousState) == true)
                one = 100;
            else if (Equal(state2, previousState) == true)
                two = 100;
            else if (Equal(state3, previousState) == true)
                three = 100;

            int min = GetMin(new int[3] { one, two, three });

            Console.WriteLine(one + " " + two + " " + three + " " + min);

            if (min == one)
                this.AssingState1();
            else if (min == two)
                this.AssingState2();
            else if (min == three)
                this.AssingState3();
        }

        private void MoveFor10()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    state1[i, j] = formArray[i, j];
                }
            }
            state1[1, 0] = state1[0, 0];
            state1[0, 0] = 0;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    state2[i, j] = formArray[i, j];
                }
            }
            state2[1, 0] = state2[1, 1];
            state2[1, 1] = 0;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    state3[i, j] = formArray[i, j];
                }
            }
            state3[1, 0] = state3[2, 0];
            state3[2, 0] = 0;

            int one = this.GetMissMatched(state1, desiredState) + this.GetManhattanDistance(state1);
            int two = this.GetMissMatched(state2, desiredState) + this.GetManhattanDistance(state2);
            int three = this.GetMissMatched(state3, desiredState) + this.GetManhattanDistance(state3);

            if (Equal(state1, previousState) == true)
                one = 100;
            else if (Equal(state2, previousState) == true)
                two = 100;
            else if (Equal(state3, previousState) == true)
                three = 100;

            int min = GetMin(new int[3] { one, two, three });

            Console.WriteLine(one + " " + two + " " + three + " " + min);

            if (min == one)
                this.AssingState1();
            else if (min == two)
                this.AssingState2();
            else if (min == three)
                this.AssingState3();

        }

        private void MoveFor01()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    state1[i, j] = formArray[i, j];
                }
            }
            state1[0, 1] = state1[0, 0];
            state1[0, 0] = 0;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    state2[i, j] = formArray[i, j];
                }
            }
            state2[0, 1] = state2[0, 2];
            state2[0, 2] = 0;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    state3[i, j] = formArray[i, j];
                }
            }
            state3[0, 1] = state3[1, 1];
            state3[1, 1] = 0;

            int one = this.GetMissMatched(state1, desiredState) + this.GetManhattanDistance(state1);
            int two = this.GetMissMatched(state2, desiredState) + this.GetManhattanDistance(state2);
            int three = this.GetMissMatched(state3, desiredState) + this.GetManhattanDistance(state3);

            if (Equal(state1, previousState) == true)
                one = 100;
            else if (Equal(state2, previousState) == true)
                two = 100;
            else if (Equal(state3, previousState) == true)
                three = 100;

            int min = GetMin(new int[3] { one, two, three });

            Console.WriteLine(one + " " + two + " " + three + " " + min);

            if (min == one)
                this.AssingState1();
            else if (min == two)
                this.AssingState2();
            else if (min == three)
                this.AssingState3();
        }

        private void MoveFor22()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    state1[i, j] = formArray[i, j];
                }
            }
            state1[2, 2] = state1[1, 2];
            state1[1, 2] = 0;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    state2[i, j] = formArray[i, j];
                }
            }
            state2[2, 2] = state2[2, 1];
            state2[2, 1] = 0;

            int one = this.GetMissMatched(state1, desiredState) + this.GetManhattanDistance(state1);
            int two = this.GetMissMatched(state2, desiredState) + this.GetManhattanDistance(state2);

            Console.WriteLine(one + " " + two);

            if (Equal(state1, previousState) == true)
                one = 100;
            else if (Equal(state2, previousState) == true)
                two = 100;

            Console.WriteLine(one + " " + two);

            if (one < two)
                this.AssingState1();
            else
                this.AssingState2();


        }

        private void MoveFor20()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    state1[i, j] = formArray[i, j];
                }
            }
            state1[2, 0] = state1[1, 0];
            state1[1, 0] = 0;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    state2[i, j] = formArray[i, j];
                }
            }
            state2[2, 0] = state2[2, 1];
            state2[2, 1] = 0;

            int one = this.GetMissMatched(state1, desiredState) + this.GetManhattanDistance(state1);
            int two = this.GetMissMatched(state2, desiredState) + this.GetManhattanDistance(state2);

            if (Equal(state1, previousState) == true)
                one = 100;
            else if (Equal(state2, previousState) == true)
                two = 100;

            Console.WriteLine(one + " " + two);

            if (one < two)
                this.AssingState1();
            else
                this.AssingState2();

        }

        private void MoveFor02()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    state1[i, j] = formArray[i, j];
                }
            }
            state1[0, 2] = state1[0, 1];
            state1[0, 1] = 0;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    state2[i, j] = formArray[i, j];
                }
            }
            state2[0, 2] = state2[1, 2];
            state2[1, 2] = 0;

            int one = this.GetMissMatched(state1, desiredState) + this.GetManhattanDistance(state1);
            int two = this.GetMissMatched(state2, desiredState) + this.GetManhattanDistance(state2);

            if (Equal(state1, previousState) == true)
                one = 100;
            else if (Equal(state2, previousState) == true)
                two = 100;

            Console.WriteLine(one + " " + two);

            if (one < two)
                this.AssingState1();
            else
                this.AssingState2();

        }

        private void MoveFor00()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    state1[i, j] = formArray[i, j];
                }
            }
            state1[0, 0] = state1[0, 1];
            state1[0, 1] = 0;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    state2[i, j] = formArray[i, j];
                }
            }
            state2[0, 0] = state2[1, 0];
            state2[1, 0] = 0;

            int one = this.GetMissMatched(state1, desiredState) + this.GetManhattanDistance(state1);
            int two = this.GetMissMatched(state2, desiredState) + this.GetManhattanDistance(state2);

            if (Equal(state1, previousState) == true)
                one = 100;
            else if (Equal(state2, previousState) == true)
                two = 100;

            Console.WriteLine(one + " " + two);

            if (one < two)
                this.AssingState1();
            else
                this.AssingState2();

        }

        private void AssingState1()
        {
            this.ModifyPreviousState();

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    formArray[i, j] = state1[i, j];
                }
            }
        }

        private void AssingState2()
        {
            this.ModifyPreviousState();

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    formArray[i, j] = state2[i, j];
                }
            }
        }

        private void AssingState3()
        {
            this.ModifyPreviousState();

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    formArray[i, j] = state3[i, j];
                }
            }
        }

        private void AssingState4()
        {
            this.ModifyPreviousState();

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    formArray[i, j] = state4[i, j];
                }
            }
        }

        private void TrackZero(out int row, out int col)
        {
            row = 0; col = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (formArray[i, j] == 0)
                    {
                        row = i;
                        col = j;
                        goto end;
                    }
                }
            }
        end:
            return;
        }

        public void InsertionSort(int[] arr)
        {
            int i, j, key;
            for (j = 1; j < arr.Length; j++)
            {
                key = arr[j];
                i = j - 1;
                while (i >= 0 && arr[i] > key)
                {
                    arr[i + 1] = arr[i];
                    i--;
                    arr[i + 1] = key;
                }
            }
        }

        private int GetMin(int[] arr)
        {
            this.InsertionSort(arr);
            return arr[0];
        }



    }
}
 