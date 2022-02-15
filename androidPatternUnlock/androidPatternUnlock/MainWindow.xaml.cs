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

namespace androidPatternUnlock
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private bool attemptInProgress = false;
        private string passPattern = "1236";
        private string currentPattern = "";

        private void Window_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            attemptInProgress = false;

            if (passPattern == currentPattern)
            {
                foreach (Label label in grid.Children)
                {
                    label.Background = Brushes.LightGreen;
                }

                if (MessageBox.Show("Successful login") == MessageBoxResult.OK);
                {
                    foreach (Label label in grid.Children)
                    {
                        label.Background = Brushes.LightBlue;
                    }
                }
            }

            currentPattern = "";
            

        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            attemptInProgress = true;
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            if (attemptInProgress && e.Source is Label label && !currentPattern.Contains(label.Tag.ToString()))
            {
                currentPattern += label.Tag;
                label.Background = Brushes.Gray;
            }
        }
    }
}
