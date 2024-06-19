using Pract_client.Classes;
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
using Pract_client.Pages;
using Pract_client.DBmodel;


namespace Pract_client.Windows
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public AuthorizationPage()
        {
            InitializeComponent();
        }
        private void BtnAuth_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(TxtLogin.Text) || string.IsNullOrEmpty(PsPassword.Password))
                {
                    MessageBox.Show("Пожалуйста, заполните логин и пароль!!!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    var a = ConnectionClasses.connect.Log_rielt.Where(d => d.Login == TxtLogin.Text && d.Password == PsPassword.Password).FirstOrDefault();
                    if (a != null)
                    {
                        var z = a.Rielt.FirstOrDefault();

                        if (a.Id_log_rielt == a.Id_log_rielt)
                        {

                            MessageBox.Show($"Добро пожаловать {z.FirstName} {z.Name} {z.LastName}", "Автризация прошла успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                            MainWindow.log_Rielt = a;
                            MainWindow.rielt = z;
                            
                            NavigationService.Navigate(new RieltPage());


                        }
                    }
                    else
                    {
                        var c = ConnectionClasses.connect.Log_client.Where(d => d.Login == TxtLogin.Text && d.Password == PsPassword.Password).FirstOrDefault();
                        if (c != null)
                        {
                            var z = c.Client.FirstOrDefault();
                            if (c.Id_log_client == c.Id_log_client)
                            {
                                MessageBox.Show($"Добро пожаловать", "Автризация прошла успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                                MainWindow.log_Client = c;
                                MainWindow.client = z;
                                
                                NavigationService.Navigate(new ClientPage()); // Открываем страницу для клиента
                            }
                        }
                        else
                        {
                            MessageBox.Show("Логин или пароль неверный!!!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Information);

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnClose_Click_1(object sender, RoutedEventArgs e)
        {
            App.Current.MainWindow.Close();
        }
    }
}
