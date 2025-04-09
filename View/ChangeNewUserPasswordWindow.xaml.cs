using Statsenko_Module3.Model;
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
    /// Логика взаимодействия для ChangeNewUserPasswordWindow.xaml
    /// </summary>
    public partial class ChangeNewUserPasswordWindow : Window
    {
        private readonly User _selectedUser;
        public ChangeNewUserPasswordWindow(User selectedUser)
        {
            InitializeComponent();
            _selectedUser = selectedUser;
        }

        private void ChangePassword_BthClick(object sender, RoutedEventArgs e)
        {
            if (OldPasswordTextBox.Text != "" &&
                NewPasswordTextBox.Password != "" &&
                RepeatNewPasswordTextBox.Password != "")
            {
                if (NewPasswordTextBox.Password == RepeatNewPasswordTextBox.Password)
                {
                    if (OldPasswordTextBox.Text == _selectedUser.Password)
                    {
                        if (OldPasswordTextBox.Text != NewPasswordTextBox.Password)
                        {
                            _selectedUser.Password = NewPasswordTextBox.Password;   

                            ClientWindow clientWindow = new ClientWindow(_selectedUser);
                            MessageBox.Show("Пароль успешно изменен", "Изменение пароля", MessageBoxButton.OK, MessageBoxImage.Information);
                            clientWindow.Show();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Текущий пароль не должен совпадать с новым паролем", "Ошибка ввода данных", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Текущий пароль неверный", "Ошибка ввода данных", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Пароли не совпадают", "Ошибка ввода данных", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Вы заполили не все поля", "Ошибка ввода данных", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
