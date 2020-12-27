using RestaurantLibrary;
using RestaurantLibrary.Logic;
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

            availableIngredients = MenuItemLogic.GetNotUsedIngredients(menuItem);

            selectedIngredients = menuItem.Ingredients;

            WireUpLists();
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

        private void updateMenuItemButton_Click(object sender, EventArgs e)
        {
            if (AreFormInputsValid())
            {
                MenuItemModel newMenuItem = new MenuItemModel(menuItemNameValue.Text, selectedIngredients);

                GlobalConfig.Connection.UpdateMenuItem(menuItem.Id, newMenuItem);

                callingFrom.CompleteMenuItemUpdate(newMenuItem);

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
