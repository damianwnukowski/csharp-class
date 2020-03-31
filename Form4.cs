using System;
using System.Windows.Forms;

namespace Damian_Wnukowski_zadanie1
{
    public partial class Form4 : Form
    {
        private ProblemSolver problemSolver = new ProblemSolver();

        public Form4()
        {
            InitializeComponent();
        }

        private void Calculate_Click(object sender, EventArgs e)
        {
            textBox3.Text = String.Format("Obliczam...");
            double x1;
            double x2;
            double z;
            int k;
            try
            {
                x1 = Convert.ToDouble(textBox1.Text);
                x2 = Convert.ToDouble(textBox2.Text);
                z = Convert.ToDouble(textBox4.Text);
                k = Convert.ToInt32(textBox5.Text);
            }
            catch
            {
                textBox3.Text = "Liczby muszą być we właściwym formacie!";
                return;
            }

            textBox3.Text = String.Format("Dla podanych x1 i x2 całka metodą prostokątów {0} podzielna przez podane Z \n \r", problemSolver.calculateZad4(x1, x2, k, z, Model.AreaType.Rectangle) ? "jest" : "nie jest");
            textBox3.Text += String.Format("Dla podanych x1 i x2 całka metodą trapezów {0} podzielna przez podane Z", problemSolver.calculateZad4(x1, x2, k, z, Model.AreaType.Trapezoid) ? "jest" : "nie jest");

        }
    }
}
