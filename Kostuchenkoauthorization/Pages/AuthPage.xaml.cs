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

namespace Kostuchenkoauthorization.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        public AuthPage()
        {
            InitializeComponent();
        }

        private void ButtonEnter_OnClick(object sender, RoutedEventArgs e)
        {
            if( string.IsNullOrEmpty(TextBoxLogin.Text) || string.IsNullOrEmpty(PasswordBox.Password))
            {
                MessageBox.Show("Введите логин или пароль!");
                return;
            }

            using (var db = new IS32kostBDEntities()) 
            {
                var users = db.users
                    .AsNoTracking()
                    .FirstOrDefault(u => u.login == TextBoxLogin.Text && u.Password == PasswordBox.Password);

                if (users == null)
                {
                    MessageBox.Show("пользователь с такими данными не найден!");
                    return;
                }

                MessageBox.Show("пользователь успешно войден!");

                switch (users.Role)
                {
                    case "polomoika":
                        NavigationService?.Navigate(new Menu());
                        break;
                    case "мусаромойка":
                        NavigationService?.Navigate(new Menu());
                        break;
                }


            }


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new Page2());
        }
    }
}
