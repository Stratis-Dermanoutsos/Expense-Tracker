using Expense_Tracker.Backend;
using System.Windows;
using System.Windows.Controls;

namespace Expense_Tracker.Frontend
{
    /// <summary>
    /// Interaction logic for ShowAllPage.xaml
    /// </summary>
    public partial class ShowAllPage : Page
    {

        public ShowAllPage()
        {
            InitializeComponent();

            DB_Handler.GetAllExpenses(this.listViewExpenses);

            this.btnEdit.Visibility = Visibility.Hidden;
            this.btnDelete.Visibility = Visibility.Hidden;
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            dynamic selectedItem = this.listViewExpenses.SelectedItem;
            uint myId = selectedItem.Id;

            Expense myExpense = DB_Handler.GetExpenseFromId(myId);

            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.OpenPage(new AddExpensePage(myExpense));
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            dynamic selectedItem = this.listViewExpenses.SelectedItem;
            uint myId = selectedItem.Id;

            if (DB_Handler.DeleteExpenseWithId(myId))
                MessageBox.Show("Expense has been deleted successfully!");

            listViewExpenses_Refresh();
        }

        private void listViewExpenses_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.btnEdit.Visibility = Visibility.Visible;
            this.btnDelete.Visibility = Visibility.Visible;
        }

        private void listViewExpenses_Refresh()
        {
            this.listViewExpenses.Items.Clear();
            DB_Handler.GetAllExpenses(this.listViewExpenses);
        }
    }
}
