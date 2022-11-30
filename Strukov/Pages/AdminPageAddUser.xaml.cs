using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.VisualStyles;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Strukov.Pages
{
    /// <summary>
    /// Логика взаимодействия для AdminPageAddUser.xaml
    /// </summary>
    public partial class AdminPageAddUser : Page
    {
        private USER currentUser;
        public AdminPageAddUser(USER selectedUser)
        {
            InitializeComponent();

            if (selectedUser != null)
            {
                BtnAddUser.Content = "Изменить";
                TBlockInfo.Text = "Редактирование бага";

                currentUser = selectedUser;

                TBoxId.Text = currentUser.id.ToString();
                TBoxName.Text = currentUser.Name;
                TBoxSurname.Text = currentUser.Surname;
          
            }
        }

 

        private void BtnAddUser_Click(object sender, RoutedEventArgs e)
        {
            

            if (TBoxId.Text == "" && TBoxName.Text == "" && TBoxSurname.Text == "")
            {
                MessageBox.Show("Заполните все обязательные поля", "Ошибка", MessageBoxButton.OK);
            }


            if(currentUser != null)
            {
                currentUser.id = Convert.ToInt32(TBoxId.Text);
                currentUser.Name = TBoxName.Text;
                currentUser.Surname = TBoxSurname.Text;
      

                MessageBox.Show("Пользователь успешно отредактирован", "Сообщение", MessageBoxButton.OK);
            }
            else
            {
                currentUser = new USER
                {
                    id = Convert.ToInt32(TBoxId.Text),
                    Name = TBoxName.Text,
                    Surname = TBoxSurname.Text,
               
                };
                AppData.Context.USERs.Add(currentUser);
                MessageBox.Show("Пользователь успешно добавлен", "Сообщение", MessageBoxButton.OK);
            }

            
            AppData.Context.SaveChanges();
            NavigationService.GoBack();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            AppData.MainFrame.Navigate(new AdminPageUsers());
        }

    }
}
