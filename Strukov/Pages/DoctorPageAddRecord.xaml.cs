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
    /// Логика взаимодействия для DoctorPageAddRecord.xaml
    /// </summary>
    public partial class DoctorPageAddRecord : Page
    {
        private RECEPTION currentRecord;
        public DoctorPageAddRecord(RECEPTION selectedUser)
        {
            InitializeComponent();

            if (selectedUser != null)
            {
                BtnAddRecord.Content = "Изменить";
                TBlockInfo.Text = "Редактирование пользователя";

                currentRecord = selectedUser;

                TBoxId.Text = currentRecord.id.ToString();
                TBoxCabinet.Text = currentRecord.Cabinet.ToString();
                TBoxDoctor.Text = currentRecord.Doctor.ToString();
                TBoxPatient.Text = currentRecord.Patient.ToString();
                DateRecord.Text = currentRecord.RecordingDate.ToString();
                TBoxPrice.Text = currentRecord.Price.ToString();          
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            AppData.MainFrame.Navigate(new DoctorPage());
        }

        private void BtnAddRecord_Click(object sender, RoutedEventArgs e)
        {
            if (TBoxId.Text == "" && TBoxCabinet.Text == "" && TBoxDoctor.Text == "" && TBoxPatient.Text == "" && TBoxPrice.Text == "")
            {
                MessageBox.Show("Заполните все поля", "Ошибка", MessageBoxButton.OK);
            }

            else
            {
                if (currentRecord != null)
                {
                    currentRecord.id = Convert.ToInt32(TBoxId.Text);
                    currentRecord.Cabinet = Convert.ToInt32(TBoxCabinet.Text);
                    currentRecord.Doctor = Convert.ToInt32(TBoxDoctor.Text);
                    currentRecord.Patient = Convert.ToInt32(TBoxPatient.Text);
                    currentRecord.RecordingDate = (DateTime)DateRecord.SelectedDate;
                    currentRecord.Price = Convert.ToInt32(TBoxPrice.Text);


                    MessageBox.Show("Пользователь успешно отредактирован", "Сообщение", MessageBoxButton.OK);
                }
                else
                {
                    currentRecord = new RECEPTION
                    {
                        id = Convert.ToInt32(TBoxId.Text),
                        Cabinet = Convert.ToInt32(TBoxCabinet.Text),
                        Doctor = Convert.ToInt32(TBoxDoctor.Text),
                        Patient = Convert.ToInt32(TBoxPatient.Text),
                        RecordingDate = (DateTime)DateRecord.SelectedDate,
                        Price = Convert.ToInt32(TBoxPrice.Text),

                    };
                    AppData.Context.RECEPTIONs.Add(currentRecord);
                    MessageBox.Show("Пользователь успешно добавлен", "Сообщение", MessageBoxButton.OK);
                }

                AppData.Context.SaveChanges();
                NavigationService.GoBack();
            }


            


            
        }
    }
}
