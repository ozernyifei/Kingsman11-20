﻿using System;
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
using System.Windows.Shapes;

namespace Kingsman20.Windows
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindowTemp.xaml
    /// </summary>
    public partial class RegistrationWindowTemp : Window
    {
        public RegistrationWindowTemp()
        {
            InitializeComponent();
        }
        //private void BtnSignIn_Click(object sender, RoutedEventArgs e)
        //{
        //    // проверка на наличие пользователя
        //    var userAuth = ClassHelper.EF.Context.Client.ToList().
        //        Where(i => i.Login == TbLogin.Text && i.Password == PbPassword.Password).
        //        FirstOrDefault();
        //    if (userAuth != null)
        //    {
        //        // переход на окно список услуг
        //        ServiceWindow serviceWindow = new ServiceWindow();
        //        serviceWindow.Show();
        //        this.Close();
        //    }
        //    else
        //    {
        //        // если пользователь не найден
        //        MessageBox.Show("Пользователя не существует", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        //    }
        //}
        private void BtnReg_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            RegistrationWindowTemp registrationWindow = new RegistrationWindowTemp();
            registrationWindow.Show();
            this.Close();
        }
    }
}
