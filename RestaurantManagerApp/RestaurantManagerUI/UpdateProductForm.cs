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
            if (AreFormInputsValid())
            {
                ProductModel newProduct = new ProductModel(productNameValue.Text, portionCountValue.Text, unitValue.Text, portionSizeValue.Text);

                GlobalConfig.Connection.UpdateProduct(product.Id, newProduct);

                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid Form.");
            }
        }

        private bool AreFormInputsValid()
        {
            bool isFormValid = true;

            if (!IsNameValid())
            {
                isFormValid = false;
            }

            if (!IsPortionCountValid())
            {
                isFormValid = false;
            }

            if (!IsUnitValid())
            {
                isFormValid = false;
            }

            if (!IsPortionSizeValid())
            {
                isFormValid = false;
            }

            return isFormValid;
        }

        private bool IsNameValid()
        {
            if (productNameValue.Text.Length == 0)
            {
                return false;
            }

            return true;
        }

        private bool IsPortionCountValid()
        {
            int portionCount = 0;
            bool isPortionCountValid = int.TryParse(portionCountValue.Text, out portionCount);

            if (!isPortionCountValid)
            {
                return false;
            }

            if (portionCount < 1)
            {
                return false;
            }

            if (portionCountValue.Text.Length == 0)
            {
                return false;
            }

            return true;
        }

        private bool IsUnitValid()
        {
            if (unitValue.Text.Length == 0)
            {
                return false;
            }

            return true;
        }

        private bool IsPortionSizeValid()
        {
            double portionSize = 0.0;
            bool isPortionSizeValid = double.TryParse(portionSizeValue.Text, out portionSize);

            if (!isPortionSizeValid)
            {
                return false;
            }

            if (portionSize < 0)
            {
                return false;
            }

            if (portionSizeValue.Text.Length == 0)
            {
                return false;
            }

            return true;
        }
    }
}
