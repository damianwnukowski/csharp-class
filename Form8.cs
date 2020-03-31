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
    public partial class Form8 : Form
    {
        private ProblemSolver problemSolver = new ProblemSolver();

        public Form8()
        {
            InitializeComponent();
        }

        private void Calculate_Click(object sender, EventArgs e)
        {
            textBox3.Text = String.Format("Obliczam...");
            double z;

            try
            {
                z = Convert.ToDouble(textBox1.Text);
            }
            catch
            {
                textBox3.Text = "Liczby muszą być we właściwym formacie!";
                return;
            }

            int forRect = problemSolver.calculateZad8(z, Model.AreaType.Rectangle);
            int forTrapez = problemSolver.calculateZad8(z, Model.AreaType.Trapezoid);

            textBox3.Text = String.Format("(METODA PROSTOKĄTÓW) Dla podanego Z  znaleziono N={0}", forRect);
            textBox3.Text += Environment.NewLine;
            textBox3.Text += String.Format("(METODA TRAPEZÓW) Dla podanego Z  znaleziono N={0}", forTrapez);

        }
    }
}
