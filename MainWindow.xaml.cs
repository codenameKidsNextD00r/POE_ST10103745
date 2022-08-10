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

namespace POE_ST10103745 //Part 1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {   
            //exit application
            this.Close();
        }

        private void BTN_Next_Click(object sender, RoutedEventArgs e)
        {
            //Declarations first
            string moduleName = TB_ModuleName.Text;
            string moduleCode = TB_ModuleCode.Text;
            string credits = TB_Credits.Text;
            string hours = TB_Hours.Text;

            //Validation
            if (string.IsNullOrWhiteSpace(moduleName) ||
                string.IsNullOrWhiteSpace(moduleCode) ||
                string.IsNullOrWhiteSpace(credits) ||
                string.IsNullOrWhiteSpace(hours))
            {
               
                MessageBox.Show("All fields must be filled to continue!");
            }
            
            else
            {

                WeeksAndDate weeksAndDate = new WeeksAndDate();//object created for new window
                this.Hide();//hide current window
                weeksAndDate.Show(); //show new window
            }

            //Process
            //dataStorage storage = new dataStorage(moduleName, moduleCode, credits, hours);
            //MessageBox.Show(storage.ToString());


        }
    }
}
