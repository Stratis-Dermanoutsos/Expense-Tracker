using Expense_Tracker.Backend;
using System;
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

            DefaultDate();
            DefaultRest();
        }

        #region Buttons
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            try {
                string date = string.Format("{0}-{1}-{2}",
                    ((ComboBoxItem)comboBoxDay.SelectedItem).Content, 
                    ((ComboBoxItem)comboBoxMonth.SelectedItem).Content, 
                    ((ComboBoxItem)comboBoxYear.SelectedItem).Content);

                Expense myExpense = new Expense(
                    DB_Handler.Count,
                    textBoxName.Text,
                    float.Parse(textBoxCost.Text),
                    date,
                    ((ComboBoxItem)comboBoxCategory.SelectedItem).Content.ToString(),
                    short.Parse(textBoxHour.Text),
                    textBoxDetails.Text
                    );

                if (myExpense.HasValidCost && myExpense.HasValidName && myExpense.HasValidHour) {
                    if (DB_Handler.SaveExpense(myExpense))
                        MessageBox.Show("Expense saved successfully!");
                    else
                        MessageBox.Show("There was a problem saving the expense!");
                } else {
                    if (!myExpense.HasValidCost)
                        MessageBox.Show("The cost of an expense must be a positive number.");
                    else if (!myExpense.HasValidName)
                        MessageBox.Show("This is now a valid name for the expense.");
                    else
                        MessageBox.Show("Please, input a correct hour from 0 to 23.");
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            DefaultDate();
            DefaultRest();
        }
        #endregion

        #region Reset fields
        private void DefaultDate()
        {
            DateTime now = DateTime.Now;
            comboBoxDay.SelectedIndex = now.Day - 1;
            comboBoxMonth.SelectedIndex = now.Month - 1;
            bool itemExists = false;
            int i = 0;
            foreach (ComboBoxItem cbi in comboBoxYear.Items) {
                itemExists = cbi.Content.ToString().Equals(now.Year.ToString());
                if (itemExists) {
                    comboBoxYear.SelectedIndex = i;
                    break;
                } else {
                    i++;
                }
            }
        }

        private void DefaultRest()
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
