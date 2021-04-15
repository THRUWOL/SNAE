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



            if (left != null && right != null)
            {
                /* Метод биссекции */
                if (CBBisection.IsChecked == true)
                {
                    TBAnswer.Text = Convert.ToString(Solver.BisectionFindRoot(f, left, right,eps));
                    
                }
                /* Метод секущих */
                else if (CBSecant.IsChecked == true)
                {
                    TBAnswer.Text = Convert.ToString(Solver.SecantFindRoot(f, x_prev, x_curr, eps2));
                }
                else if (CBNewton.IsChecked == true)
                {
               //     TBAnswer_newton.Text = Convert.ToString(Solver.NewtonRaphson(n1,n2,1,eps3));
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

    public static class Solver
    {
        public static double? BisectionFindRoot(Func<double, double> f, double lowerBound, double upperBound,
            double rangeTolerance = 1e-10, double fTolerance = 1e-3, int maxIterations = 100)
        {
            double root = 0.5 * (upperBound + lowerBound);
            bool convergence = false;
            double fLowerBound = f(lowerBound);
            for (int iteration = 0; iteration < maxIterations && !convergence; iteration++)
            {
                double fRoot = f(root);
                double range = Math.Abs(upperBound - lowerBound);
                convergence = range <= rangeTolerance && Math.Abs(fRoot) <= fTolerance;
                if (Math.Sign(fRoot) == Math.Sign(fLowerBound))
                {
                    lowerBound = root;
                    fLowerBound = fRoot;
                }
                else
                {
                    upperBound = root;
                }
                root = 0.5 * (upperBound + lowerBound);

            }

            return convergence ? root : (double?)null;
        }

        public static double? SecantFindRoot(Func<double, double> f, double lowerBound, double upperBound,
            double rangeTolerance = 1e-10, double fTolerance = 1e-3, int maxIterations = 100)
        {
            double fLowerBound = f(lowerBound);
            double fUpperBound = f(upperBound);
            double root = upperBound - (upperBound - lowerBound) / (fUpperBound - fLowerBound) * fUpperBound;
            bool convergence = false;
            for (int iteration = 0; iteration < maxIterations && !convergence; iteration++)
            {
                double fRoot = f(root);
                double range = Math.Min(upperBound - root, root - lowerBound);
                convergence = range <= rangeTolerance && Math.Abs(fRoot) <= fTolerance;
                int fRootSign = Math.Sign(fRoot);
                if (fRootSign == Math.Sign(fLowerBound))
                {
                    lowerBound = root;
                    fLowerBound = fRoot;
                }
                else if (fRootSign == Math.Sign(fUpperBound))
                {
                    upperBound = root;
                    fUpperBound = fRoot;
                }
                else
                {
                    if (Math.Abs(fLowerBound) > Math.Abs(fUpperBound))
                    {
                        fLowerBound = 0;
                        lowerBound = root;
                    }
                    else
                    {
                        fUpperBound = 0;
                        upperBound = root;
                    }
                }
                root = upperBound - (upperBound - lowerBound) / (fUpperBound - fLowerBound) * fUpperBound;
            }

            return convergence ? root : (double?)null;
        }

        public static double? NewtonRaphson(Func<double, double> f, Func<double, double> df, double x0,
            double xTolerance = 1e-10, double fTolerance = 1e-10, int maxIterations = 100)
        {
            bool convergence = false;
            double root = x0;
            for (int iteration = 0; iteration < maxIterations && !convergence; iteration++)
            {
                double fRoot = f(root);
                double nextRoot = root - fRoot / df(root);
                convergence = Math.Abs(nextRoot - root) <= xTolerance && Math.Abs(fRoot) <= fTolerance;
                root = nextRoot;
            }
            return convergence ? root : (double?)null;
        }
    }
}
