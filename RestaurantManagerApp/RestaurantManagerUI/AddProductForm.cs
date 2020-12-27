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
        private IProductRequester callingForm;

        public AddProductForm(IProductRequester caller)
        {
            InitializeComponent();

            callingForm = caller;
        }

        private void addProductButton_Click(object sender, EventArgs e)
        {
            if (AreFormInputsValid())
            {
                ProductModel product = new ProductModel(productNameValue.Text, portionCountValue.Text, unitValue.Text, portionSizeValue.Text);
                
                GlobalConfig.Connection.CreateProduct(product);

                callingForm.CompleteProductCreation(product);

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
