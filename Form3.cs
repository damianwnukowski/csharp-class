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
    public partial class Form3 : Form
    {
        ProblemSolver problemSolver = new ProblemSolver();

        public Form3()
        {
            InitializeComponent();
        }

        private void Calculate_Click(object sender, EventArgs e)
        {
            textBox3.Text = String.Format("Obliczam...");
            double x1;
            double x2;
            try
            {
                x1 = Convert.ToDouble(textBox1.Text);
                x2 = Convert.ToDouble(textBox2.Text);
            }
            catch
            {
                textBox3.Text = "Liczby wejściowe muszą być we właściwym formacie i nie mogą być puste!";
                return;
            }

            double result1;
            double result2;
            try
            {
                result1 = problemSolver.calculateZad3(x1, x2, Model.AreaType.Trapezoid);
                result2 = problemSolver.calculateZad3(x1, x2, Model.AreaType.Rectangle);
            }
            catch (TimeoutException ex)
            {
                textBox3.Text = "Przekroczono czas oczekiwania na wyniki, spróbuj łatwiejszych do obliczenia danych wejściowych";
                return;
            }

            textBox3.Text = String.Format("Błąd średniokwadratowy dla metody trapezów dla podanych x1 i x2 wynosi {0} \n \r", result1);
            textBox3.Text += String.Format("Błąd średniokwadratowy dla metody prostokątów dla podanych x1 i x2 wynosi {0} \n \r", result2);

        }
    }
}
