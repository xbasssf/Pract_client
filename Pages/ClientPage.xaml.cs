using Pract_client.Classes;
using Pract_client.DBmodel;
using Pract_client.Windows;
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
    /// Логика взаимодействия для ClientPage.xaml
    /// </summary>
    public partial class ClientPage : Page
    {
        public ClientPage()
        {
            InitializeComponent();
            LvClient.ItemsSource = ConnectionClasses.connect.Client.ToList();
            Refresh();
        }

        public void Refresh()
        {
            LvClient.ItemsSource = null;
            LvClient.ItemsSource = ConnectionClasses.connect.Client.ToList();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Удалить?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
            {
                return;
            }
            else
            {
                var s = (sender as Button).DataContext as DBmodel.Client;
                if (s != null)
                {
                    ConnectionClasses.connect.Client.Remove(s);
                    ConnectionClasses.connect.SaveChanges();
                    Refresh();
                    MessageBox.Show($"Клиент {s.First_Name} {s.Name} {s.Patronomyc} удален", "Удаление", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddClientPage());
            
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            var a = (sender as Button).DataContext as DBmodel.Client;
            NavigationService.Navigate(new EditClientPage(a));
        }

        private void AddIngredientButton_Click(object sender, RoutedEventArgs e)
        {
           
            NavigationService.Navigate(new ClientCabinetPage());
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AuthorizationPage());
        }
    }
}
