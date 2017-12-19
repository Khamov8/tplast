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
using System.Windows.Shapes;
using System.Data;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;

namespace projectalpha
{
    
    public partial class Process : Window
    {
        public Process()
        {
            InitializeComponent();
            MainWindow ma = new MainWindow();
          string login = ma.name;


            string connectingString = @"Server=localhost;DATABASE=projectalpha;UID=root;PASSWORD=root;";
            MySqlConnection connection = new MySqlConnection(connectingString);
            MySqlCommand cmd = new MySqlCommand("select * from customer where Charges = \'" + Charges + "\' and Profit = \'" + Profit + "\'and login =\'"+ma.name+"\' ;", connection);
            DataTable dt = new DataTable();
              /*connection.Open();
              dt.Load(command.ExecuteReader());
              connection.Close();
              dtGrid.DataContext = dt;


            command.ExecuteReader();*/

        }
        private void EnterP_Click(object sender, RoutedEventArgs e)
        {
            string connection = @"Server=localhost;DATABASE=projectalpha;UID=root;PASSWORD=root;";
            
            MySqlConnection MySql = new MySqlConnection(connection);

            /*MainWindow ma = new MainWindow();
            string login = ma.name;*/

            string profit = Profit.Text;
            string charges = Charges.Text;
            string insertUserCommand = ("insert into customer(Profit," + "Charges)" +
                "values" + "('" + profit + "', '" + charges + "');");
          
            MySqlCommand command = new MySqlCommand(insertUserCommand, MySql);
            try
            {
                if (MySql.State == System.Data.ConnectionState.Closed)
                {
                    MySql.Open();
                }

                //command.ExecuteReader();
                int count = Convert.ToInt32(command.ExecuteScalar());
                if (count == 0)
                {
                    MessageBox.Show("Данные внесены");
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Вы ввели одинаковые даннные");
            }
            finally
            {
                MySql.Close();
            }
            
        }

        private void СomputationP_Click(object sender, RoutedEventArgs e)
        {
            string profit = Profit.Text;
            string charges = Charges.Text;


            double prof = Double.Parse(profit);
            double charge = Double.Parse(charges);
            double x, y, incomeYear, incomeMonth, incomeWeek, incomeDay, weekprofit, weekcharge, dayprofit, daycharge;
            double year = 12;


            string S1 = Profit.Text;
            x = Convert.ToDouble(S1);


            string S2 = Charges.Text;
            y = Convert.ToDouble(S2);


            prof = x * year;
            charge = y * year;
            incomeYear = prof - charge;
            incomeMonth = x - y;
            weekprofit = x / 30 * 7;
            weekcharge = y / 30 * 7;
            incomeWeek = weekprofit - weekcharge;
            dayprofit = x / 30;
            daycharge = y / 30;
            incomeDay = dayprofit - daycharge;


            YearP.Text = profit.ToString();
            YearC.Text = charge.ToString();
            NetIncomeYear.Text = incomeYear.ToString();
            MonthP.Text = x.ToString();
            MonthC.Text = y.ToString();
            NetIncomeMonth.Text = incomeMonth.ToString();
            WeekP.Text = weekprofit.ToString();
            WeekC.Text = weekcharge.ToString();
            IncomeWeek.Text = incomeWeek.ToString();
            DayP.Text = dayprofit.ToString();
            DayC.Text = daycharge.ToString();
            IncomeDay.Text = incomeDay.ToString();


        }
        private void Profit_TextChanged(object sender, TextChangedEventArgs e)
        {

            //TextBox box = sender as TextBox;

            //this.Entered.IsEnabled = box.Text.Length > 0;


        }
        private void Charges_TextChanged(object sender, TextChangedEventArgs e)
        {

            TextBox box = sender as TextBox;

            this.Сomputation.IsEnabled = box.Text.Length > 0;


        }
        private void textBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void ClearP_Click(object sender, RoutedEventArgs e)
        {
            string text =NetIncomeYear.Text;
            if (text != "CLEAR")
            {
                Profit.Text ="";
                Charges.Text = "";
                YearP.Text = "";
                YearC.Text = "";
                NetIncomeYear.Text = "";
                MonthP.Text = "";
                MonthC.Text = "";
                NetIncomeMonth.Text = "";
                WeekP.Text = "";
                WeekC.Text = "";
                IncomeWeek.Text = "";
                DayP.Text = "";
                DayC.Text = "";
                IncomeDay.Text = "";
               
            }
        }

        private void CloseP_Click(object sender, RoutedEventArgs e)
        { 
            this.Close();
        }

  
    }
}
