using Damian_Wnukowski_zadanie1.Model;
using System;
using System.Text;
using System.Windows.Forms;

namespace Damian_Wnukowski_zadanie1
{
    public partial class Form1 : Form
    {

        private ProblemSolver problemSolver = new ProblemSolver();

        public Form1()
        {
            InitializeComponent();
        }

        private void Calculate_Click(object sender, EventArgs e)
        {
            textBox3.Text = String.Format("Obliczam...");
            int m;
            double z;
            try
            {
                m = Convert.ToInt32(textBox1.Text);
                z = Convert.ToDouble(textBox2.Text);
            } catch
            {
                textBox3.Text = "Liczby wejściowe muszą być we właściwym formacie i nie mogą być puste!";
                return;
            }

            textBox3.Text = String.Format("Wyniki dla M={0} i Z={1}", m, z);
            Global global = null;
            try
            {
                global = problemSolver.calculateZad1(m, z);
            } catch (TimeoutException ex)
            {
                textBox3.Text = "Przekroczono czas oczekiwania na wyniki, spróbuj łatwiejszych do obliczenia danych wejściowych";
                return;
            }
            var stringBuilder = new StringBuilder();
            foreach (var singleCount in global.ListOfSingleCount)
            {
                stringBuilder.AppendLine(String.Format("AreaType: {0} Area: {1}", singleCount.AreaType, singleCount.Area)); 
            }

            textBox3.Text = stringBuilder.ToString();
        }
    }
}
