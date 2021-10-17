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
        //private readonly StoreMenu _storeMenu;

        //public ChoiceHandler(StoreMenu storeMenu)
        //{
        //    _storeMenu = storeMenu;
        //}

        public void Handle(MainMenuChoices choice)
        {
            Console.Clear();
            switch (choice)
            {
                case MainMenuChoices.StoreMenu:
                    {
                        StoreMenu.
                        var newChoice = Enum.Parse<StoreMenuChoices>(Console.ReadLine());
                        HandleStoreChoice(newChoice);
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Escolha inválida! Tente novamente.");
                        break;
                    }
            }
        }

        private void HandleStoreChoice(StoreMenuChoices newChoice)
        {
            throw new NotImplementedException();
        }
    }
}
