using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace MonteCarloPi
{
    internal class ViewModel : INotifyPropertyChanged
    {
        private readonly IMonteCarloPiCalculator piCalculator;

        public int NumberOfPoints { get; set; }

        private double calculatedPi;

        public double CalculatedPi
        {
            get { return calculatedPi; }

            private set
            {
                calculatedPi = value;
                RaisePropertyChanged("CalculatedPi");
            }
        }

        private double deviation;

        public double Deviation
        {
            get { return deviation; }
            private set
            {
                deviation = value;
                RaisePropertyChanged("Deviation");
            }
        }

        public double Pi
        {
            get { return Math.PI; }
        }

        private IEnumerable<Point> points;

        public IEnumerable<Point> Points
        {
            get { return points; }
            private set
            {
                points = value;
                RaisePropertyChanged("Points");
            }
        }

        public DelegateCommand GoCommand { get; set; }
     
        public ViewModel(IMonteCarloPiCalculator piCalculator)
        {
            this.piCalculator = piCalculator;
            GoCommand = new DelegateCommand(CalculatePi);
        }

        private void RaisePropertyChanged(string propertyName)
        {
            var delegates = PropertyChanged;
            if (delegates != null)
            {
                delegates(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void CalculatePi()
        {
            var result = piCalculator.GetValueOfPi(NumberOfPoints);
            Points = result.Item2;
            CalculatedPi = piCalculator.GetValueOfPi(NumberOfPoints).Item1;
            Deviation = Pi - CalculatedPi;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }

    public class Point
    {
        public double X { get; set; }
        public double Y { get; set; }
    }

}
