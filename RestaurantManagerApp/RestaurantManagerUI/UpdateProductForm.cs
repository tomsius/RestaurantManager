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
    public partial class UpdateProductForm : Form
    {
        private ProductModel product;

        public UpdateProductForm(ProductModel product)
        {
            InitializeComponent();

            this.product = product;

            InitializeFormFields();
        }

        private void InitializeFormFields()
        {
            productNameValue.Text = product.Name;
            portionCountValue.Text = product.PortionCount.ToString();
            unitValue.Text = product.Unit;
            portionSizeValue.Text = product.PortionSize.ToString();
        }

        private void updateProductButton_Click(object sender, EventArgs e)
        {

        }
    }
}
