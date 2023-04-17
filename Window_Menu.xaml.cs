using A5V.Pages;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Shapes;

namespace A5V
{
    /// <summary>
    /// Логика взаимодействия для Window.xaml
    /// </summary>
    public partial class Window_Menu : Window
    {
        public Window_Menu()
        {
            InitializeComponent();
            MySqlConnectionStringBuilder bild = new MySqlConnectionStringBuilder
            {
                Server = "cfif31.ru",
                Port = 3306,
                UserID = "ISPr23-36_VoronyanskijAV",
                Database = "ISPr23-36_VoronyanskijAV_voenkomat",
                Password = "ISPr23-36_VoronyanskijAV",
                CharacterSet = "utf8"

            };
            Trace.WriteLine(bild.ConnectionString);

            //Server = cfif31.ru; Port = 3306; Uder ID = ISPr23-36_VoronyanskijAV; Database = ISPr23-36_VoronyanskijAV_voenkomat; Password = ISPr23-36_VoronyanskijAV; Character Set = utf8 
        }
        private void Show_Rabotnik(object sender, RoutedEventArgs e)
        {
            FrameNav.Navigate(new Rabotnik_P());
        }

        private void Show_Priizvnik(object sender, RoutedEventArgs e)
        {

            FrameNav.Navigate(new Priizvnik_P());
        }

        private void Show_Medkomissiya(object sender, RoutedEventArgs e)
        {
            FrameNav.Navigate(new Medkomissiya_P());

        }
    }
}
