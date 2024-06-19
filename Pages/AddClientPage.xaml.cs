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
using Pract_client.Classes;
using Pract_client.DBmodel;
using Pract_client.Pages;

namespace Pract_client.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddClientPage.xaml
    /// </summary>
    public partial class AddClientPage : Page
    {
        public AddClientPage()
        {
            InitializeComponent();
        }
        Client cl = new Client();

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TxtPhone.Text) && string.IsNullOrEmpty(TxtEmail.Text))
            {
                MessageBox.Show("Укажите хотя бы один контакт: телефон или email.");

            }
            else
            {

                cl.Name = TxtName.Text;
                cl.First_Name = TxtSurname.Text;
                cl.Patronomyc = TxtPatronumic.Text;
                cl.Email = TxtEmail.Text;  
                cl.Phone_Number = TxtPhone.Text;
                ConnectionClasses.connect.Client.Add(cl);
                ConnectionClasses.connect.SaveChanges();
                MessageBox.Show($"Клиент добавлен", "Добавление записи", MessageBoxButton.OK, MessageBoxImage.Information);
                NavigationService.Navigate(new ClientPage());
            }
        }

        private void TxtName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !System.Text.RegularExpressions.Regex.IsMatch(e.Text, @"^[а-яА-Яa-zA-Z]+$");
        }

        private void TxtSurname_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !System.Text.RegularExpressions.Regex.IsMatch(e.Text, @"^[а-яА-Яa-zA-Z]+$");
        }

        private void TxtPatronumic_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !System.Text.RegularExpressions.Regex.IsMatch(e.Text, @"^[а-яА-Яa-zA-Z]+$");
        }

        private void TxtPhone_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !System.Text.RegularExpressions.Regex.IsMatch(e.Text, @"^[0-9]+$");
            
        }

        private void TxtLogin_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !System.Text.RegularExpressions.Regex.IsMatch(e.Text, @"^[0-9]+$");
        }

        private void TxtPassword_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !System.Text.RegularExpressions.Regex.IsMatch(e.Text, @"^[0-9]+$");
        }

    }
}

