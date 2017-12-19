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
using System.Data;
using MySql.Data.MySqlClient;

namespace projectalpha
{
   
    public partial class MainWindow : Window
    {
       public string name;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        { string connectingString = @"Server=localhost;DATABASE=projectalpha;UID=root;PASSWORD=root;";
            MySqlConnection connection = new MySqlConnection(connectingString);
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
            name = textBoxUser.Text;
            string password = passBoxPwd.Password;
            MySqlCommand cmd = new MySqlCommand("select * from customer where login = \'" + name + "\' and Password = \'" + password + "\';", connection);
                cmd.CommandType = CommandType.Text;
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = cmd;
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);
                 if (dataSet.Tables[0].Rows.Count > 0)
                {

                    Process process = new Process();
                    process.Show();

                    this.Close();
                    Calculator.Calculator calculator = new Calculator.Calculator();
                    calculator.Show();

                }
                else {
                    MessageBox.Show("Пароль или логин неверный!");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);



            }
            finally
            {
                connection.Close();
            }

            // DataTable dt = new DataTable();
            //dt.Load(cmd.ExecuteReader());
            //connection.Close();
            //dtGrid.DataContext = dt;
            
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Forgotpassword_Click(object sender, RoutedEventArgs e)
        { 

        }
        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            Registration a = new Registration();
            a.Show();
            this.Close();

        }

        private void Alphaprocess_Click(object sender, RoutedEventArgs e)
        {
            
            Process a = new Process();
            a.Show();
            
            Calculator.Calculator calculator = new Calculator.Calculator();
            calculator.Show();
            this.Close();
        }

        
    }
}

