using System;

namespace MonteCarloPi
{
    public interface IRandomNumberGenerator
    {
        double GetNext();
    }

    public class RandomNumberGenerator : IRandomNumberGenerator
    {
        private readonly Random random;

        public RandomNumberGenerator()
        {
            random = new Random();
        }

        public double GetNext()
        {
            return random.NextDouble();
        }
    }
}