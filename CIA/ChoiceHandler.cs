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

        public ChoiceHandler(StoreMenu storeMenu, ProductMenu productMenu, SalesMenu salesMenu)
        {
            _storeMenu = storeMenu;
            _productMenu = productMenu;
            _salesMenu = salesMenu;
        }

        public void Handle(MainMenuChoices choice)
        {
            Console.Clear();
            switch (choice)
            {
                case MainMenuChoices.StoreMenu:
                    {
                        var storeChoice = _storeMenu.DisplayAndGetChoice();
                        HandleStoreChoice(storeChoice);
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Escolha inválida! Tente novamente.");
                        break;
                    }
            }
        }

        private void HandleStoreChoice(StoreMenuChoices choice)
        {
            switch (choice)
            {
                case StoreMenuChoices.Exit:
                    {
                        break;
                    }
                case StoreMenuChoices.RegisterStore:
                    {
                        _storeMenu.CreateStore();
                        break;
                    }
                case StoreMenuChoices.DeleteStore:
                    {
                        _storeMenu.DeleteStore();
                        break;
                    }
                case StoreMenuChoices.ListStores:
                    {
                        _storeMenu.ListStores();
                        break;
                    }
            }
        }
    }
}
