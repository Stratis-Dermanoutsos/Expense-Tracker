using Expense_Tracker.Backend;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace Expense_Tracker.Frontend
{
    /// <summary>
    /// Interaction logic for AddExpensePage.xaml
    /// </summary>
    public partial class AddExpensePage : Page
    {
        Expense currentExpense;

        public AddExpensePage(Expense expToEdit)
        {
            InitializeComponent();

            this.currentExpense = expToEdit;

            DefaultDate();
            DefaultRest();
        }

        public AddExpensePage()
        {
            InitializeComponent();

            this.currentExpense = null;

            DefaultDate();
            DefaultRest();
        }

        #region Buttons
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            try {
                string date = string.Format("{0}-{1}",
                    int.Parse(((ComboBoxItem)comboBoxDay.SelectedItem).Content.ToString()).ToString("00"),
                    int.Parse(((ComboBoxItem)comboBoxMonth.SelectedItem).Content.ToString()).ToString("00"));

                Expense myExpense = new Expense(
                    (this.currentExpense == null) ? DB_Handler.Count : this.currentExpense.Id,
                    textBoxName.Text,
                    float.Parse(textBoxCost.Text),
                    date,
                    uint.Parse(((ComboBoxItem)comboBoxYear.SelectedItem).Content.ToString()),
                    ((ComboBoxItem)comboBoxCategory.SelectedItem).Content.ToString(),
                    short.Parse(textBoxHour.Text),
                    textBoxDetails.Text
                    );

                if (myExpense.HasValidCost && myExpense.HasValidName && myExpense.HasValidHour) {
                    bool result = (this.currentExpense == null) ? DB_Handler.SaveExpense(myExpense) : DB_Handler.UpdateExpense(myExpense);
                    if (result) {
                        MessageBox.Show("Expense saved successfully!");

                        MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
                        mainWindow.OpenPage(new ShowAllPage());
                    } else
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
            if (this.currentExpense == null) {
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
            } else {
                DateTime then = DateTime.ParseExact(this.currentExpense.Date, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                comboBoxDay.SelectedIndex = then.Day - 1;
                comboBoxMonth.SelectedIndex = then.Month - 1;
                bool itemExists = false;
                int i = 0;
                foreach (ComboBoxItem cbi in comboBoxYear.Items) {
                    itemExists = cbi.Content.ToString().Equals(then.Year.ToString());
                    if (itemExists) {
                        comboBoxYear.SelectedIndex = i;
                        break;
                    } else {
                        i++;
                    }
                }
            }
        }

        private void DefaultRest()
        {
            if (this.currentExpense == null) {
                textBoxName.Text = "Expense name";
                textBoxCost.Text = "13.20";
                comboBoxCategory.SelectedIndex = comboBoxCategory.Items.Count - 1;
                textBoxHour.Text = "16";
                textBoxDetails.Text = "-";
            } else {
                textBoxName.Text = this.currentExpense.Name;
                textBoxCost.Text = this.currentExpense.Cost.ToString();
                comboBoxCategory.SelectedIndex = this.currentExpense.CategoryIndex;
                textBoxHour.Text = this.currentExpense.Hour.ToString();
                textBoxDetails.Text = this.currentExpense.Details;
            }
        }
        #endregion
    }
}
