using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _8_Puzzle_Agent
{
    public partial class Form1 : Form
    {
        Agent1 agent;
        int[,] array;
        public Form1()
        {
            InitializeComponent();
            this.InitializeArray();
            agent = new Agent1(array);
            UpdateLabel();
            this.SetListener();

            this.MaximizeBox = false;
            this.Text = "8 Puzzle Agent";
        }

        private void SetListener()
        {
            button1.Click += new EventHandler(button1_click);
            button2.Click += new EventHandler(button2_click);
            //this.KeyPress += new KeyPressEventHandler(key_pressed);
        }
        private void button2_click(object sender, EventArgs e)
        {
            agent.NextMove();
            this.UpdateLabel();
        }

        private void button1_click(object sender, EventArgs e)
        {
            //Randomize.RandomizeArray(array);
            Randomize.EasyRandomArray(array);
            this.UpdateLabel();
            if (isSolveable(array) == false)
                Console.WriteLine("Not Solvable");
            else
                Console.WriteLine("Solvable");
        }

        private void InitializeArray()
        {
            array = new int[3, 3] {{1,2,3},{4,5,6},{7,8,0}

            }; 
        }

        internal  void UpdateLabel()
        {
            if (array[0, 0] == 0)
                label1.Text = "  ";
            else
                label1.Text = array[0, 0].ToString();

            if (array[0, 1] == 0)
                label2.Text = "  ";
            else
                label2.Text = array[0, 1].ToString();

            if (array[0, 2] == 0)
                label3.Text = "  ";
            else
                label3.Text = array[0, 2].ToString();

            if (array[1, 0] == 0)
                label4.Text = "  ";
            else
                label4.Text = array[1, 0].ToString();

            if (array[1, 1] == 0)
                label5.Text = "  ";
            else
                label5.Text = array[1, 1].ToString();

            if (array[1, 2] == 0)
                label6.Text = "  ";
            else
                label6.Text = array[1, 2].ToString();

            if (array[2, 0] == 0)
                label7.Text = "  ";
            else
                label7.Text = array[2, 0].ToString();

            if (array[2, 1] == 0)
                label8.Text = "  ";
            else
                label8.Text = array[2, 1].ToString();

            if (array[2, 2] == 0)
                label9.Text = "  ";
            else
                label9.Text = array[2, 2].ToString();

        }


        int GetInvCount(int[] arr)
        {
            int inv_count = 0;
            for (int i = 0; i < arr.Length - 1; i++)
                for (int j = i + 1; j < arr.Length; j++)
                    if (arr[i] > arr[j])
                        inv_count++;
            return inv_count;
        }
        public bool isSolveable(int[,] arr)
        {
            int count = 0;
            int[] flatArray = new int[8];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (arr[i, j] == 0)
                        continue;
                    else
                    {
                        flatArray[count++] = arr[i, j];
                    }
                }
            }

            if (this.GetInvCount(flatArray) % 2 == 0)
                return true;
            else
                return false;
        }


    }
}
