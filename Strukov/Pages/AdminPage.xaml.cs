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
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {

        public AdminPage()
        {
            InitializeComponent();         
        }

        private void btnUsers_Click(object sender, RoutedEventArgs e)
        {
            AppData.MainFrame.Navigate(new AdminPageUsers());
        }

        private void btnRole_Click(object sender, RoutedEventArgs e)
        {
            AppData.MainFrame.Navigate(new AdminPageRole());
        }

        private void btnStatis_Click(object sender, RoutedEventArgs e)
        {
            AppData.MainFrame.Navigate(new AdminPageStatis());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.UserId = 0;
            Properties.Settings.Default.Save();
            AppData.MainFrame.Navigate(new AuthorizationPage());
        }
    }
}
