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
    /// Логика взаимодействия для RegistrationWindowTemp.xaml
    /// </summary>
    public partial class RegistrationWindowTemp : Window
    {
        public RegistrationWindowTemp()
        {
            InitializeComponent();
            CmbGender.ItemsSource = ClassHelper.EF.Context.Gender.ToList();
            CmbGender.DisplayMemberPath = "GenderName";
           
            CmbGender.SelectedIndex = 0;
        }

        private void Tb_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (textBox.Text.Length != 0 && textBox.Text == (string)textBox.Tag)
            {
                textBox.Foreground = Brushes.Black;
                textBox.Text = "";
            }
        }
        private void Tb_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (textBox.Text.Length == 0)
            {
                textBox.Foreground = Brushes.DarkGray;
                textBox.Text = (string)textBox.Tag;
            }
        }
        private void Pb_GotFocus(object sender, RoutedEventArgs e)
        {
            PasswordBox pb = sender as PasswordBox;
            if (pb.Password.Length != 0 && pb.Password == (string) pb.Tag)
            {
                pb.Foreground = Brushes.Black;
                pb.Password = "";
            }
        }
        private void Pb_LostFocus(object sender, RoutedEventArgs e)
        {
            PasswordBox pb = sender as PasswordBox;
            if (pb.Password.Length == 0 )
            {
                pb.Foreground= Brushes.DarkGray;
                pb.Password= (string)pb.Tag;
            }
        }
        private void BtnSignIn_Click(object sender, RoutedEventArgs e)
        {
            // проверка на наличие пользователя
            var userAuth = ClassHelper.EF.Context.Client.ToList().
                Where(i => i.Login == TbLogin.Text && i.Password == PbPassword.Password).
                FirstOrDefault();
            if (userAuth != null)
            {
                // переход на окно список услуг
                ServiceWindow serviceWindow = new ServiceWindow();
                serviceWindow.Show();
                this.Close();
            }
            else
            {
                // если пользователь не найден
                MessageBox.Show("Пользователя не существует", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void BtnSignIn_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            AuthWindow aW = new AuthWindow();
            aW.Show();
            this.Close();
        }
    }
}
