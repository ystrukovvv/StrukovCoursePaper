using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
    /// Interaction logic for RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        private USER currentUser;
        public RegistrationPage()
        {
            InitializeComponent();
            var currentGender = AppData.Context.GENDERs.ToList();

            //занимаем индекс 0 пустым значением
            currentGender.Insert(0, new GENDER
            {
                id = 0,
                GenderName = ""
            });
            ComboGender.ItemsSource = currentGender;
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            AppData.MainFrame.Navigate(new AuthorizationPage());
        }

        private void ComboGender_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var currentGender = ComboGender.SelectedItem as GENDER;
        }

        private void BtnAddUser_Click(object sender, RoutedEventArgs e)
        {
            if (TBoxName.Text == "" && TBoxSurname.Text == "")
            {
                MessageBox.Show("Заполните все обязательные поля", "Ошибка", MessageBoxButton.OK);
            }
            else if (ComboGender.SelectedIndex == 0)
            {
                MessageBox.Show("Выберите пол", "Ошибка", MessageBoxButton.OK);
            }
            else
            {
                var maxid = AppData.Context.USERs.ToList();

                //получаем кол-во элементов списка и прибавляем 1
                int newuserid = Convert.ToInt32(maxid.Count()) + 1;

                //номер роли по умолчанию
                int rol = 3;

                currentUser = new USER
                {
                    id = newuserid,
                    Name = TBoxName.Text,
                    Surname = TBoxSurname.Text,
                    RoleId = rol,
                    Login = TBoxLogin.Text,
                    Password = TBoxPassword.Text,
                    MiddleName = TBoxMiddleName.Text,
                    DateOfBirth = DatePic.SelectedDate,
                    Region = TBoxRegion.Text,
                    Siti = TBoxSiti.Text,
                    Street = TBoxStreet.Text,
                    House = TBoxHouse.Text,
                    Apartament = TBoxApartament.Text,
                    PhoneNumber = TBoxPhone.Text,
                    Passport = TBoxPassport.Text,
                    MedicalRecord = TBoxMedicalRecord.Text,

                    //индекс 0 заняли при инициализации, соответственно можем исходить из выбора 1||2
                    Gender = ComboGender.SelectedIndex
                };
                AppData.Context.USERs.Add(currentUser);
                MessageBox.Show("Вы успешно зарегистрированы", "Сообщение", MessageBoxButton.OK);
            
                AppData.Context.SaveChanges();
                AppData.MainFrame.Navigate(new AuthorizationPage());
            }   
        }
    }
}
