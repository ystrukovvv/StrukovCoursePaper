using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Strukov.Pages
{
    /// <summary>
    /// Логика взаимодействия для AdminPageStatis.xaml
    /// </summary>
    public partial class AdminPageStatis : Page
    {
        Chart chartData = null;
        public AdminPageStatis()
        {
            InitializeComponent();
            chartData = ChartHost.Child as Chart;
            chartData.ChartAreas.Add(new ChartArea
            {
                Name = "Активность пользователей",
            });

            ComboType.ItemsSource = Enum.GetValues(typeof(SeriesChartType));
            PickerStart.SelectedDate = DateTime.Now;
        }

        private void PickerStart_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void UpdateChart()
        {
            chartData.Series.Clear();

            if (PickerStart.SelectedDate.HasValue == true && 
                ComboType.SelectedItem is SeriesChartType currentType)
            {
                chartData.Series.Add(new Series
                {
                    Name = "Колличество новостей в день",
                    ChartType = currentType,
                    IsValueShownAsLabel = true
                });

                var currentSeries = chartData.Series.First();
                var currentAuthors = AppData.Context.AUTHORs.ToList();
                foreach (var author in currentAuthors)
                {
                    var postsForDay = author.NEWS.ToList().Where(p => p.Date == PickerStart.SelectedDate).ToList();
                    currentSeries.Points.AddXY(author.Nickname, postsForDay.Count());
                }
            }
 
        }

        private void ComboType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateChart();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            AppData.MainFrame.Navigate(new AdminPage());
        }
    }
}
