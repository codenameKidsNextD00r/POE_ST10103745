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

namespace POE_ST10103745
{
    /// <summary>
    /// Interaction logic for startup.xaml
    /// </summary>
    public partial class startup : Window
    {
        public startup()
        {
            InitializeComponent();
        }

        private void btn_Register_Click(object sender, RoutedEventArgs e)
        {
            sign_up sign_Up = new sign_up();
            this.Hide();
            sign_Up.Show();
        }

        private void btn_Login_Click(object sender, RoutedEventArgs e)
        {
            login login = new login();
            this.Hide();
            login.Show();
        }
    }
}
