﻿using Kingsman20.Windows;
using Kingsman20.Windows.Admin;
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

namespace Kingsman20
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            if (ClassHelper.UserDataClass.SavedEmployee != null)
            {
                switch (ClassHelper.UserDataClass.SavedEmployee.PositionID)
                {
                    case 1:
                        {

                            break;
                        }
                    case 2:
                        {
                            BtnReportList.Visibility = Visibility.Collapsed;
                            break;
                        }
                    case 3:
                        {
                            BtnReportList.Visibility = Visibility.Collapsed;
                            break;
                        }
                    default:
                        break;
                }
            }
        }

        private void BtnEmployeeList_Click(object sender, RoutedEventArgs e)
        {
            EmployeeWindow employeeWindow = new EmployeeWindow();
            this.Hide();
            employeeWindow.ShowDialog();
            this.Show();
        }

        private void BtnClientList_Click(object sender, RoutedEventArgs e)
        {
            ClientWindow clientWindow = new ClientWindow();
            this.Hide();
            clientWindow.ShowDialog();
            this.Show();
        }

        private void BtnServiceList_Click(object sender, RoutedEventArgs e)
        {
            ServiceWindow serviceWindow = new ServiceWindow();
            this.Hide();
            serviceWindow.ShowDialog();
            this.Show();
        }

        private void BtnReportsList_Click(object sender, RoutedEventArgs e)
        {
            ReportWindow reportWindow = new ReportWindow();
            this.Hide();
            reportWindow.ShowDialog();
            this.Show();
        }
    }
}
//
