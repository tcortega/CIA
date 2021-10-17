using CIA.Core.Entities;
using CIA.Core.Repositories;
using CIA.Menus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIA.Services
{
    public class CIAService
    {
        private readonly MainMenu _mainMenu;
        private readonly ChoiceHandler _choiceHandler;

        public CIAService(MainMenu mainMenu, ChoiceHandler choiceHandler)
        {
            _mainMenu = mainMenu;
            _choiceHandler = choiceHandler;
        }

        public void Start()
        {
            Console.Title = "CIA";

            while (true)
            {
                try
                {
                    var choice = _mainMenu.DisplayAndGetChoice();
                    if (choice == MainMenuChoices.Exit)
                    {
                        break;
                    }

                    _choiceHandler.Handle(choice);
                    Console.Clear();
                }
                catch (ArgumentException)
                {
                    _mainMenu.DisplayInvalidChoice();
                }
            }
        }

    }
}
