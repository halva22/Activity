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

namespace activity
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void calculate_Click(object sender, RoutedEventArgs e)
        {
            bool acts = double.TryParse(_activity1.Text.Replace('.',','), out double a);
            bool times = double.TryParse(time1.Text.Replace('.', ','), out double b);
            bool halfs = double.TryParse(halfTime.Text.Replace('.', ','), out double c);
            bool pows = int.TryParse(power.Text, out int powers);
            if (acts && times && halfs)
            {
                try
                {
                    a = a * Math.Pow(10, powers);
                    double d = Calculate.CalculateResult(a, b, c);
                    current_activity_calculated.Content = Math.Round(d,2).ToString();
                }
                catch { MessageBox.Show("Произошла ошибка"); }
            }
            else
            {
                MessageBox.Show("При чтении введенных данных произошла ошибка");
            }
                        
        }
        
        private void window1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Keyboard.ClearFocus();
        }

        private void _activity1_KeyUp(object sender, KeyEventArgs e)
        {
            calculate.IsEnabled = Calculate.CheckInput(_activity1, time1, halfTime);
        }

        private void time1_KeyUp(object sender, KeyEventArgs e)
        {
            calculate.IsEnabled = Calculate.CheckInput(_activity1, time1, halfTime);
        }

        private void halfTime_KeyUp(object sender, KeyEventArgs e)
        {
            calculate.IsEnabled = Calculate.CheckInput(_activity1, time1, halfTime);
        }
    }
}
