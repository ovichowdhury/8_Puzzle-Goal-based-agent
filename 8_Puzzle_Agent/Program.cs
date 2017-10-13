using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _8_Puzzle_Agent
{
    static class Program
    {
        internal static Form1 mainForm;

        
        static void Main()
        {
            mainForm = new Form1();
            Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(mainForm);
            
        }
    }
}
