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

namespace POE_ST10103745
{
    /// <summary>
    /// Interaction logic for sign_up.xaml
    /// </summary>
    public partial class sign_up : Window
    {
        //establish connection 
        SqlConnection connection = new SqlConnection(@"Data Source=ROZE\SQLEXPRESS; Initial Catalog=Bongani_POE;" + "Integrated Security=True");
        //command
        SqlCommand command;
        //adapter
        SqlDataAdapter adapter;

        public sign_up()
        {
            InitializeComponent();
        }

        private void btn_SubmitRegister_Click(object sender, RoutedEventArgs e)
        {
            //make sure text boxes are not empty
            if (string.IsNullOrEmpty(tb_Name.Text) ||
                string.IsNullOrEmpty(tb_username.Text) ||
                string.IsNullOrWhiteSpace(tb_email.Text) ||
                tb_password.ToString() == "" ||
                tb_passwordConfirm.ToString() == ""
                )
            {
                MessageBox.Show("Please enter all values.");
            }

            //make sure password and confirm passowrd are the same
            else if (tb_password.ToString() != tb_passwordConfirm.ToString())
            {
                MessageBox.Show("Make sure you enter the same password both times.");
            }

            else //intsert data in table
            {
                connection.Open();
                command = new SqlCommand("INSERT INTO User_Details (FULL_NAME, USERNAME, EMAIL, PASSWORD) " +
                "VALUES (@FULL_NAME, @USERNAME, @EMAIL, @PASSWORD)", connection);

                command.Parameters.AddWithValue("@FULL_NAME", tb_Name.Text);
                command.Parameters.AddWithValue("@USERNAME", tb_username.Text);
                command.Parameters.AddWithValue("@EMAIL", tb_email.Text);
                command.Parameters.AddWithValue("@PASSWORD", tb_password.Password);
                command.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("You've Successfully Registered");

                //Go to Login
                login login = new login();
                this.Hide();
                login.Show();
            }
        }

        private void btn_Back_Click(object sender, RoutedEventArgs e)
        {
            startup startup = new startup();
            this.Hide();
            startup.Show();
        }

        private void btn_Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
