using Expense_Tracker.Backend;
using System.Windows;
using System.Windows.Controls;

namespace Expense_Tracker.Frontend
{
    /// <summary>
    /// Interaction logic for AddExpensePage.xaml
    /// </summary>
    public partial class AddExpensePage : Page
    {
        public AddExpensePage()
        {
            InitializeComponent();

            textBoxName.Text = DB_Handler.Count.ToString();
        }

        #region Buttons
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            /*Expense myExpense = new Expense(
                DB_Handler.Count,
                textBoxName.Text,
                float.Parse(textBoxCost.Text),
                ,
                ,
                ,
                (short)comboBoxCategory.SelectedIndex,
                short.Parse(textBoxHour.Text),
                textBoxDetails.Text
                );*/
        }

        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            textBoxName.Text = "Expense name";
            textBoxCost.Text = "13.20";

            comboBoxCategory.SelectedIndex = comboBoxCategory.Items.Count - 1;
            textBoxHour.Text = "16";
            textBoxDetails.Text = "-";
        }
        #endregion
    }
}
