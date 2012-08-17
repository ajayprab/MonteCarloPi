using System;
using System.Collections.Generic;

namespace MonteCarloPi
{

     interface IMonteCarloPiCalculator
    {
        Tuple<double,IEnumerable<Point>> GetValueOfPi(int numberOfPoints);
    }

    public class MonteCarloPiCalculator : IMonteCarloPiCalculator
    {
        private readonly IRandomNumberGenerator randomNumberGenerator;

        public MonteCarloPiCalculator(IRandomNumberGenerator randomNumberGenerator)
        {
            this.randomNumberGenerator = randomNumberGenerator;
        }

        public Tuple<double, IEnumerable<Point>> GetValueOfPi(int numberOfPoints)
        {
            var numberOfPointsInCircle = 0;
            List<Point> points = new List<Point>();
            double tempx, tempy;
            for (int i = 0; i < numberOfPoints; i++)
            {
                tempx = randomNumberGenerator.GetNext();
                tempy = randomNumberGenerator.GetNext();
                if (Math.Pow(tempx, 2) + Math.Pow(tempy, 2) <= 1)
                {
                    points.Add(new Point { X = tempx*100, Y = tempy*100 });
                    numberOfPointsInCircle++;
                }
            }

            return Tuple.Create<double,IEnumerable<Point>>(((double) numberOfPointsInCircle/numberOfPoints)*4, points);
        }
    }
}