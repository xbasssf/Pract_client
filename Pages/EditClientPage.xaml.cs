using Pract_client.Classes;
using Pract_client.DBmodel;
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

namespace Pract_client.Pages
{
    /// <summary>
    /// Логика взаимодействия для EditClientPage.xaml
    /// </summary>
    public partial class EditClientPage : Page
    {
        DBmodel.Client client;
        public EditClientPage(DBmodel.Client _client)
        {
            InitializeComponent();
            client = _client;
            this.DataContext = client;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (TxtPhone.Text == "" && TxtEmail.Text == "")
            {
                MessageBox.Show("Укажите хотя бы один контакт: телефон или email.");
                return;
            }
            var a = ConnectionClasses.connect.Client.Where(z => z.Id_Client == client.Id_Client).FirstOrDefault();
            a.First_Name = TxtSurname.Text;
            a.Name = TxtName.Text;
            a.Patronomyc = TxtPatronumic.Text;
            a.Email = TxtEmail.Text;
            a.Phone_Number = TxtPhone.Text;
            ConnectionClasses.connect.SaveChanges();
            MessageBox.Show("Изменения сохранены", "Изменения данных", MessageBoxButton.OK, MessageBoxImage.Information);
            
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

        private void TxtPassword_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !System.Text.RegularExpressions.Regex.IsMatch(e.Text, @"^[0-9]+$");
        }
        private void BtnBack_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ClientPage());
        }
    }
}
