using Damian_Wnukowski_zadanie1.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Damian_Wnukowski_zadanie1
{
    public class ProblemSolver
    {
        private const long MAX_EXECUTION_TIME = 10_000L;
        private Random random = new Random();

        public Global calculateZad1(int m, double z)
        {
            List<SingleCount> singleCounts = new List<SingleCount>();
            var isCompleted = executeWithTimeLimit(() =>
            {
                for (int i = 0; i < m; i++)
                {
                    SingleCount rectangle = new SingleCount(0, 100, random.Next(10, 1000000), AreaType.Rectangle, 2);
                    SingleCount trapezoid = new SingleCount(0, 100, random.Next(10, 1000000), AreaType.Trapezoid, 2);
                    SingleCount trueResult = new SingleCount(0, 100, random.Next(10, 1000000), null, 2);

                    double maxDifference = trueResult.Area * z / 100;

                    if (Math.Abs(trueResult.Area - rectangle.Area) <= maxDifference)
                    {
                        singleCounts.Add(rectangle);
                    }

                    if (Math.Abs(trueResult.Area - trapezoid.Area) <= maxDifference)
                    {
                        singleCounts.Add(trapezoid);
                    }
                }
            });
            if (isCompleted)
            {
                return new Global(singleCounts);
            } else
            {
                throw new TimeoutException();
            }
        }

        public int calculateZad2(double z)
        {
            int i = 1;
            var isCompleted = executeWithTimeLimit(() =>
            {
                List<SingleCount> singleCounts = new List<SingleCount>();
                SingleCount trueResult = new SingleCount(0, 100, 0, null, 3);
                double maxDifference = trueResult.Area * z / 100;

                SingleCount rectangle = new SingleCount(0, 100, i, AreaType.Rectangle, 3);

                SingleCount trapezoid = new SingleCount(0, 100, i, AreaType.Trapezoid, 3);

                while ((Math.Abs(trueResult.Area - rectangle.Area) >= maxDifference) || (Math.Abs(trueResult.Area - rectangle.Area) >= maxDifference))
                {
                    rectangle = new SingleCount(0, 100, i, AreaType.Rectangle, 3);
                    trapezoid = new SingleCount(0, 100, i, AreaType.Trapezoid, 3);
                    i++;
                }
            });

            if (isCompleted)
            {
                return i;
            }
            else
            {
                throw new TimeoutException();
            }
        }

        public double calculateZad3(double x1, double x2, AreaType areaType)
        {
            double result = 0;

            var isCompleted = executeWithTimeLimit(() =>
            {
                SingleCount trueResult = new SingleCount(x1, x2, 0, null, 2);

                for (int i = 1; i <= 6; i++)
                {
                    var singleCount = new SingleCount(x1, x2, (int)Math.Pow(10, i), areaType, 2);

                    result += Math.Pow(trueResult.Area - singleCount.Area, 2);
                }
            });

            if (isCompleted)
            {
                return result / 6;
            }
            else
            {
                throw new TimeoutException();
            }
        }

        public bool calculateZad4(double x1, double x2, int k, double z, AreaType areaType)
        {
            SingleCount singleCount = null;
            var isCompleted = executeWithTimeLimit(() =>
            {
                singleCount = new SingleCount(x1, x2, (int)Math.Pow(10, k), areaType, 3);
            });

            if (isCompleted)
            {
                return (((int)singleCount.Area % z) == 0);
            }
            else
            {
                throw new TimeoutException();
            }
        }

        public List<double> calculateZad5(int k, AreaType areaType)
        {
            double x1 = 0;
            double x2 = 10;
            double x3 = 5;
            double x4 = 6;

            var isCompleted = executeWithTimeLimit(() =>
            {
                var resultFor3 = new SingleCount(x1, x2, k, areaType, 3);

                int n = (int)Math.Pow(10, k);

                var resultFor2 = new SingleCount(x3, x4, n, areaType, 2);

                while (resultFor2.Area < resultFor3.Area)
                {
                    x4++;
                    resultFor2 = new SingleCount(x3, x4, n, areaType, 2);
                }

                double addOrSubstract = 0.5d;

                int toleratedNumberOfIterations = 1000;

                while ((resultFor2.Area != resultFor3.Area) && toleratedNumberOfIterations != 0)
                {
                    if (resultFor2.Area < resultFor3.Area)
                    {
                        x4 += addOrSubstract;
                    }
                    else
                    {
                        x4 -= addOrSubstract;
                    }
                    resultFor2 = new SingleCount(x3, x4, n, areaType, 2);
                    addOrSubstract /= 2;
                    toleratedNumberOfIterations--;
                }
            });

            if (isCompleted)
            {
                return new List<double>() { x1, x2, x3, x4 };
            }
            else
            {
                throw new TimeoutException();
            }
        }

        public Global calculateZad6(int k, int m, AreaType areaType)
        {
            int n = (int)Math.Pow(10, k);
            double currentLowestDifference = double.MaxValue;
            SingleCount currentBestForX2 = null; 
            SingleCount currentBestForX3 = null;

            var isCompleted = executeWithTimeLimit(() =>
            {
                for (int i = 0; i < m; i++)
                {
                    int x1 = random.Next();
                    int x2 = random.Next(x1, int.MaxValue);
                    int x3 = random.Next();
                    int x4 = random.Next(x3, int.MaxValue);
                    var singleCount2 = new SingleCount(x1, x2, n, areaType, 2);
                    var singleCount3 = new SingleCount(x3, x4, n, areaType, 3);

                    double diff = Math.Abs(singleCount2.Area - singleCount3.Area);
                    if (diff < currentLowestDifference)
                    {
                        currentLowestDifference = diff;
                        currentBestForX2 = singleCount2;
                        currentBestForX3 = singleCount3;
                    }
                }
            });

            if (isCompleted)
            {
                return new Global(new List<SingleCount>() { currentBestForX2, currentBestForX3 });
            }
            else
            {
                throw new TimeoutException();
            }
        }

        public int calculateZad7(double x1, double x2, int z, AreaType areaType)
        {
            int n = 1;
            int indexOfFunction = 2; //funkcja kwadratowa

            var isCompleted = executeWithTimeLimit(() =>
            {
                var singleCount = new SingleCount(x1, x2, n, areaType, indexOfFunction);

                while ((int)singleCount.Area % z != 0)
                {
                    n++;
                    singleCount = new SingleCount(x1, x2, n, areaType, indexOfFunction);
                }
            });

            if (isCompleted)
            {
                return n;
            }
            else
            {
                throw new TimeoutException();
            }
        }

        public int calculateZad8(double z, AreaType areaType)
        {
            double trueResult = Math.Sin(Math.PI / 2);
            double x1 = 0;
            double x2 = Math.PI / 2;

            double maxDifference = trueResult * z / 100;


            int n = 1;

            var isCompleted = executeWithTimeLimit(() =>
            {
                var singleCount = new SingleCount(x1, x2, n, areaType, (x) => Math.Cos(x));

                while (Math.Abs(singleCount.Area - trueResult) >= maxDifference)
                {
                    n++;
                    singleCount = new SingleCount(x1, x2, n, areaType, (x) => Math.Cos(x));
                }
            });

            if (isCompleted)
            {
                return n;
            }
            else
            {
                throw new TimeoutException();
            }
        }

        private bool executeWithTimeLimit(Action codeBlock)
        {
            try
            {
                Task task = Task.Factory.StartNew(() => codeBlock());
                task.Wait(TimeSpan.FromMilliseconds(MAX_EXECUTION_TIME));
                return task.IsCompleted;
            }
            catch (AggregateException ae)
            {
                throw ae.InnerExceptions[0];
            }
        }
    }
}