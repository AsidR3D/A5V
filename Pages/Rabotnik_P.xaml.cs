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
    /// Логика взаимодействия для Rabotnik.xaml
    /// </summary>
    public partial class Rabotnik_P : Page
    {
        public Rabotnik_P()
        {
            InitializeComponent();
            DataGridRabotnik.ItemsSource = CoreModel.init().Rabotniks.ToList();
        }
        private void Update()
        {
            DataGridRabotnik.ItemsSource = CoreModel.init().Rabotniks.ToList();
        }
        private void Add_Show_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Rabotnik_add(new Rabotnik()));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridRabotnik.SelectedItem == null)
                return;

            Rabotnik data = DataGridRabotnik.SelectedItem as Rabotnik;
            if (MessageBox.Show("Удаление", "Удалить выбранный элемент?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                CoreModel.init().Rabotniks.Remove(data);
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
            if (DataGridRabotnik.SelectedItem == null)
                return;
            NavigationService.Navigate(new Rabotnik_add(DataGridRabotnik.SelectedItem as Rabotnik));
        }
    }
}