using Strukov.Pages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Design;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Excel = Microsoft.Office.Interop.Excel;

namespace Strukov
{
    /// <summary>
    /// Логика взаимодействия для AdminPageUsers.xaml
    /// </summary>
    public partial class AdminPageUsers : Page
    {
        public AdminPageUsers()
        {            
            InitializeComponent();
            DataGridUsers.ItemsSource = AppData.Context.USERs.ToList();
        }

        private void BtnAddUser_Click(object sender, RoutedEventArgs e)
        {
            AppData.MainFrame.Navigate(new AdminPageAddUser(null));
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            if (AppData.statusRegistry == true)
            {
                AppData.MainFrame.Navigate(new RegistryPage());
            }
            else
            {
                AppData.MainFrame.Navigate(new AdminPage());
            }            
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridUsers.SelectedItem is USER currentUser)
            {
                NavigationService.Navigate(new AdminPageAddUser(currentUser));
            }
            else
            {
                MessageBox.Show("Выберите пользователя", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите удалить данный баг?", "Сообщение", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    AppData.Context.USERs.Remove((USER)DataGridUsers.SelectedItem);
                    AppData.Context.SaveChanges();
                    DataGridUsers.ItemsSource = AppData.Context.USERs.ToList();
                    MessageBox.Show("Пользователь удалён", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch
                {
                    MessageBox.Show("Пользователь записан на приём. Удаление невозможно", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                
            }
        }

        private void BtnExcel_Click(object sender, RoutedEventArgs e)
        {
            Excel.Application application = new Excel.Application();
            application.Workbooks.Add();
            Excel.Worksheet worksheet = application.ActiveSheet;

            worksheet.Cells[1, 1] = "Id";
            worksheet.Cells[1, 2] = "Name";
            worksheet.Cells[1, 3] = "MiddleNam";
            worksheet.Cells[1, 4] = "Surname";

            var allClients = AppData.Context.USERs.ToList().OrderBy(p => p.Name).ToList();

            for (int i = 0; i < allClients.Count(); i++)
            {
                var currentClient = allClients[i];

                worksheet.Cells[i + 2, 1] = currentClient.id;
                worksheet.Cells[i + 2, 2] = currentClient.Name;
                worksheet.Cells[i + 2, 3] = currentClient.MiddleName;
                worksheet.Cells[i + 2, 4] = currentClient.Surname;
            }

            var directory = new DirectoryInfo("Export");
            if (directory.Exists == false)
            {
                directory.Create();

            }
            worksheet.SaveAs($"{ AppDomain.CurrentDomain.BaseDirectory}Export" + $"\\Export_Clients_{DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss")}.xlsx");
            application.Quit();
            MessageBox.Show("Данные выгружены успешно");
        }
    }
}
