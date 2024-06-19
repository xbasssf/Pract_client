using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для EditRieltPage.xaml
    /// </summary>
    public partial class EditRieltPage : Page
    {
        DBmodel.Rielt rielt;
        public EditRieltPage(DBmodel.Rielt _rielt)
        {
            InitializeComponent();
            rielt = _rielt;
            this.DataContext = rielt;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TxtSurname.Text) || string.IsNullOrEmpty(TxtName.Text) || string.IsNullOrEmpty(TxtPatronumic.Text))
            {
                MessageBox.Show("Заполните ФИО полностью!!");
            }
            else
            {
                var a = ConnectionClasses.connect.Rielt.Where(z => z.Id_Rielt == rielt.Id_Rielt).FirstOrDefault();
                a.FirstName = TxtSurname.Text;
                a.Name = TxtName.Text;
                a.LastName = TxtPatronumic.Text;
                a.DealShare = Convert.ToInt32(TxtShare.Text);
                ConnectionClasses.connect.SaveChanges();
                MessageBox.Show("Изменения сохранены", "Изменения данных", MessageBoxButton.OK, MessageBoxImage.Information);
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
        private void TxtPassword_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !System.Text.RegularExpressions.Regex.IsMatch(e.Text, @"^[0-9]+$");
        }
        private void BtnBack_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RieltPage());
        }

    }
}
