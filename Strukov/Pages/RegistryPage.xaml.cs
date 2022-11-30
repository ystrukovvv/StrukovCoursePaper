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

namespace Strukov.Pages
{
    /// <summary>
    /// Логика взаимодействия для RegistryPage.xaml
    /// </summary>
    public partial class RegistryPage : Page
    {
        public RegistryPage()
        {
            AppData.statusRegistry = true;
            InitializeComponent();
        }

        private void btnUsers_Click(object sender, RoutedEventArgs e)
        {
            AppData.MainFrame.Navigate(new AdminPageUsers());
        }

        private void btnRecord_Click(object sender, RoutedEventArgs e)
        {
            AppData.MainFrame.Navigate(new DoctorPage());
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            AppData.statusRegistry = false;
            Properties.Settings.Default.UserId = 0;
            Properties.Settings.Default.Save();
            AppData.MainFrame.Navigate(new AuthorizationPage());
        }
    }
}
