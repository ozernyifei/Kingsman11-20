using Kingsman20.DB;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    /// Логика взаимодействия для AddServiceWindow.xaml
    /// </summary>
    public partial class AddServiceWindow : Window
    {

        private string pathImage;
        private bool isEdit = false;
        DB.Service editService = null;
        public AddServiceWindow()
        {
            InitializeComponent();

            CmbTypeService.ItemsSource = ClassHelper.EF.Context.ServiceType.ToList();
            CmbTypeService.DisplayMemberPath = "TypeName";
            CmbTypeService.SelectedIndex = 0;
        }

        public AddServiceWindow(DB.Service service)
        {
            InitializeComponent();
            isEdit = true;
            editService = service;

            CmbTypeService.ItemsSource = ClassHelper.EF.Context.ServiceType.ToList();
            CmbTypeService.DisplayMemberPath = "TypeName";

            ImgImageService.Source = new BitmapImage(new Uri(editService.ServicePhoto));
            TbNameService.Text = editService.ServiceName;
            TbDiscService.Text = editService.Description;
            TbPriceService.Text = Convert.ToString(editService.Price);

            CmbTypeService.SelectedItem = ClassHelper.EF.Context.ServiceType.Where(i => i.ID == editService.ServiceTypeID).FirstOrDefault();
        }

        private void BtnChooseImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                ImgImageService.Source = new BitmapImage(new Uri(openFileDialog.FileName));

                pathImage = openFileDialog.FileName;
            }
        }

        private void BtnAddService_Click(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(TbNameService.Text))
            {
                MessageBox.Show("Поле Наименование не заполнено");
                return;
            }
            if (string.IsNullOrWhiteSpace(TbPriceService.Text))
            {
                MessageBox.Show("Поле Стоимость услуги не заполнено");
                return;
            }
            if (!Char.IsDigit(TbPriceService.Text, 0))
            {
                MessageBox.Show("Поле Стоимость услуги не может содержать не цифры");
                return;
            }

            if (isEdit == false)
            {


                DB.Service addService = new DB.Service
                {
                    ServiceName = TbNameService.Text,
                    Price = Convert.ToDecimal(TbPriceService.Text),
                    Description = TbDiscService.Text,
                    ServiceTypeID = (CmbTypeService.SelectedItem as DB.ServiceType).ID
                };
                if (pathImage != null)
                {
                    addService.ServicePhoto = pathImage;
                }

                ClassHelper.EF.Context.Service.Add(addService);
                ClassHelper.EF.Context.SaveChanges();

                MessageBox.Show("Услуга добавлена", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            else
            {

                editService.ServiceName = TbNameService.Text;
                editService.Description = TbDiscService.Text;
                editService.Price = Convert.ToDecimal(TbPriceService.Text);
                editService.ServiceTypeID = (CmbTypeService.SelectedItem as DB.ServiceType).ID;

                ClassHelper.EF.Context.SaveChanges();

                MessageBox.Show("Данные успешно сохранны");

                this.Close();
            }
        }
    }
}
