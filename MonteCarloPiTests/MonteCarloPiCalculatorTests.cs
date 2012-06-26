using MonteCarloPi;
using NUnit.Framework;
using UnityAutoMoq;

namespace MonteCarloPiTests
{
    [TestFixture]
    public abstract class TestBase
    {
        protected UnityAutoMoqContainer AutoMock { get; set; }

        [SetUp]
        public void SetUp()
        {
            AutoMock = new UnityAutoMoqContainer();
            Setup();
        }
        
        protected virtual void Setup() { }
    }


    public class MonteCarloPiCalculatorTests : TestBase
    {
        protected override void Setup()
        {
            var mockRandomNumberGenerator = AutoMock.GetMock<IRandomNumberGenerator>();
            int ctr = 0;
            double[] values = {.25, .25, .50, .50, .8, .8, .9, .9};
            mockRandomNumberGenerator.Setup(x => x.GetNext())
                .Returns(() => values[ctr])
                .Callback(() => ctr++);
        }

        [Test]
        public void when_getvalueofpi_is_called_with_four_points_pi_is_approximated_as_expected()
        {
            var monteCarloPiCalculator = AutoMock.Resolve<MonteCarloPiCalculator>();
            Assert.That(monteCarloPiCalculator.GetValueOfPi(4), Is.EqualTo(2));
        }
    }
}
