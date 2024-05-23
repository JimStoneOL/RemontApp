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

namespace RemontApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для ClientPage.xaml
    /// </summary>
    public partial class ClientPage : Page
    {
        public ClientPage()
        {
            InitializeComponent();

            int hours=DateTime.Now.Hour;
            string fio = Classes.Current.currentUser.lastname + " " + Classes.Current.currentUser.firstname + " " + Classes.Current.currentUser.middlename;

            if (hours > 0 && hours<=6)
            {
                greetings.Content = "Доброй ночи "+fio;
            } else if (hours > 6 && hours <= 12)
            {
                greetings.Content = "Доброго утра " + fio;
            }
            else if (hours > 12 && hours <= 18)
            {
                greetings.Content = "Доброго дня " + fio;
            }
            else
            {
                greetings.Content = "Доброго вечера " + fio;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Classes.Current.currentFrame.Navigate(new Pages.ClientOrderPage());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Classes.Current.currentFrame.Navigate(new Pages.CreateOrderPage());
        }
    }
}
