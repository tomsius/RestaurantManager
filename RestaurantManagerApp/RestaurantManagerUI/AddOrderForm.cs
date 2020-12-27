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
    public partial class AddOrderForm : Form
    {
        private List<MenuItemModel> availableMenuItems = GlobalConfig.Connection.GetAllMenuItems();
        private List<MenuItemModel> selectedMenuItems = new List<MenuItemModel>();

        private IOrderRequester callingForm;

        public AddOrderForm(IOrderRequester caller)
        {
            InitializeComponent();

            callingForm = caller;

            WireUpLists();
        }

        private void WireUpLists()
        {
            menuItemsDropDown.DataSource = null;
            menuItemsDropDown.DataSource = availableMenuItems;
            menuItemsDropDown.DisplayMember = "Name";

            menuItemsListBox.DataSource = null;
            menuItemsListBox.DataSource = selectedMenuItems;
            menuItemsListBox.DisplayMember = "Name";
        }

        private void addMenuItemButton_Click(object sender, EventArgs e)
        {
            MenuItemModel menuItem = (MenuItemModel)menuItemsDropDown.SelectedItem;

            if (menuItem != null)
            {
                availableMenuItems.Remove(menuItem);
                selectedMenuItems.Add(menuItem);

                WireUpLists();
            }
        }

        private void removeMenuItemButton_Click(object sender, EventArgs e)
        {
            MenuItemModel menuItem = (MenuItemModel)menuItemsListBox.SelectedItem;

            if (menuItem != null)
            {
                selectedMenuItems.Remove(menuItem);
                availableMenuItems.Add(menuItem);

                WireUpLists();
            }
        }

        private void createOrderButton_Click(object sender, EventArgs e)
        {
            if (AreFormInputsValid())
            {
                OrderModel order = new OrderModel(DateTime.Today, selectedMenuItems);
                OrderLogic.ReduceProductsInStock(selectedMenuItems);

                order = GlobalConfig.Connection.CreateOrder(order);

                callingForm.CompleteOrderCreation(order);

                this.Close();
            }
            else
            {
                MessageBox.Show("Not enough products in stock.");
            }
        }

        private bool AreFormInputsValid()
        {
            if (OrderLogic.AreOrderedMenuItemsProductsInStock(selectedMenuItems))
            {
                return true;
            }

            return false;
        }
    }
}
