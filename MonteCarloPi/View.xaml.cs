using System.Windows;
using Microsoft.Practices.Unity;

namespace MonteCarloPi
{
    /// <summary>
    /// Interaction logic for View.xaml
    /// </summary>
    public partial class View : Window
    {
        public View()
        {
            InitializeComponent();
            IUnityContainer container = new UnityContainer();
            container.RegisterType<IRandomNumberGenerator, RandomNumberGenerator>();
            container.RegisterType<IMonteCarloPiCalculator, MonteCarloPiCalculator>();
            DataContext = container.Resolve<ViewModel>();
        }
    }
}
