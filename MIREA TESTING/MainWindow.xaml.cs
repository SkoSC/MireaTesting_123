using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Mirea;

namespace MIREA_TESTING
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private PrimaryTaskInteractor _interactor = new PrimaryTaskInteractor();

        public MainWindow()
        {
            InitializeComponent();

            InputBox.TextChanged += (_, args) =>
            {
                OutputBox.ItemsSource = _interactor.Apply(InputBox.Text);
            };
        }
    }
}