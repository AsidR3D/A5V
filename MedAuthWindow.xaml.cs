using A5V.DB;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
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
    /// Логика взаимодействия для MedAuthWindow.xaml
    /// </summary>
    public partial class MedAuthWindow : Window
    {
        public MedAuthWindow()
        {
            InitializeComponent();
            {
            
            }          
        }
        private void MedEnterButton_Click(object sender, RoutedEventArgs e)
        {
            if (MedLoginTextBox == null && MedPasswordTextBox == null)
            {
                MessageBox.Show("Заполните поля");
                return;
            }
            else
            {
                Rabotnik user = CoreModel.init().Rabotniks.FirstOrDefault(p => p.Name == MedLoginTextBox.Text && (p.Patronymic == MedPasswordTextBox.Text));

                if (user != null)
                {
                    MessageBox.Show("вы вошли");
                    Window_Menu wind = new Window_Menu();
                    wind.Show();
                    Close();
                }
                else 
                {
                    MessageBox.Show("такого пользователя нет!");
                }


            }
        }
    }
}
