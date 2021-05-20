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

namespace Laba_3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double num1 = 0;
        double num2 = 0;
        string op = "";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_num_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            String num = button.Content.ToString();
            if (txtVal.Text == "0")
                txtVal.Text = num;
            else
                txtVal.Text += num;


            if (op == "")
            {
                num1 = Double.Parse(txtVal.Text);
            }
            else
            {
                num2 = Double.Parse(txtVal.Text);
            }
            
        }

       

        private void btn_op_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            op = button.Content.ToString();                      
        }

        

        private void btn_eq_Click(object sender, RoutedEventArgs e)
        {
            double res = 0;
            switch (op)
            {
                case "+":                    
                        res = num1 + num2;
                        break;
                    
                case "-":                    
                        res = num1 - num2;
                        break;
                    
                case "*":                    
                        res = num1 * num2;
                        break;
                    
                case "/":                    
                        res = num1 / num2;
                        break;
                    
                case "min":                    
                        res = Math.Min(num1, num2);
                        break;
                    
                case "max":                    
                        res = Math.Max(num1, num2);
                        break;
                case "avg":
                    res = (num1 + num2) / 2;
                    break;
                case "x^y":
                    res = Pow(num1, (int)num2);
                    break;
            }

            txtVal.Text = res.ToString();
            op = "";
            num1 = res;
            num2 = 0;
        }

        private double Pow(double x, int y)
        {
            if (y == 0)
                return 1;
             return Pow(x, y - 1) * x;
        }

        private void btn_CE_Click(object sender, RoutedEventArgs e)
        {
            txtVal.Text = "0";
            num1 = 0;
            num2 = 0;
            op = "";
        }

        private void btn_C_Click(object sender, RoutedEventArgs e)
        {
            txtVal.Text = "0";            
        }

        private void btn_plusminus_Click(object sender, RoutedEventArgs e)
        {
            if (op == "")
            {
                num1 *= -1;
                txtVal.Text = num1.ToString();
            }
            else
            {
                num2 *= -1;
                txtVal.Text = num2.ToString();
            }
        }

        private void btn_backspace_Click(object sender, RoutedEventArgs e)
        {
            txtVal.Text = DropLastChar(txtVal.Text);
            if (op == "")
            {
                num1 = double.Parse(txtVal.Text);
            }
            else
            {
                num2 = double.Parse(txtVal.Text);
            }
        }

        private string DropLastChar(string text)
        {
            if (text.Length == 1)
            {
                text = "0";
            }
            else
            {
                text = text.Remove(text.Length - 1, 1);
                if (text[text.Length - 1] == ',')
                {
                    text = text.Remove(text.Length - 1, 1);
                }                
            }
            return text;
        }

        private void btn_comma_Click(object sender, RoutedEventArgs e)
        {
            if (op == "")
                SetComma(num1);
            else
                SetComma(num2);

        }

        private void SetComma(double num)
        {
            if (txtVal.Text.Contains(','))
                return;
            txtVal.Text += ',';
        }
    }
}
