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

namespace Pract_client.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddRieltPage.xaml
    /// </summary>
    public partial class AddRieltPage : Page
    {
        public AddRieltPage()
        {
            InitializeComponent();
        }
        Rielt ri = new Rielt();

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TxtSurname.Text) || string.IsNullOrEmpty(TxtName.Text) || string.IsNullOrEmpty(TxtPatronumic.Text))
            {
                MessageBox.Show("Заполните ФИО полностью!!");
            }
            else
            {

                ri.Name = TxtName.Text;
                ri.FirstName = TxtSurname.Text;
                ri.LastName = TxtPatronumic.Text;
                ri.DealShare = Convert.ToInt32(TxtShare.Text);
                ConnectionClasses.connect.Rielt.Add(ri);
                ConnectionClasses.connect.SaveChanges();
                MessageBox.Show($"Риелтор {TxtSurname.Text} {TxtName.Text} {TxtPatronumic.Text} добавлен", "Добавление записи", MessageBoxButton.OK, MessageBoxImage.Information);
                NavigationService.Navigate(new RieltPage());
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

        private void TxtShare_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void TxtLogin_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !System.Text.RegularExpressions.Regex.IsMatch(e.Text, @"^[0-9]+$");
        }

        private void TxtPassword_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {   
            e.Handled = !System.Text.RegularExpressions.Regex.IsMatch(e.Text, @"^[0-9]+$");
        }

        private void TxtShare_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(TxtShare.Text))
            {

            }
            else
            {
                if (Convert.ToInt32(TxtShare.Text) > 100)
                {
                    MessageBox.Show("Доля должна быть больше 0 и меньше 100!!");
                }
            }
        }
    }

}
