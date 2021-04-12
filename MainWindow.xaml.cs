using org.mariuszgromada.math.mxparser;
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
using Expression = org.mariuszgromada.math.mxparser.Expression; //парсер для формулы

namespace SNAE
{
    public partial class MainWindow : Window
    {
        public MainWindow() => InitializeComponent();
        private void Window_MouseLeftButtonDown(object sender, RoutedEventArgs e) => this.DragMove();
        private void BClose_Click(object sender, RoutedEventArgs e) => this.Close();
        private void BMinimize_Click(object sender, RoutedEventArgs e) => this.WindowState = WindowState.Minimized;

        readonly Argument x = new Argument("x");

        private void BStart_Click(object sender, RoutedEventArgs e)
        {
            x.setArgumentValue(1);
            Expression expression = new Expression(TBExpression.Text, x); // парсим формулу

            double eps = Convert.ToDouble(TBEps.Text);
            double left_argument = Convert.ToDouble(TBLeft.Text);
            double right_argument = Convert.ToDouble(TBRight.Text);
            double middle_argument = 0;
            double h;
            
            if (expression != null && left_argument != null && right_argument != null)
            {
                if (CBBisection.IsChecked == true)
                {
                    while (right_argument-left_argument > eps)
                    {
                        h = (right_argument - left_argument) / 2;
                        middle_argument = left_argument + h;
                        if (Math.Sign(left_argument) != Math.Sign(right_argument))
                        {
                            right_argument = middle_argument;
                        }
                        else left_argument = middle_argument;
                    }
                    TBExpression.Text = Convert.ToString(middle_argument);
                }
                else if (CBSecant.IsChecked == true)
                {

                }
                else
                {
                    // если ничего не выбрано
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
        }
        private void CBSecant_Unchecked(object sender, RoutedEventArgs e)
        {
            CBBisection.IsEnabled = true;
        }

        // x^2-cos(x) = 0; accuracy = 0.001

        /* Метод биссекции */

        /* Метод секущих */

        /* Метод Ньютона-Рафсона*/
    }
}
