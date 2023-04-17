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
    /// Логика взаимодействия для Medkomissiya.xaml
    /// </summary>
    public partial class Medkomissiya_P : Page
    {
        public Medkomissiya_P()
        {
            InitializeComponent();
            DataGridMedkomissiya.ItemsSource = CoreModel.init().Medkomissiyas.ToList();
        }
        private void Update()
        {
            DataGridMedkomissiya.ItemsSource = CoreModel.init().Medkomissiyas.ToList();
        }
        private void Add_Show_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Medkomissiya_add(new Medkomissiya()));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridMedkomissiya.SelectedItem == null)
                return;

            Medkomissiya data = DataGridMedkomissiya.SelectedItem as Medkomissiya;
            if (MessageBox.Show("Удаление", "Удалить выбранный элемент?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                CoreModel.init().Medkomissiyas.Remove(data);
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
            if (DataGridMedkomissiya.SelectedItem == null)
                return;
            NavigationService.Navigate(new Medkomissiya_add(DataGridMedkomissiya.SelectedItem as Medkomissiya));
        }
    }
}