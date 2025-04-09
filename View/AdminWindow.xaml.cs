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
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
            ListBoxClients.ItemsSource = UsersData.GetUsers();
        }

        private void AddNewUser_ButtonClick(object sender, RoutedEventArgs e)
        {
            UserInformationWindow userInformationWindow = new UserInformationWindow();
            userInformationWindow.ShowDialog();
        }
        private void EditUser_ButtonClick(object sender, RoutedEventArgs e)
        {
            User user = ListBoxClients.SelectedItem as User;
            UserInformationWindow userInformationWindow = new UserInformationWindow(user);
            userInformationWindow.ShowDialog();
        }
    }
}
