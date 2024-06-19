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
    /// Логика взаимодействия для RieltCabinetPage.xaml
    /// </summary>
    public partial class RieltCabinetPage : Page
    {
        
        public RieltCabinetPage()
        {
            InitializeComponent();
            this.DataContext = MainWindow.rielt;
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
            e.Handled = !System.Text.RegularExpressions.Regex.IsMatch(e.Text, @"^[0-9]+$");
            if (!string.IsNullOrEmpty(TxtShare.Text))
            {
                int value = int.Parse(TxtShare.Text);
                if (value < 0 || value > 100 || TxtShare.Text.Length > 2) // Проверка на диапазон и длину
                {
                    e.Handled = true; // Запретить ввод
                }
            }
        }


       
        private void BtnBack_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        
    }
}
