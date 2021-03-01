using Expense_Tracker.Backend;
using System.Windows;
using System.Windows.Controls;

namespace Expense_Tracker.Frontend
{
    public partial class ShowAllPage : Page
    {
        #region Constructors
        public ShowAllPage()
        {
            InitializeComponent();

            /* Load the data */
            DB_Handler.GetAllExpenses(this.listViewExpenses);

            /* Show the total cost */
            double totalCost = DB_Handler.GetTotalCost();
            labelTotal.Content = totalCost.ToString("0.##");

            /* Hide the buttons since no list item is selected on load */
            this.btnEdit.Visibility = Visibility.Hidden;
            this.btnDelete.Visibility = Visibility.Hidden;
        }

        public ShowAllPage(string year)
        {
            InitializeComponent();

            /* Load the data */
            DB_Handler.GetAllExpenses(this.listViewExpenses, year);

            /* Show the total cost */
            double totalCost = DB_Handler.GetTotalCost(year);
            labelTotal.Content = totalCost.ToString("0.##");

            /* Hide the buttons since no list item is selected on load */
            this.btnEdit.Visibility = Visibility.Hidden;
            this.btnDelete.Visibility = Visibility.Hidden;
        }
        #endregion

        #region Buttons
        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            /* Get the Id of the object we want to edit */
            dynamic selectedItem = this.listViewExpenses.SelectedItem;
            uint myId = selectedItem.Id;

            /* Create an Expense object */
            Expense myExpense = DB_Handler.GetExpenseFromId(myId);

            /* Start editing */
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.OpenPage(new AddExpensePage(myExpense));
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            /* Get the Id of the object we want to delete */
            dynamic selectedItem = this.listViewExpenses.SelectedItem;
            uint myId = selectedItem.Id;

            /* Delete the object */
            if (DB_Handler.DeleteExpenseWithId(myId))
                MessageBox.Show("Expense has been deleted successfully!");

            listViewExpenses_Refresh();
        }
        #endregion

        #region <listViewExpenses>
        /* If an item was selected, show the options */
        private void listViewExpenses_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.btnEdit.Visibility = Visibility.Visible;
            this.btnDelete.Visibility = Visibility.Visible;
        }

        /* Refresh our list */
        private void listViewExpenses_Refresh()
        {
            this.listViewExpenses.Items.Clear();
            DB_Handler.GetAllExpenses(this.listViewExpenses);
        }
        #endregion
    }
}
