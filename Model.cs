using System;
using System.Collections.Generic;

namespace Damian_Wnukowski_zadanie1.Model
{
    public enum AreaType
    {
        Rectangle,
        Trapezoid
    }

    public class SingleCount
    {
        public double X1 { get; set; }
        public double X2 { get; set; }
        public int N { get; set; }
        public AreaType? AreaType { get ; set; }
        public double Area { get; set; }
        public int CalculationNumber { get; set; }
        public int LowestN { get; set; }
        public double MinSquareError { get; set; }

        public SingleCount(double x1, double x2, int n, AreaType areaType, Func<double, double> function)
        {
            this.X1 = x1;
            this.X2 = x2;
            this.N = n;
            this.AreaType = areaType;
            switch (areaType)
            {
                case Model.AreaType.Rectangle:
                    Area = calculateForRectangle(x1, x2, n, function);
                    break;
                case Model.AreaType.Trapezoid:
                    Area = calcualteForTrapezoid(x1, x2, n, function);
                    break;
                default:
                    throw new Exception("Constructor can't handle this area type");
            }
        }

        public SingleCount(double x1, double x2, int n, AreaType? areaType, int indexOfFunction)
        {
            this.X1 = x1;
            this.X2 = x2;
            this.N = n;
            this.AreaType = areaType;
            switch (areaType)
            {
                case Model.AreaType.Rectangle:
                    Area = calculateForRectangle(x1, x2, n, (lambdaParam) => Math.Pow(lambdaParam, indexOfFunction));
                    break;
                case Model.AreaType.Trapezoid:
                    Area = calcualteForTrapezoid(x1, x2, n, (lambdaParam) => Math.Pow(lambdaParam, indexOfFunction));
                    break;
                default:
                    Area = calculate(x1, x2, indexOfFunction);
                    break;
            }
        }

        private double calculate(double x1, double x2, int indexOfFunction)
        {
            double result = 1.0d / (indexOfFunction + 1) * Math.Pow(x2, indexOfFunction + 1);
            result -= 1.0d / (indexOfFunction + 1) * Math.Pow(x1, indexOfFunction + 1);
            return result;
        }

        private double calcualteForTrapezoid(double x1, double x2, int n, Func<double, double> func)
        {
            double result = 0;
            double height = (x2 - x1) / n;
            double fx1 = 0;
            double fx2 = 0;
            for (int i =0; i < n; i++)
            {
                fx1 = fx2;
                fx2 = func((x2 - x1) / n * (i + 1));
                result += (fx1 + fx2) * height / 2;
            }

            return result;
        }

        private double calculateForRectangle(double x1, double x2, int n, Func<double, double> func)
        {
            double result = 0;
            double height = (x2 - x1) / n;

            double fx1 = 0;
            for (int i = 0; i < n; i++)
            {
                
                fx1 = func((x2 - x1) / n * (i + 1));
                Console.Write("fx1 dla x=" + ((x2 - x1) / n * (i + 1)) + "wynosi:  " + fx1);
                result += fx1 * height;
            }

            return result;
        }
    }

    public class Global
    {

        public List<SingleCount> ListOfSingleCount { get; set; }
        public Global(List<SingleCount> list)
        {
            this.ListOfSingleCount = list;
        }
    }
}
