using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIA.Menus
{
    public class MainMenu : BaseMenu, IMenu<MainMenuChoices>
    {
        public MainMenuChoices DisplayAndGetChoice()
        {
            var textoMenu = new StringBuilder();
            textoMenu.AppendLine("MENU PRINCIPAL");
            textoMenu.AppendLine("1 - Menu de Lojas");
            textoMenu.AppendLine("");

            textoMenu.Append("Escolha um menu: ");

            Console.Write(textoMenu);
            return Enum.Parse<MainMenuChoices>(Console.ReadLine());
        }
    }
}
