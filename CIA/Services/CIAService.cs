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
        private readonly ChoiceHandler _choiceHandler;

        public CIAService(ChoiceHandler choiceHandler)
        {
            _choiceHandler = choiceHandler;
        }

        public void Start()
        {
            Console.Title = "CIA";

            MainMenuChoices choice;
            do
            {
                MainMenu.Display();
                choice = Enum.Parse<MainMenuChoices>(Console.ReadLine());

                _choiceHandler.Handle(choice);
            } while (choice != 0);
        }

    }
}
