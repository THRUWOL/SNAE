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
            double h;
            int iter = 0;

            if (left != null && right != null)
            {
                if (CBBisection.IsChecked == true)
                {
                    do
                    {
                        h = (left + right) / 2;
                        double middle_expresion = f(h);
                        if ((left_expression * middle_expresion) < 0) right = h;
                        else left = h;
                        if (Math.Abs(middle_expresion) <= eps || (right - left) <= eps || iter == 1000) break;
                        iter++;
                    } while (true);
                    TBAnswer.Text = Convert.ToString(h);
                    TBIter.Text = Convert.ToString(iter);
                }
                else if (CBSecant.IsChecked == true)
                {
                    iter = 0;
                    double x_next = 0;
                    double tmp;

                    do
                    {
                        tmp = x_next;
                        x_next = x_curr - f(x_curr) * (x_prev - x_curr) / (f(x_prev) - f(x_curr));
                        x_prev = x_curr;
                        x_curr = tmp;
                        iter++;
                    } while (Math.Abs(x_next - x_curr) > eps2);
                    TBAnswer.Text = Convert.ToString(x_next);
                    TBIter.Text = Convert.ToString(iter);
                }
                else
                {
                    // если ничего не выбрано
                    // sin(y) + 2x = 2
                    // cos(x-1) + y = 0.7
                }
            }
        }

        private void CBBisection_Checked(object sender, RoutedEventArgs e)
        {
            CBSecant.IsEnabled = false;
            Diapazon.Visibility = Visibility;
        }
        private void CBBisection_Unchecked(object sender, RoutedEventArgs e)
        {
            CBSecant.IsEnabled = true;
            Diapazon.Visibility = Visibility.Hidden;
        }
        private void CBSecant_Checked(object sender, RoutedEventArgs e)
        {
            CBBisection.IsEnabled = false;
            Diapazon2.Visibility = Visibility;
        }
        private void CBSecant_Unchecked(object sender, RoutedEventArgs e)
        {
            CBBisection.IsEnabled = true;
            Diapazon2.Visibility = Visibility.Hidden;
        }

        // x^2-cos(x) = 0; accuracy = 0.001

        /* Метод биссекции */

        /* Метод секущих */

        /* Метод Ньютона-Рафсона*/
    }
}
