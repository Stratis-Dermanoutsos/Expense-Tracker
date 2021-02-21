using Expense_Tracker.Frontend;
using System.Windows;
using System.Windows.Input;

namespace Expense_Tracker
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            HideSidePanel();

            frameParent.Content = new ShowAllPage();
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
        }

        private void ShowSidePanel()
        {
            frameParent.Margin = new Thickness(170, 55, 0, 0);

            dockPanelSide.Visibility = Visibility.Visible;
        }
        #endregion
    }
}
