using RestaurantLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagerUI
{
    public interface IMenuItemChanger
    {
        void CompleteMenuItemUpdate(MenuItemModel newMenuItem);
    }
}
