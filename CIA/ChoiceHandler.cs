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

        public ChoiceHandler(StoreMenu storeMenu)
        {
            _storeMenu = storeMenu;
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
                        //var newStore = StoreMenu
                    break;
                }
            }
        }
    }
}
