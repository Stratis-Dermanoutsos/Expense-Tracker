using Expense_Tracker.Backend;
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
        }
    }
}
