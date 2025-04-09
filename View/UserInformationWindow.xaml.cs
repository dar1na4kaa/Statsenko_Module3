using Statsenko_Module3.Data;
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
    /// Логика взаимодействия для UserInformationWindow.xaml
    /// </summary>
    public partial class UserInformationWindow : Window
    {
        User user { get; set; }
        public UserInformationWindow()
        {
            InitializeComponent();
            user = new User();
            this.DataContext = user;

            Title = "Регистрация пользователя";
            SaveButton.Content = "Сохранить";
        }
        public UserInformationWindow(User user)
        {
            InitializeComponent();
            this.user = user;
            this.DataContext = user;

            Title = "Редактирование пользователя";
            SaveButton.Content = "Изменить";
        }

        private void SaveButtonClick(object sender, RoutedEventArgs e)
        {
            if (UsersData.AddUser(user))
            {
                MessageBox.Show("Пользователь успешно зарегистирован", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("Ошибка регистрации пользователя", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
