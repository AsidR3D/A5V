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
    /// Логика взаимодействия для Priizvnik_add.xaml
    /// </summary>
    public partial class Priizvnik_add : Page
    {
        Priizvnik data;
        public Priizvnik_add(Priizvnik Data)
        {
            data = Data;
            DataContext = Data;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(data.Name) ||
                    string.IsNullOrEmpty(data.Surname) ||
                    string.IsNullOrEmpty(data.Patronymic) ||
                    string.IsNullOrEmpty(data.Address) ||
                    string.IsNullOrEmpty(data.Phone) ||
                    string.IsNullOrEmpty(data.Email) ||
                    string.IsNullOrEmpty(data.Password) ||
                    string.IsNullOrEmpty(data.Education) ||
                    string.IsNullOrEmpty(data.Profession) ||
                    string.IsNullOrEmpty(data.MaritalStatus))
                    throw new Exception("Заполните данные");
                if (data.Id == 0) CoreModel.init().Priizvniks.Add(data);
                else CoreModel.init().Priizvniks.Update(data);
                CoreModel.init().SaveChanges();
                NavigationService.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Результат", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (data.Id != 0)
            {
                CoreModel.init().Entry(data).Reload();
            }
        }
    }
}