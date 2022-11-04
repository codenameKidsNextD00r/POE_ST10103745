using System.Data.SqlClient;
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
using System.Text.RegularExpressions;
using System.Data;


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

        //establish connection
        SqlConnection connection = new SqlConnection(@"Data Source=ROZE\SQLEXPRESS; Initial Catalog=Bongani_POE; Integrated Security=True");
        //command
        SqlCommand command;
        //adapter
        SqlDataAdapter adapter;


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
            display displayWindow = new display();
            this.Hide();
            displayWindow.Show();

            connection.Open();
            DataTable table = new DataTable();
            adapter= new SqlDataAdapter("select * from Module_Details", connection);
            adapter.Fill(table);
            displayWindow.dg_moduleData.ItemsSource = table.DefaultView;
            //Datagrid.ItemsSource = ddt.DefaultView;
            connection.Close();

            //Process
            //dataStorage storage = new dataStorage(moduleName, moduleCode, credits, hours);
            //MessageBox.Show(storage.ToString());

        }

        private void TB_Hours_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        //ensure we can enter numeric values and decimals in the textbox
        private void TypeNumericValidation(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9.,]+").IsMatch(e.Text);
        }

        //ensure users don't paste string data into textbox
        private void PasteNumericValidation(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(String)))
            {
                String input = (String)e.DataObject.GetData(typeof(String));
                if (new Regex("[^0-9.,]+").IsMatch(input))
                {
                    e.CancelCommand();
                }
            }
            else e.CancelCommand();
        }

        private void BTN_Add_Click(object sender, RoutedEventArgs e)
        {

            //ensure all fields are entered 
            if (
                (string.IsNullOrWhiteSpace(TB_ModuleName.Text) ||
                (string.IsNullOrWhiteSpace(TB_ModuleCode.Text) ||
                TB_Hours.Text == " " ||
                TB_Credits.Text == ""
                )))
            {
                MessageBox.Show("Enter all module details.");
            }

            else
            {
                connection.Open();
                command = new SqlCommand(@"INSERT INTO Module_Details (MODULE_NAME, MODULE_CODE, WEEKLY_HOURS, CREDITS)" +
                    "VALUES (@MODULE_NAME, @MODULE_CODE, @WEEKLY_HOURS, @CREDITS)", connection);
                command.Parameters.AddWithValue("@MODULE_NAME", TB_ModuleName.Text);
                command.Parameters.AddWithValue("@MODULE_CODE", TB_ModuleCode.Text);
                command.Parameters.AddWithValue("@WEEKLY_HOURS", TB_Hours.Text);
                command.Parameters.AddWithValue("@CREDITS", TB_Credits.Text);

                command.ExecuteNonQuery();
                connection.Close();

                MessageBox.Show("Module Successfully Added.");

                //Clearing input data
                TB_ModuleName.Clear();
                TB_ModuleCode.Clear();
                TB_Hours.Clear();
                TB_Credits.Clear();
            }

            
            

            


        }
    }
}
