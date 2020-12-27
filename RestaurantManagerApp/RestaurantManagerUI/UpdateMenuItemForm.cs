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
    public partial class UpdateMenuItemForm : Form
    {
        private List<ProductModel> allIngredients = GlobalConfig.Connection.GetAllProducts();
        private List<ProductModel> availableIngredients = new List<ProductModel>();
        private List<ProductModel> selectedIngredients = new List<ProductModel>();

        private IMenuItemChanger callingFrom;
        private MenuItemModel menuItem;

        public UpdateMenuItemForm(IMenuItemChanger caller, MenuItemModel menuItem)
        {
            InitializeComponent();

            callingFrom = caller;
            this.menuItem = menuItem;

            InitializeFormFields();
        }

        private void InitializeFormFields()
        {
            menuItemNameValue.Text = menuItem.Name;

            availableIngredients = GetAvailableIngredients();

            selectedIngredients = menuItem.Ingredients;

            WireUpLists();
        }

        private List<ProductModel> GetAvailableIngredients()
        {
            List<ProductModel> output = new List<ProductModel>();

            foreach (ProductModel product in allIngredients)
            {
                bool contains = false;
                foreach (ProductModel ingredient in menuItem.Ingredients)
                {
                    if (product.Id == ingredient.Id)
                    {
                        contains = true;
                        break;
                    }
                }

                if (!contains)
                {
                    output.Add(product);
                }
            }

            return output;
        }

        private void WireUpLists()
        {
            ingredientsDropDown.DataSource = null;
            ingredientsDropDown.DataSource = availableIngredients;
            ingredientsDropDown.DisplayMember = "Name";

            ingredientsListBox.DataSource = null;
            ingredientsListBox.DataSource = selectedIngredients;
            ingredientsListBox.DisplayMember = "Name";
        }
    }
}
