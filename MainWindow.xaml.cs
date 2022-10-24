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
using System.Xml.Schema;

namespace POE_ST10103745 //Part 1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //variable declaration
        public string moduleName, moduleCode;
        public int credits;
        public double hours;

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
            moduleName = TB_ModuleName.Text;
            moduleCode = TB_ModuleCode.Text;
            credits = 0;
            hours = 0;
            


            //Validation
            //exciption handling for textbox to int conversion

            if (string.IsNullOrWhiteSpace(moduleName) ||
                string.IsNullOrWhiteSpace(moduleCode) ||
                !Int32.TryParse(TB_Credits.Text, out credits) ||
                !Double.TryParse(TB_Hours.Text, out hours)
               )

            {
                MessageBox.Show("All fields must be filled in correctly to continue!");
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

        private void BTN_Add_Click(object sender, RoutedEventArgs e)
        {
            
            if (string.IsNullOrWhiteSpace(moduleName) ||
                string.IsNullOrWhiteSpace(moduleCode) ||
                !Int32.TryParse(TB_Credits.Text, out credits) ||
                !Double.TryParse(TB_Hours.Text, out hours)
                )

            {
                MessageBox.Show("Please input module details first");
            }

            else 
            {
                MessageBox.Show("Module Successfully Added.");
            }

            //Clearing input data
            TB_ModuleName.Clear();
            TB_ModuleCode.Clear();
            TB_Hours.Clear();
            TB_Credits.Clear();


        }
    }
}
