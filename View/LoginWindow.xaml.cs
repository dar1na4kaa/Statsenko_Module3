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
        private string userLogin = "";
        private int attemptLogin = 0;
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Login_BthClick(object sender, RoutedEventArgs e)
        {
            if (LoginTextBox.Text.Trim() != "" && PasswordTextBox.Password.Trim() != "")
            {
                var selectedUser = UsersData.GetUsers().FirstOrDefault(user => user.Login == LoginTextBox.Text);
                if (selectedUser != null)
                {
                    if (selectedUser.Password == PasswordTextBox.Password)
                    {
                        if (selectedUser.Status != Model.UserStatus.Blocked)
                        {
                            if ((selectedUser.LastDateLogin >= DateTime.Now.AddMonths(-1) || selectedUser.LastDateLogin == null) && attemptLogin <3)
                            {
                                switch (selectedUser.Role)
                                {
                                    case Model.UserRole.Admin:

                                        break;

                                    case Model.UserRole.Client:
                                        if(selectedUser.LastDateLogin == null)
                                        {
                                            ChangeNewUserPasswordWindow changeNewUserPasswordWindow = new ChangeNewUserPasswordWindow(selectedUser);
                                            changeNewUserPasswordWindow.Show();
                                            this.Close();
                                        }
                                        else
                                        {
                                            selectedUser.LastDateLogin = DateTime.Now;
                                            ClientWindow clientWindow = new ClientWindow();
                                            clientWindow.Show();
                                            this.Close();
                                        }
                                        break;
                                }
                            }
                            else
                            {
                                selectedUser.Status = Model.UserStatus.Blocked;
                                MessageBox.Show("Вы заблокированы. Обратитесь к администратору", "Ошибка о блокировке", MessageBoxButton.OK, MessageBoxImage.Information);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Вы заблокированы. Обратитесь к администратору", "Ошибка о блокировке", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }
                    else
                    {
                        if (userLogin != selectedUser.Login)
                        {
                            userLogin = selectedUser.Login;
                            attemptLogin = 0;
                        }
                        attemptLogin++;
                        MessageBox.Show($"Вы ввели неверный пароль. До блокировки аккаунта {3-attemptLogin} попыток", "Ошибка авторизации", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Вы ввели неверный логин", "Ошибка авторизации", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Введите логин или пароль", "Ошибка ввода данных", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }
    }
}
