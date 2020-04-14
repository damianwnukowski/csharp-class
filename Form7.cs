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
    public partial class Form7 : Form
    {
        private ProblemSolver problemSolver = new ProblemSolver();

        public Form7()
        {
            InitializeComponent();
        }

        private void Calculate_Click(object sender, EventArgs e)
        {
            textBox3.Text = String.Format("Obliczam...");
            double x1;
            double x2;
            int z;
            
            try
            {
                x1 = Convert.ToDouble(textBox1.Text);
                x2 = Convert.ToDouble(textBox2.Text);
                z = Convert.ToInt32(textBox5.Text);
            }
            catch
            {
                textBox3.Text = "Liczby wejściowe muszą być we właściwym formacie i nie mogą być puste!";
                return;
            }

            int forRect;
            int forTrapez;

            try
            {
                forRect = problemSolver.calculateZad7(x1, x2, z, Model.AreaType.Rectangle);
                forTrapez = problemSolver.calculateZad7(x1, x2, z, Model.AreaType.Trapezoid);
            }
            catch (TimeoutException ex)
            {
                textBox3.Text = "Przekroczono czas oczekiwania na wyniki, spróbuj łatwiejszych do obliczenia danych wejściowych";
                return;
            }

            textBox3.Text = String.Format("(METODA PROSTOKĄTÓW) Dla podanego x1, x2 i Z  znaleziono N={0}", forRect);
            textBox3.Text += Environment.NewLine;
            textBox3.Text += String.Format("(METODA TRAPEZÓW) Dla podanego x1, x2 i Z  znaleziono N={0}", forTrapez);

        }
    }
}
