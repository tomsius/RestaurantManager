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
    public partial class RestaurantManagerForm : Form
    {
        public RestaurantManagerForm()
        {
            InitializeComponent();
        }

        private void manageStockButton_Click(object sender, EventArgs e)
        {
            StockViewerForm form = new StockViewerForm();
            form.Show();
        }

        private void manageMenuButton_Click(object sender, EventArgs e)
        {
            MenuViewerForm form = new MenuViewerForm();
            form.Show();
        }

        private void manageOrdersButton_Click(object sender, EventArgs e)
        {
            OrdersViewerForm form = new OrdersViewerForm();
            form.Show();
        }
    }
}
