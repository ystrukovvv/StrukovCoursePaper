using Strukov.Pages;
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

namespace Strukov
{
    /// <summary>
    /// Логика взаимодействия для DoctorPage.xaml
    /// </summary>
    public partial class DoctorPage : Page
    {
        public DoctorPage()
        {
            InitializeComponent();

            if (AppData.statusRegistry == true)
            {
                BtnBack.Content = "Назад";
            }

            DataGridUsers.ItemsSource = AppData.Context.RECEPTIONs.ToList();
        }
        
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            if (AppData.statusRegistry == true)
            {
                AppData.MainFrame.Navigate(new RegistryPage());
            }
            else
            {
                Properties.Settings.Default.UserId = 0;
                Properties.Settings.Default.Save();
                AppData.MainFrame.Navigate(new AuthorizationPage());
            }
            
        }

        private void BtnAddRecording_Click(object sender, RoutedEventArgs e)
        {
            AppData.MainFrame.Navigate(new DoctorPageAddRecord(null));
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {

            if (DataGridUsers.SelectedItem is RECEPTION currentRecord)
            {
                NavigationService.Navigate(new DoctorPageAddRecord(currentRecord));
            }
            else
            {
                MessageBox.Show("Выберите запись", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите удалить данную запись на приём?", "Сообщение", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    AppData.Context.RECEPTIONs.Remove((RECEPTION)DataGridUsers.SelectedItem);
                    AppData.Context.SaveChanges();
                    DataGridUsers.ItemsSource = AppData.Context.RECEPTIONs.ToList();
                    MessageBox.Show("Запись на приём удалёна", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch
                {
                    MessageBox.Show("Ошибка", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                }

            }
        }
    }
}
