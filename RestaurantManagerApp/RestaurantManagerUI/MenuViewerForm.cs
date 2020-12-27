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
    public partial class MenuViewerForm : Form, IMenuItemRequester, IMenuItemChanger
    {
        private List<MenuItemModel> menuItems = GlobalConfig.Connection.GetAllMenuItems();

        public MenuViewerForm()
        {
            InitializeComponent();

            WireUpLists();
        }

        private void WireUpLists()
        {
            menuItemsListBox.DataSource = null;
            menuItemsListBox.DataSource = menuItems;
            menuItemsListBox.DisplayMember = "DisplayName";
        }

        private void addMenuItemButton_Click(object sender, EventArgs e)
        {
            AddMenuItemForm form = new AddMenuItemForm(this);
            form.Show();
        }

        private void updateMenuItemButton_Click(object sender, EventArgs e)
        {
            MenuItemModel menuItem = (MenuItemModel)menuItemsListBox.SelectedItem;

            UpdateMenuItemForm form = new UpdateMenuItemForm(this, menuItem);
            form.Show();
        }

        public void CompleteMenuItemCreation(MenuItemModel menuItem)
        {
            menuItems.Add(menuItem);

            WireUpLists();
        }

        public void CompleteMenuItemUpdate(MenuItemModel newMenuItem)
        {
            foreach (MenuItemModel menuItem in menuItems)
            {
                if (newMenuItem.Id == menuItem.Id)
                {
                    menuItem.Name = newMenuItem.Name;
                    menuItem.Ingredients = newMenuItem.Ingredients;
                }
            }

            WireUpLists();
        }

        private void removeMenuItemButton_Click(object sender, EventArgs e)
        {
            MenuItemModel menuItem = (MenuItemModel)menuItemsListBox.SelectedItem;

            GlobalConfig.Connection.DeleteMenuItem(menuItem.Id);

            menuItems.Remove(menuItem);

            WireUpLists();
        }
    }
}
