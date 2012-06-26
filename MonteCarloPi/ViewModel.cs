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

        private List<Point> points;

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
            CalculatedPi = piCalculator.GetValueOfPi(NumberOfPoints);
            Deviation = Pi - CalculatedPi;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }

    class Point
    {
        public int x { get; set; }
        public int y { get; set; }
    }

}
