using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIA.Menus
{
    public class StoreMenu : BaseMenu, IMenu<StoreMenuChoices>
    {
        public StoreMenuChoices DisplayAndGetChoice()
        {
            StringBuilder textoMenu = new();
            textoMenu.AppendLine($"MENU DE LOJAS {Environment.NewLine}");
            textoMenu.AppendLine("1 - Cadastrar uma loja");
            textoMenu.AppendLine("0 - Sair");

            while (true)
            {
                try
                {
                    Console.WriteLine(textoMenu);
                    return Enum.Parse<StoreMenuChoices>(Console.ReadLine());
                }
                catch (ArgumentException)
                {
                    DisplayInvalidChoice();
                }
            }
        }
    }
}
