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

        public AddOrderForm()
        {
            InitializeComponent();

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
    }
}
