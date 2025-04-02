using Statsenko_Module3.Data;
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
using System.Windows.Shapes;

namespace Statsenko_Module3.View
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Login_BthClick(object sender, RoutedEventArgs e)
        {
            if (LoginTextBox.Text.Trim() != "" && PasswordTextBox.Password.Trim() != "")
            {
                var selectedUser = UsersData.GetUsers().FirstOrDefault(user => user.Login == LoginTextBox.Text && user.Password == PasswordTextBox.Password);
                if (selectedUser != null)
                {
                }
                else
                {
                    MessageBox.Show("Вы ввели неверный логин или пароль", "Ошибка авторизации", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
            else
            {
                MessageBox.Show("Введите логин или пароль", "Ошибка ввода данных", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
