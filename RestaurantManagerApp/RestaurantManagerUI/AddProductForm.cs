using RestaurantLibrary.Models;
using RestaurantLibrary;
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
    public partial class AddProductForm : Form
    {
        public AddProductForm()
        {
            InitializeComponent();
        }

        private void addProductButton_Click(object sender, EventArgs e)
        {
            if (ValidateFormInputs())
            {
                ProductModel product = new ProductModel(productNameValue.Text, portionCountValue.Text, unitValue.Text, portionSizeValue.Text);

                foreach (var connection in GlobalConfig.Connections)
                {
                    connection.CreateProduct(product);
                }

                SetFieldsToDefaultValues();
            }
            else
            {
                MessageBox.Show("Invalid Form.");
            }
        }

        // TODO - Refactor validation
        private bool ValidateFormInputs()
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

        private void SetFieldsToDefaultValues()
        {
            productNameValue.Text = string.Empty;
            portionCountValue.Text = "0";
            unitValue.Text = string.Empty;
            portionSizeValue.Text = "0";
        }
    }
}
