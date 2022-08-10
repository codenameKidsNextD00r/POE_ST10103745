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
    /// Interaction logic for WeeksAndDate.xaml
    /// </summary>
    public partial class WeeksAndDate : Window
    {
        public WeeksAndDate()
        {
            InitializeComponent();
        }

        private void BTN_Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Hide();
            mainWindow.Show();
        }

        private void BTN_Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BTN_Submit_Click(object sender, RoutedEventArgs e)
        {
            //Declarations with objects from other window
            MainWindow main = new MainWindow();
            string moduleName = main.TB_ModuleName.Text;
            string moduleCode = main.TB_ModuleCode.Text;
            string credits = main.TB_Credits.Text;
            string hours = main.TB_Hours.Text;

            //Process
            dataStorage storage = new dataStorage(moduleName, moduleCode, credits, hours);
            MessageBox.Show(storage.ToString());
        }
    }
}
