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
    /// Логика взаимодействия для Medkomissiya_add.xaml
    /// </summary>
    public partial class Medkomissiya_add : Page
    {
        Medkomissiya data;
        public Medkomissiya_add(Medkomissiya Data)
        {
            data = Data;
            DataContext = Data;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(data.Height) ||
                    string.IsNullOrEmpty(data.Weight) ||
                    string.IsNullOrEmpty(data.BloodType) ||
                    string.IsNullOrEmpty(data.VisionLeft) ||
                    string.IsNullOrEmpty(data.VisionRight) ||
                    string.IsNullOrEmpty(data.HearingLeft) ||
                    string.IsNullOrEmpty(data.HearingRight))  throw new Exception("Заполните данные");
                if (data.Id == 0) CoreModel.init().Medkomissiyas.Add(data);
                else CoreModel.init().Medkomissiyas.Update(data);
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