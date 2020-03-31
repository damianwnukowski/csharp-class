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
                textBox3.Text = "Podaj wartości M(liczba powtórzeń) i Z (ilość procent). Liczby muszą być we właściwym formacie!";
                return;
            }

            textBox3.Text = String.Format("Wyniki dla M={0} i Z={1}", m, z);

            var global = problemSolver.calculateZad1(m, z);
            var stringBuilder = new StringBuilder();
            foreach (var singleCount in global.ListOfSingleCount)
            {
                stringBuilder.AppendLine(String.Format("AreaType: {0} Area: {1}", singleCount.AreaType, singleCount.Area)); 
            }

            textBox3.Text = stringBuilder.ToString();
        }
    }
}
