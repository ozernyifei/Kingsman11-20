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
using System.Windows.Shapes;

namespace Kingsman20.Windows
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {

        DB.Employee authEmployee = null;
        DB.Client authClient = null;
        public AuthWindow()
        {
            InitializeComponent();
        }
        private void TbLogin_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (textBox.Text == "Ваш логин")
            {
                textBox.Text = "";
                textBox.Foreground = Brushes.Black;
            }
        }

        private void TbLogin_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Foreground = Brushes.DarkGray;
                textBox.Text = "Ваш логин";
            }
        }

        private void PbPassword_GotFocus(object sender, RoutedEventArgs e)
        {
            PasswordBox passwordBox = sender as PasswordBox;
            if (passwordBox.Password == "Password")
            {
                passwordBox.Password = "";
                passwordBox.Foreground = Brushes.Black;

            }

        }
        private void PbPassword_LostFocus(object sender, RoutedEventArgs e)
        {
            PasswordBox passwordBox = sender as PasswordBox;
            if (string.IsNullOrWhiteSpace(passwordBox.Password))
            {
                passwordBox.Foreground = Brushes.DarkGray;
                passwordBox.Password = "Password";
            }
        }
        private void BtnSignIn_Click(object sender, RoutedEventArgs e)
        {
            if ((string.IsNullOrEmpty(PbPassword.Password) || PbPassword.Password != Convert.ToString(PbPassword.Tag)) && (string.IsNullOrEmpty(TbLogin.Text) || TbLogin.Text != Convert.ToString(TbLogin.Tag)))
            {
                authEmployee = ClassHelper.EF.Context.Employee.ToList().Where(i => i.Password == PbPassword.Password && i.Login == TbLogin.Text).FirstOrDefault();
                authClient = ClassHelper.EF.Context.Client.ToList().Where(i => i.Password == PbPassword.Password && i.Login == TbLogin.Text).FirstOrDefault();

                if (authEmployee != null)
                {
                    MainWindow mainWindow = new MainWindow();
                    this.Close();
                    mainWindow.ShowDialog();

                    ClassHelper.UserDataClass.SavedEmployee = authEmployee;
                }
                else if (authClient != null)
                {

                    MainWindow mainWindow = new MainWindow();
                    this.Close();
                    mainWindow.ShowDialog();

                    ClassHelper.UserDataClass.SavedClient = authClient;
                }
                else
                {
                    // если пользователь не найден
                    MessageBox.Show("Пользователя не существует", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void BtnReg_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            RegistrationWindowTemp registrationWindow = new RegistrationWindowTemp();
            registrationWindow.Show();
            this.Close();
        }
    }
}
