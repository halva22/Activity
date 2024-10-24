using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace activity
{
    public class Calculate
    {
        //startActivity - значение паспортной активности источника (записывается из окошка Исходная активность, в Бк)
        //time - время, в течение которого продолжается распад, берется из окошка Время распада, в часах
        //halfTime - период полураспада радионуклида в источнике, записывается из окошка Период полураспада, в часах
         
        //непосредственный пересчет активности
        public static double CalculateResult(double startActivity, double time, double halfTime)
        {
            try
            {
                return startActivity * Math.Exp(-0.693 * time / halfTime);
            }
            catch
            {
                MessageBox.Show("При выполнении расчета произошла ошибка");
                return 0;
            }
        }
        //проверка. что все введено
        public static bool CheckInput(TextBox textBox, TextBox t, TextBox b)
        {
            if (textBox.Text != "" && t.Text != "" && b.Text != "")
            {
                return true;
            }
            return false;
        }
    }
}
