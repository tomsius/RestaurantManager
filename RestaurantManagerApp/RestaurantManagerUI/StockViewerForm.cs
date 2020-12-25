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
    public partial class StockViewerForm : Form, IProductRequester
    {
        private List<ProductModel> stock = GlobalConfig.Connection.GetAllProducts();

        public StockViewerForm()
        {
            InitializeComponent();

            WireUpLists();
        }

        private void WireUpLists()
        {
            productsListBox.DataSource = null;
            productsListBox.DataSource = stock;
            productsListBox.DisplayMember = "Name";
        }

        private void addProductButton_Click(object sender, EventArgs e)
        {
            AddProductForm form = new AddProductForm(this);
            form.Show();
        }

        public void CompleteProduct(ProductModel product)
        {
            stock.Add(product);

            WireUpLists();
        }
    }
}
