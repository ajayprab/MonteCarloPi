using System;

namespace MonteCarloPi
{

    public interface IMonteCarloPiCalculator
    {
        double GetValueOfPi(int numberOfPoints);
    }

    public class MonteCarloPiCalculator : IMonteCarloPiCalculator
    {
        private readonly IRandomNumberGenerator randomNumberGenerator;

        public MonteCarloPiCalculator(IRandomNumberGenerator randomNumberGenerator)
        {
            this.randomNumberGenerator = randomNumberGenerator;
        }

        public double GetValueOfPi(int numberOfPoints)
        {
            var numberOfPointsInCircle = 0;
            double tempx, tempy;
            for (int i = 0; i < numberOfPoints; i++)
            {
                tempx = randomNumberGenerator.GetNext();
                tempy = randomNumberGenerator.GetNext();
                if (Math.Pow(tempx, 2) + Math.Pow(tempy, 2) <= 1)
                {
                    numberOfPointsInCircle++;
                }
            }

            return ((double) numberOfPointsInCircle/numberOfPoints)*4;
        }
    }
}