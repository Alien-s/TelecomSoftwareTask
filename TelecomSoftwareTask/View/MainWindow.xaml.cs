using Persons;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using TelecomSoftwareTask.Controller;
using TelecomSoftwareTask.Data;
using TelecomSoftwareTask.Model;

namespace TelecomSoftwareTask
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<User> Users { get; set; }
        public ObservableCollection<Name> ListOfCangedNames { get; set; }


        public MainWindow()
        {
            InitializeComponent();
            DataContext = ListOfCangedNames;
        }

        /// <summary>
        /// On the loaded window receive the Data from file and show at DataGrid 
        /// </summary>
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Users = await GetData.GetIncommingsListOfUsers();
            dgIncommingData.DataContext = Users;
            dgIncommingData.ItemsSource = Users;
        }


        /// <summary>
        /// By click of button generate the first list of changed names
        /// </summary>
        private void btnStep_1_Click(object sender, RoutedEventArgs e)
        {
            ChangedName changedName = new ChangedName();

            ListOfCangedNames = changedName.ChangeWhole(Users);
            dgListOfWholeCahngedNames.ItemsSource = ListOfCangedNames;

            btnStep_2.IsEnabled = true;
        }


        /// <summary>
        /// By click of button generate the extended list of changed names
        /// </summary>
        private void btnStep_2_Click(object sender, RoutedEventArgs e)
        {
            ChangedName changedName = new ChangedName();

            ListOfCangedNames = changedName.ChangeParticle(ListOfCangedNames);
            dgListOfNameVersions.ItemsSource = ListOfCangedNames;

            grpBox_Step_3.IsEnabled = true;
        }


        /// <summary>
        /// Filter of the extended list of changed names
        /// </summary>
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            if (txtNamesCollectionFilter.Text == null) return;

            try
            {
                //LINQ Request
                var filter = (from name in ListOfCangedNames
                              where name.IncommingName == (txtNamesCollectionFilter.Text).Trim()
                              select name).First();

                lstFilter.ItemsSource = filter.ParticalChangedName;
            }
            catch (Exception)
            {
                Error error = new Error();
                error.FilterError();
            }
        }


        /// <summary>
        /// Clear the Searchings field and ListView with all variants
        /// </summary>
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtNamesCollectionFilter.Text = null;
            lstFilter.DataContext = null;
            lstFilter.ItemsSource = null;
        }
    }
}
