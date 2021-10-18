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
        StoreMenu
    }

    public enum StoreMenuChoices
    {
        Exit,
        RegisterStore,
        DeleteStore,
        ListStores
    }

    public enum ProductMenuChoices
    {
        Exit,
        RegisterProduct,
        DeleteProduct,
        UpdateProduct,
        ViewProducts
    }

    public enum SalesMenuChoices
    {
        Exit,
        RegisterSale,
        DeleteSale,
        UpdateSale,
        ViewSales
    }

    public enum InventoryMenuChoices
    {
        Exit,
        RegisterInventory,
        DeleteInventory,
        UpdateInventory,
        ViewInventories
    }
}
