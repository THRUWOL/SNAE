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
    public partial class MainWindow : Window
    {
        public MainWindow() => InitializeComponent();
        private void Window_MouseLeftButtonDown(object sender, RoutedEventArgs e) => this.DragMove();
        private void BClose_Click(object sender, RoutedEventArgs e) => this.Close();
        private void BMinimize_Click(object sender, RoutedEventArgs e) => this.WindowState = WindowState.Minimized;

        double f(double x) 
        {
            return (x*x) - Math.Cos(x);
            //return 2 * Math.Log10(x) - x / 2 + 1;
        }
        double n1(double x, double y)
        {
            return Math.Sin(y) + 2 * x - 2;
        }
        double n2(double x, double y)
        {
            return Math.Cos(x - 1) + y - 0.7;
        }

        private void BStart_Click(object sender, RoutedEventArgs e)
        {
            
            double left = Convert.ToDouble(TBLeft.Text);
            double right = Convert.ToDouble(TBRight.Text);
            double x_prev = Convert.ToDouble(TBxa.Text);
            double x_curr = Convert.ToDouble(TBxb.Text);
            double left_expression = f(left);

            double eps = Convert.ToDouble(TBEps.Text);
            double eps2 = Convert.ToDouble(TBEps_seidel.Text);
            double eps3 = Convert.ToDouble(TBEps_newton.Text);
            double h;
            int iter = 0;

        }

        private void CBBisection_Checked(object sender, RoutedEventArgs e)
        {
            CBSecant.IsEnabled = false;
            CBNewton.IsEnabled = false;
            Diapazon.Visibility = Visibility;
        }
        private void CBBisection_Unchecked(object sender, RoutedEventArgs e)
        {
            CBSecant.IsEnabled = true;
            CBNewton.IsEnabled = true;
            Diapazon.Visibility = Visibility.Hidden;
        }
        private void CBSecant_Checked(object sender, RoutedEventArgs e)
        {
            CBBisection.IsEnabled = false;
            CBNewton.IsEnabled = false;
            Diapazon2.Visibility = Visibility;
        }
        private void CBSecant_Unchecked(object sender, RoutedEventArgs e)
        {
            CBBisection.IsEnabled = true;
            CBNewton.IsEnabled = true;
            Diapazon2.Visibility = Visibility.Hidden;
        }
        private void CBNewton_Checked(object sender, RoutedEventArgs e)
        {
            CBBisection.IsEnabled = false;
            CBSecant.IsEnabled = false;
            Diapazon3.Visibility = Visibility;
            GRID1.Visibility = Visibility.Hidden;
            GRID1_Copy.Visibility = Visibility;
        }
        private void CBNewton_Unchecked(object sender, RoutedEventArgs e)
        {
            CBBisection.IsEnabled = true;
            CBSecant.IsEnabled = true;
            Diapazon3.Visibility = Visibility.Hidden;
            GRID1_Copy.Visibility = Visibility.Hidden;
            GRID1.Visibility = Visibility;
        }
    }
}
