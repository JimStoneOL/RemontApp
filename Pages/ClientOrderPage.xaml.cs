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
    /// Логика взаимодействия для ClientOrderPage.xaml
    /// </summary>
    public partial class ClientOrderPage : Page
    {
        List<orders> orderList=Data.remontEntities.GetContext().orders.Where(o=>o.client_id==Classes.Current.currentUser.user_id).ToList();
        public ClientOrderPage()
        {
            InitializeComponent();

            List<string> string_orders = new List<string>();
            orderList.ForEach(o => string_orders.Add(o.order_id.ToString()));
            order_box.ItemsSource= string_orders;


        }

        private void order_box_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (order_box.SelectedItem != null)
            {
                int order_id=Int32.Parse(order_box.SelectedItem as string);
                Data.orders order = Data.remontEntities.GetContext().orders.Where(o => o.order_id == order_id).FirstOrDefault();
                MessageBox.Show(order.ToString());
            }
        }
    }
}
