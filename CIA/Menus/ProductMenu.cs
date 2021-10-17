using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIA.Menus
{
    public class ProductMenu : BaseMenu, IMenu<ProductMenuChoices>
    {
        public ProductMenuChoices DisplayAndGetChoice()
        {
            StringBuilder textoMenu = new();
            textoMenu.AppendLine($"MENU DE LOJAS {Environment.NewLine}");
            textoMenu.AppendLine("1 - Cadastrar um produto");
            textoMenu.AppendLine("0 - Sair");
            textoMenu.AppendLine("");

            textoMenu.Append("Escolha uma opção: ");

            while (true)
            {
                try
                {
                    Console.Write(textoMenu);
                    return Enum.Parse<ProductMenuChoices>(Console.ReadLine());
                }
                catch (ArgumentException)
                {
                    DisplayInvalidChoice();
                }
            }
        }
    }
}
