using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Controls.Primitives;

namespace POE_ST10103745
{
    /// <summary>
    /// Interaction logic for login.xaml
    /// </summary>
    public partial class login : Window
    {
        //establish connection
        SqlConnection connection = new SqlConnection(@"Data Source=ROZE\SQLEXPRESS; Initial Catalog=Bongani_POE; Integrated Security = true");
        //command to be used later
        SqlCommand command;
        //Adapter to be used later 
        SqlDataAdapter adapter;
        //Data Reader to read rows from sql server
        SqlDataReader reader;
        public login()
        {
            InitializeComponent();
        }

        private void btn_Exit_Click(object sender, RoutedEventArgs e)
        {
           this.Close();
        }

        private void btn_Back_Click(object sender, RoutedEventArgs e)
        {
            startup startup = new startup();
            this.Hide();
            startup.Show();
        }

        private void btn_SubmitLogin_Click(object sender, RoutedEventArgs e)
        {
            //make sure textboxes aren't empty
            if (string.IsNullOrWhiteSpace(tb_username.Text) ||
                tb_password.Password == ""
                )
            {
                MessageBox.Show("Please fill all empty fields");
            }

            //check if user exists or is registered 
            else
            {
                string username = tb_username.Text;
                string password = tb_password.Password;
                command = new SqlCommand();
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM User_Details where USERNAME='" + tb_username.Text + "' AND PASSWORD='" + tb_password.Password + "'";
                reader = command.ExecuteReader();
                
                if (reader.Read())
                {
                    MessageBox.Show("Welcome " + username + "!" );
                    MainWindow mw = new MainWindow();
                    this.Hide();
                    mw.Show();

                }
                else
                {
                    MessageBox.Show("Invalid Login please check username and password");
                }
                connection.Close();
            }
        }
    }
}
