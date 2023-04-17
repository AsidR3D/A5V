using A5V.DB;
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

namespace A5V.Pages
{
    /// <summary>
    /// Логика взаимодействия для Priizvnik.xaml
    /// </summary>
    public partial class Priizvnik_P : Page
    {
        public Priizvnik_P()
        {
            InitializeComponent();
            DataGridPriizvnik.ItemsSource = CoreModel.init().Priizvniks.ToList();
        }
        private void Update()
        {
            DataGridPriizvnik.ItemsSource = CoreModel.init().Priizvniks.ToList();
        }
        private void Add_Show_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Priizvnik_add(new Priizvnik()));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridPriizvnik.SelectedItem == null)
                return;

            Priizvnik data = DataGridPriizvnik.SelectedItem as Priizvnik;
            if (MessageBox.Show("Удаление", "Удалить выбранный элемент?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                CoreModel.init().Priizvniks.Remove(data);
                CoreModel.init().SaveChanges();
                Update();
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            Update();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (DataGridPriizvnik.SelectedItem == null)
                return;
            NavigationService.Navigate(new Priizvnik_add(DataGridPriizvnik.SelectedItem as Priizvnik));
        }
    }
}