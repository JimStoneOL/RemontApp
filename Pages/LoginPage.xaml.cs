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
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string login = login_text.Text;
                string password = password_text.Text;

                StringBuilder errors = new StringBuilder();

                if (string.IsNullOrEmpty(login))
                {
                    errors.AppendLine("Пустой логин!");
                }
                if (string.IsNullOrEmpty(password))
                {
                    errors.AppendLine("Пустой пароль!");
                }

                if (errors.Length > 0)
                {
                    MessageBox.Show(errors.ToString());
                }
                else
                {
                   if(Data.remontEntities.GetContext().users.Any(u=>u.login==login && u.password == password))
                    {
                        Classes.Current.currentUser = Data.remontEntities.GetContext().users.Where(u => u.login == login && u.password == password).FirstOrDefault();
                        switch (Classes.Current.currentUser.role_id)
                        {
                            case 1:
                                Classes.Current.currentFrame.Navigate(new Pages.ClientPage());
                                break;
                            case 2:
                                Classes.Current.currentFrame.Navigate(new Pages.ExecutorPage());
                                break;
                            case 3:
                                Classes.Current.currentFrame.Navigate(new Pages.ManagerPage());
                                break;
                        }
                        }
                    else
                    {
                        MessageBox.Show("Неправильный логин или пароль");
                    }
                }
                } catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
