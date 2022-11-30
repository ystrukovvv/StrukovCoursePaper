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
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public AuthorizationPage()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxLogin.Text != "")
            {
                if (PasswordBox.Password != "")
                {
                    var currentUser = AppData.Context.USERs.ToList().Where(p => p.Login == TextBoxLogin.Text).FirstOrDefault();
                    if (currentUser != null)
                    {
                        if (currentUser.Password == PasswordBox.Password)
                        {
                            NavigateUser(currentUser);
                        }
                        else
                        {
                            MessageBox.Show("Пароль указан не верно!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Указанного пользователя не существует!");
                    }

                }
                else
                {
                    MessageBox.Show("Введите пароль!");
                }
            }
            else
            {
                MessageBox.Show("Введите логин!");
            }           

        }

        private void NavigateUser(USER currentUser)
        {
            if (currentUser.RoleId == 1)
            {
                SaveUser(currentUser.id, CheckBox.IsChecked.Value);
                AppData.MainFrame.Navigate(new AdminPage());
            }
            if (currentUser.RoleId == 2)
            {
                SaveUser(currentUser.id, CheckBox.IsChecked.Value);
                AppData.MainFrame.Navigate(new DoctorPage());
            }
            if (currentUser.RoleId == 3)
            {
                SaveUser(currentUser.id, CheckBox.IsChecked.Value);
                AppData.MainFrame.Navigate(new UserPage());
            }
            if (currentUser.RoleId == 4)
            { 
                SaveUser(currentUser.id, CheckBox.IsChecked.Value);
                AppData.MainFrame.Navigate(new RegistryPage());
            }
        }

        private void SaveUser(int id, bool isChecked)
        {
            if (isChecked)
            {
                Properties.Settings.Default.UserId = id;
                Properties.Settings.Default.Save();
            }
            
        }

        private void btnNews_Click(object sender, RoutedEventArgs e)
        {
            AppData.MainFrame.Navigate(new NewsPage());
        }

        private void btnReg_Click(object sender, RoutedEventArgs e)
        {
            AppData.MainFrame.Navigate(new RegistrationPage());
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var usid = Properties.Settings.Default.UserId;
            if (usid > 0)
            {
                var currentUser = AppData.Context.USERs.ToList().FirstOrDefault(p => p.id == usid);
                if (currentUser != null)
                {
                    NavigateUser(currentUser);
                }
            }
        }
    }
}
