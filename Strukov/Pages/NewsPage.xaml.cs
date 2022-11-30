using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects.DataClasses;
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
    /// Логика взаимодействия для NewsPage.xaml
    /// </summary>
    public partial class NewsPage : Page
    {
        public NewsPage()
        {
            InitializeComponent();
            var currentAuthor = AppData.Context.AUTHORs.ToList();
            currentAuthor.Insert(0, new AUTHOR
            {
                id = 0,
                Nickname = "Все авторы"
            });
            ComboAuthors.ItemsSource = currentAuthor;
            UpdateItems();
        }

        private void UpdateItems()
        {
            var allNews = AppData.Context.NEWS.ToList();
            if (ComboAuthors.SelectedIndex > 0)
            {
                allNews = allNews.Where(p => p.AUTHOR == ComboAuthors.SelectedItem as AUTHOR).ToList();
            }

            switch (ComboSort.SelectedIndex)
            {
                case 0:
                    allNews = allNews.OrderBy(p => p.Date).ToList();
                    break;
                case 1:
                    allNews = allNews.OrderBy(p => p.Header).ToList();
                    break;
                default:
                    allNews = allNews.OrderBy(p => p.Text).ToList();
                    break;
            }

            if (ItemControl != null)
                ItemControl.ItemsSource = allNews;
        }

        private void ComboAuthors_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateItems();
        }

        private void ComboSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateItems();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            AppData.MainFrame.Navigate(new AuthorizationPage());
        }
    }
}
