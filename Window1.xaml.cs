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

namespace projectalpha
{
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void Finish_Click(object sender, RoutedEventArgs e)
        {
            MainWindow a = new MainWindow();
            a.Show();
            string connection = @"Server=localhost;DATABASE=projectalpha;UID=root;PASSWORD=root;";
            MySqlConnection mySql = new MySqlConnection(connection);
            
            string name = textBoxUserR.Text;
            string password = passBoxPwdR.Password;
            string firstname = FirstnameR.Text;
            string secondname = SecondnameR.Text;
            string insertUserCommand=("insert into customer(Password,"+ "Firstname,"+  "Secondname,"+ "login)" +
                "values" + "('" + password + "', '" + firstname + "', '" + secondname + "', '" + name + "');");
            MySqlCommand command = new MySqlCommand(insertUserCommand, mySql);

            try
            {
                if (mySql.State == System.Data.ConnectionState.Closed)
                {
                    mySql.Open();
                }

                //command.ExecuteReader();
                int count = Convert.ToInt32(command.ExecuteScalar());
                if (count == 0)
                {
                    MessageBox.Show("Регистрация прошла успешно!");
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Пользователь уже с таким логином существует!");
            }
            finally
            {
                mySql.Close();
            }
            //Сула спроси про statusId
            //DataTable dt = new DataTable();
            //dt.Load(cmd.ExecuteReader());
            //connection.Close();
            //dtGrid.DataContext = dt;
            this.Close();
        }

        private void textBoxUserR_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void FirstnameR_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
