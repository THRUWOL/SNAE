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

namespace SNAE
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow() => InitializeComponent();
        private void Window_MouseLeftButtonDown(object sender, RoutedEventArgs e) => this.DragMove();
        private void BClose_Click(object sender, RoutedEventArgs e) => this.Close();
        private void BMinimize_Click(object sender, RoutedEventArgs e) => this.WindowState = WindowState.Minimized;

        // x^2-cos(x) = 0; accuracy = 0.001

        /* Метод биссекции */

        /* Метод секущих */

        /* Метод Ньютона-Рафсона*/
    }
}
