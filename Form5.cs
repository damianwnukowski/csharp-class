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
    public partial class Form5 : Form
    {

        private ProblemSolver problemSolver = new ProblemSolver();

        public Form5()
        {
            InitializeComponent();
        }

        private void Calculate_Click(object sender, EventArgs e)
        {
            textBox3.Text = String.Format("Obliczam...");
            int k;
            try
            {
                k = Convert.ToInt32(textBox5.Text);
            }
            catch
            {
                textBox3.Text = "Liczby muszą być we właściwym formacie!";
                return;
            }

            List<double> xsRect = problemSolver.calculateZad5(k, Model.AreaType.Rectangle);
            List<double> xsTrapezoid = problemSolver.calculateZad5(k, Model.AreaType.Trapezoid);

            textBox3.Text = String.Format("Dla podanego K i metody prostokątów otrzymano: x1: {0}, x2: {1}, x3: {2}, x4: {3}", xsRect[0], xsRect[1], xsRect[2], xsRect[3]);
            textBox3.Text += Environment.NewLine;
            textBox3.Text += String.Format("Dla podanego K i metody trapezów otrzymano: x1: {0}, x2: {1}, x3: {2}, x4: {3}", xsTrapezoid[0], xsTrapezoid[1], xsTrapezoid[2], xsTrapezoid[3]);

        }
    }
}
