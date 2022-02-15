using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace Pizza
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            cb_pizza.Items.Add("Kentucky");
            cb_pizza.Items.Add("Margherita");
            cb_pizza.Items.Add("Pollo");
            cb_pizza.SelectedIndex = 0;

            if (File.Exists("orders.json"))
            {
                lbox.ItemsSource = JsonConvert.DeserializeObject<Order[]>(File.ReadAllText("orders.json"));
            }

            if (File.Exists("orders.json"))
            {
                var orders = JsonConvert.DeserializeObject<Order[]>(File.ReadAllText("orders.json"));
                orders.ToList().ForEach(x => lbox.Items.Add(x));
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var p = new Order(tb_customer.Text, cb_pizza.SelectedItem.ToString(), rb_tomato.IsChecked == true);
            lbox.Items.Add(p);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            List<Order> orders = new List<Order>();
            foreach (var item in lbox.Items)
            {
                orders.Add(item as Order);
            }

            string jsonData = JsonConvert.SerializeObject(orders);
            File.WriteAllText("orders.json",jsonData);
        }
    }

    internal class Order
    {
        private string customer;
        private string? type;
        private bool isTomatoBased;

        public Order(string text, string? v1, bool v2)
        {
            this.customer = text;
            this.type = v1;
            this.isTomatoBased = v2;
        }
        public override string ToString()
        {
            return $"{customer}: {type}";
        }
    }
}
