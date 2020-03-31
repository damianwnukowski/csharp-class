using Damian_Wnukowski_zadanie1.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Damian_Wnukowski_zadanie1
{
    public partial class Form6 : Form
    {
        private ProblemSolver problemSolver = new ProblemSolver();

        public Form6()
        {
            InitializeComponent();
        }

        private void Calculate_Click(object sender, EventArgs e)
        {
            textBox3.Text = String.Format("Obliczam...");
            int k;
            int m;
            try
            {
                k = Convert.ToInt32(textBox1.Text);
                m = Convert.ToInt32(textBox5.Text);
            }
            catch
            {
                textBox3.Text = "Liczby muszą być we właściwym formacie!";
                return;
            }

            Global forRect = problemSolver.calculateZad6(k, m, Model.AreaType.Rectangle);
            Global forTrapez= problemSolver.calculateZad6(k, m, Model.AreaType.Trapezoid);

            textBox3.Text = String.Format("(METODA PROSTOKĄTÓW) Dla podanego K i M  znaleziono przedział dla x^2: ({0}, {1}) , dla x^3: ({2}, {3}), różnica pomiędzy ich całkami wynosi: {4} ", 
                forRect.ListOfSingleCount[0].X1, forRect.ListOfSingleCount[0].X2, forRect.ListOfSingleCount[1].X1, forRect.ListOfSingleCount[1].X2, 
                Math.Abs(forRect.ListOfSingleCount[0].Area - forRect.ListOfSingleCount[1].Area));
            textBox3.Text += Environment.NewLine;
            textBox3.Text += String.Format("(METODA TRAPEZÓW) Dla podanego K i M  znaleziono przedział dla x^2: ({0}, {1}) , dla x^3: ({2}, {3}), różnica pomiędzy ich całkami wynosi: {4} ",
               forTrapez.ListOfSingleCount[0].X1, forTrapez.ListOfSingleCount[0].X2, forTrapez.ListOfSingleCount[1].X1, forTrapez.ListOfSingleCount[1].X2,
               Math.Abs(forTrapez.ListOfSingleCount[0].Area - forTrapez.ListOfSingleCount[1].Area));
        }
    }
}
