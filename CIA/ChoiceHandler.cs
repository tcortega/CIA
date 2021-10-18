using CIA.Menus;
using CIA.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIA
{
    public class ChoiceHandler
    {
        private readonly StoreMenu _storeMenu;
        private readonly ProductMenu _productMenu;
        private readonly SalesMenu _salesMenu;
        private readonly CustomerMenu _customerMenu;
        private readonly InventoryMenu _inventoryMenu;

        public ChoiceHandler(StoreMenu storeMenu, ProductMenu productMenu, SalesMenu salesMenu, CustomerMenu customerMenu, InventoryMenu inventoryMenu)
        {
            _storeMenu = storeMenu;
            _productMenu = productMenu;
            _salesMenu = salesMenu;
            _customerMenu = customerMenu;
            _inventoryMenu = inventoryMenu;
        }

        public void Handle(MainMenuChoices choice)
        {
            Console.Clear();
            switch (choice)
            {
                case MainMenuChoices.StoreMenu:
                    {
                        var subMenuChoice = _storeMenu.DisplayAndGetChoice();
                        HandleSubMenuChoices(subMenuChoice, _storeMenu);
                        break;
                    }
                case MainMenuChoices.ProductMenu:
                    {
                        var subMenuChoice = _productMenu.DisplayAndGetChoice();
                        HandleSubMenuChoices(subMenuChoice, _productMenu);
                        break;
                    }
                case MainMenuChoices.CustomerMenu:
                    {
                        var subMenuChoice = _customerMenu.DisplayAndGetChoice();
                        HandleSubMenuChoices(subMenuChoice, _customerMenu);
                        break;
                    }
                case MainMenuChoices.InventoryMenu:
                    {
                        var subMenuChoice = _inventoryMenu.DisplayAndGetChoice();
                        HandleSubMenuChoices(subMenuChoice, _inventoryMenu);
                        break;
                    }
                case MainMenuChoices.SalesMenu:
                    {
                        var subMenuChoice = _salesMenu.DisplayAndGetChoice();
                        HandleSubMenuChoices(subMenuChoice, _salesMenu);
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Escolha inválida! Tente novamente.");
                        break;
                    }
            }
        }

        private void HandleSubMenuChoices(SubMenuChoices choice, ISubMenu menu)
        {
            switch (choice)
            {
                case SubMenuChoices.Exit:
                    {
                        break;
                    }
                case SubMenuChoices.Register:
                    {
                        menu.Create();
                        break;
                    }
                case SubMenuChoices.Delete:
                    {
                        menu.Delete();
                        break;
                    }
                case SubMenuChoices.Update:
                    {
                        menu.Update();
                        break;
                    }
                case SubMenuChoices.View:
                    {
                        menu.View();
                        break;
                    }
            }
        }
    }
}
