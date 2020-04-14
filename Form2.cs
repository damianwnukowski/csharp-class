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
                textBox3.Text = "Liczby wejściowe muszą być we właściwym formacie i nie mogą być puste!";
                return;
            }

            double n;
            try
            {
                n = problemSolver.calculateZad2(z);
            }
            catch (TimeoutException ex)
            {
                textBox3.Text = "Przekroczono czas oczekiwania na wyniki, spróbuj łatwiejszych do obliczenia danych wejściowych";
                return;
            }
            textBox3.Text = String.Format("Szukane n to {0}", n);
        }
    }
}
