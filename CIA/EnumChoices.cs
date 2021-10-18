using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIA
{
    public enum MainMenuChoices
    {
        Exit,
        StoreMenu,
        ProductMenu,
        CustomerMenu,
        InventoryMenu,
        SalesMenu,
    }

    public enum SubMenuChoices
    {
        Exit,
        Register,
        Delete,
        Update,
        View
    }
}
