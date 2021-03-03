using Expense_Tracker.Frontend;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Expense_Tracker
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            HideSidePanel();

            OpenPage(new ShowAllPage());
        }

        #region Side Panel Visibility
        private void TopLeftRect_MouseEnter(object sender, MouseEventArgs e)
        {
            ShowSidePanel();
        }

        private void framePanelParent_MouseEnter(object sender, MouseEventArgs e)
        {
            HideSidePanel();
        }

        private void HideSidePanel()
        {
            dockPanelSide.Visibility = Visibility.Collapsed;

            frameParent.Margin = new Thickness(0, 55, 0, 0);

            /* Hide the important grid row and show the backup - SCALING */
            this.MenuGrid.RowDefinitions[7].Height = new GridLength(0);
            this.MenuGrid.RowDefinitions[13].Height = new GridLength(20, GridUnitType.Star);
        }

        private void ShowSidePanel()
        {
            frameParent.Margin = new Thickness(170, 55, 0, 0);

            dockPanelSide.Visibility = Visibility.Visible;
        }
        #endregion

        #region frameParent - TO BE REMASTERED
        Page activePage;
        public void OpenPage(Page newPage)
        {
            if (this.activePage != null) {
                Page temp = this.activePage;
            }

            this.frameParent.Content = null;

            this.activePage = newPage;
            this.frameParent.Content = this.activePage;

            while (this.frameParent.NavigationService.RemoveBackEntry() != null);
        }
        #endregion

        #region Side menu buttons
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            OpenPage(new AddExpensePage());
        }

        private void ButtonShowAll_Click(object sender, RoutedEventArgs e)
        {
            OpenPage(new ShowAllPage());
        }

        private void ButtonShowYearButton_Click(object sender, RoutedEventArgs e)
        {
            /* Hide backup grid row and show the one we want - SCALING */
            this.MenuGrid.RowDefinitions[13].Height = new GridLength(0);
            this.MenuGrid.RowDefinitions[7].Height = new GridLength(20, GridUnitType.Star);
        }

        private void ButtonShowYear_Click(object sender, RoutedEventArgs e)
        {
            string year = ((ComboBoxItem)comboBoxYear.SelectedItem).Content.ToString();
            OpenPage(new ShowAllPage(year));
        }
        #endregion
    }
}
