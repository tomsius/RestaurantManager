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

        public void CompleteMenuItemCreation(MenuItemModel menuItem)
        {
            menuItems.Add(menuItem);

            WireUpLists();
        }

        public void CompleteMenuItemUpdate(MenuItemModel newMenuItem)
        {
            throw new NotImplementedException();
        }
    }
}
