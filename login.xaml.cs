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

        }
    }
}
