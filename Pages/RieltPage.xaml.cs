using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
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
using Pract_client.Windows;

namespace Pract_client.Pages
{
    /// <summary>
    /// Логика взаимодействия для RieltPage.xaml
    /// </summary>
    public partial class RieltPage : Page
    {
        public RieltPage()
        {
            InitializeComponent();
            LvRielt.ItemsSource = ConnectionClasses.connect.Rielt.ToList();
            Refresh();
        }
        public void Refresh()
        {
            LvRielt.ItemsSource = null;
            LvRielt.ItemsSource = ConnectionClasses.connect.Rielt.ToList();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddRieltPage());

        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            var a = (sender as Button).DataContext as DBmodel.Rielt;
            NavigationService.Navigate(new EditRieltPage(a));
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Удалить?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
            {
                return;
            }
            else
            {
                var d = (sender as Button).DataContext as DBmodel.Rielt;
                if (d != null)
                {
                    ConnectionClasses.connect.Rielt.Remove(d);
                    ConnectionClasses.connect.SaveChanges();
                    Refresh();
                    MessageBox.Show($"Работник {d.FirstName} {d.Name} {d.LastName} уволен", "Увольнение", MessageBoxButton.OK, MessageBoxImage.Information);              }
            }
        }

        private void AddIngredientButton_Click(object sender, RoutedEventArgs e)
        {
            
            NavigationService.Navigate(new RieltCabinetPage());
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AuthorizationPage());
        }
    }
}
