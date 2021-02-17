﻿using Expense_Tracker.Frontend;
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

namespace Expense_Tracker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            HideSidePanel();

            frameParent.Content = new AddExpensePage();
        }


        #region Side Panel Visibility
        private void TopLeftRect_MouseEnter(object sender, MouseEventArgs e)
        {
            ShowSidePanel();
        }

        private void stackPanelParent_MouseEnter(object sender, MouseEventArgs e)
        {
            HideSidePanel();
        }

        private void HideSidePanel()
        {
            dockPanelSide.Visibility = Visibility.Collapsed;

            stackPanelParent.Margin = new Thickness(0, 55, 0, 0);
        }

        private void ShowSidePanel()
        {
            stackPanelParent.Margin = new Thickness(170, 55, 0, 0);

            dockPanelSide.Visibility = Visibility.Visible;
        }
        #endregion
    }
}
