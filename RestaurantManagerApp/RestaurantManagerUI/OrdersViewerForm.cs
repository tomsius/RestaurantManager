using RestaurantLibrary;
using RestaurantLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantManagerUI
{
    public partial class OrdersViewerForm : Form, IOrderRequester
    {
        private List<OrderModel> orders = GlobalConfig.Connection.GetAllOrders();

        public OrdersViewerForm()
        {
            InitializeComponent();

            WireUpLists();
        }

        private void WireUpLists()
        {
            ordersListBox.DataSource = null;
            ordersListBox.DataSource = orders;
            ordersListBox.DisplayMember = "DisplayName";
        }

        private void createOrderButton_Click(object sender, EventArgs e)
        {
            AddOrderForm form = new AddOrderForm(this);
            form.Show();
        }

        public void CompleteOrderCreation(OrderModel order)
        {
            orders.Add(order);

            WireUpLists();
        }
    }
}
