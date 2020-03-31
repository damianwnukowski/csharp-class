using Damian_Wnukowski_zadanie1.Model;
using System;
using System.Text;
using System.Windows.Forms;

namespace Damian_Wnukowski_zadanie1
{
    public partial class Form2 : Form
    {

        private ProblemSolver problemSolver = new ProblemSolver();

        public Form2()
        {
            InitializeComponent();
        }

        private void Calculate_Click(object sender, EventArgs e)
        {
            textBox3.Text = String.Format("Obliczam...");
            double z;
            try
            {
                z = Convert.ToDouble(textBox2.Text);
            }
            catch
            {
                textBox3.Text = "Podaj wartości Z (ilość procent). Liczby muszą być we właściwym formacie!";
                return;
            }

            textBox3.Text = String.Format("Wyniki dla Z={0}",z);

            var n = problemSolver.calculateZad2(z);
            textBox3.Text = String.Format("Szukane n to {0}", n);
        }
    }
}
