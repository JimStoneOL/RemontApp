using RemontApp.Data;
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
    /// Логика взаимодействия для CreateOrderPage.xaml
    /// </summary>
    public partial class CreateOrderPage : Page
    {

        List<Data.services> service_list= Data.remontEntities.GetContext().services.ToList();
        public CreateOrderPage()
        {
            InitializeComponent();

            List<string> string_services = new List<string>();
            service_list.ForEach(s => string_services.Add(s.service_id.ToString()));
            service_box.ItemsSource = string_services;

            string services_text = "";
            Classes.Current.currentServices.ForEach(s => services_text += " "+s.name);
            service_label.Content = services_text;

            decimal price = 0;
            Classes.Current.currentServices.ForEach(s => price += s.price.Value);
            price_label.Content = price;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string description = description_text.Text;
            if (Classes.Current.currentServices.Count() > 0)
            {
                Data.orders new_order = new Data.orders()
                {
                    client_id = Classes.Current.currentUser.user_id,
                    price=Decimal.Parse(price_label.Content.ToString()),
                    description=description,
                    is_comleted=false
                };
                Data.remontEntities.GetContext().orders.Add(new_order);
                Data.remontEntities.GetContext().SaveChanges();


                foreach(Data.services serv in Classes.Current.currentServices){
                    Data.order_services new_os = new Data.order_services()
                    {
                        order_id = new_order.order_id,
                        service_id=serv.service_id
                    };
                    Data.remontEntities.GetContext().order_services.Add(new_os);
                    Data.remontEntities.GetContext().SaveChanges();
                }

                MessageBox.Show("Заявка успешно добавлена");

            }
            else
            {
                MessageBox.Show("Нету ниодной услуги");
            }
        }

        private void service_box_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (service_box.SelectedItem != null)
            {
                int service_id = Int32.Parse(service_box.SelectedItem as string);
                Data.services service = Data.remontEntities.GetContext().services.Where(s => s.service_id == service_id).FirstOrDefault();
                MessageBox.Show(service.name);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (service_box.SelectedItem != null)
            {
                int service_id = Int32.Parse(service_box.SelectedItem as string);
                Data.services service = Data.remontEntities.GetContext().services.Where(s => s.service_id == service_id).FirstOrDefault();
                Classes.Current.currentServices.Add(service);
                Classes.Current.currentFrame.Navigate(new Pages.CreateOrderPage());
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Classes.Current.currentServices = new List<services>();
            Classes.Current.currentFrame.Navigate(new Pages.CreateOrderPage());
        }
    }
}
