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
    /// Логика взаимодействия для RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Page
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try {
                string lastname = lastname_text.Text;
                string firstname = firstname_text.Text;
                string middlename = middlename_text.Text;
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
                    Data.users new_user = new Data.users()
                    {
                        lastname = lastname,
                        firstname = firstname,
                        middlename = middlename,
                        login = login,
                        password = password,
                        role_id=1
                    };
                    Data.remontEntities.GetContext().users.Add(new_user);
                    Data.remontEntities.GetContext().SaveChanges();
                    MessageBox.Show("Успешно зарегистрировались");
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            }
    }
}
