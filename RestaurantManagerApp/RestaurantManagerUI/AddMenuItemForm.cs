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
    public partial class AddMenuItemForm : Form
    {
        private List<ProductModel> availableIngredients = GlobalConfig.Connection.GetAllProducts();
        private List<ProductModel> selectedIngredients = new List<ProductModel>();

        public AddMenuItemForm()
        {
            InitializeComponent();

            //CreateSampleData();
            WireUpLists();
        }

        // TODO - Delete test code
        private void CreateSampleData()
        {
            availableIngredients.Add(new ProductModel { Name = "Potatoes"});
            availableIngredients.Add(new ProductModel { Name = "Tomatoes" });

            selectedIngredients.Add(new ProductModel { Name = "Cabbage" });
            selectedIngredients.Add(new ProductModel { Name = "Coca-Cola" });
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

        private void addIngredientButton_Click(object sender, EventArgs e)
        {
            ProductModel product = (ProductModel)ingredientsDropDown.SelectedItem;

            if (product != null)
            {
                availableIngredients.Remove(product);
                selectedIngredients.Add(product);

                WireUpLists();
            }
        }

        private void removeIngredientButton_Click(object sender, EventArgs e)
        {
            ProductModel product = (ProductModel)ingredientsListBox.SelectedItem;

            if (product != null)
            {
                selectedIngredients.Remove(product);
                availableIngredients.Add(product);

                WireUpLists();
            }
        }

        private void createMenuItemButton_Click(object sender, EventArgs e)
        {
            if (AreFormInputsValid())
            {
                MenuItemModel menuItem = new MenuItemModel(menuItemNameValue.Text, selectedIngredients);

                GlobalConfig.Connection.CreateMenuItem(menuItem);

                // TODO - if we are not closing this form after creation, reset fields
            }
        }

        private bool AreFormInputsValid()
        {
            bool isFormValid = true;

            if (!IsNameValid())
            {
                isFormValid = false;
            }

            if (AreIngredientsEmpty())
            {
                isFormValid = false;
            }

            return isFormValid;
        }

        private bool IsNameValid()
        {
            if (menuItemNameValue.Text.Length == 0)
            {
                return false;
            }

            return true;
        }

        private bool AreIngredientsEmpty()
        {
            if (selectedIngredients.Count == 0)
            {
                return true;
            }

            return false;
        }
    }
}
