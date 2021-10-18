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
            textoMenu.AppendLine("==== MENU PRINCIPAL ====");
            textoMenu.AppendLine($"");

            textoMenu.AppendLine("1 - Menu de Lojas");
            textoMenu.AppendLine("2 - Menu de Produtos");
            textoMenu.AppendLine("3 - Menu de Clientes");
            textoMenu.AppendLine("4 - Menu de Estoque");
            textoMenu.AppendLine("5 - Menu de Vendas");
            textoMenu.AppendLine("0 - Sair do programa");
            textoMenu.AppendLine("");

            textoMenu.Append("Escolha um menu: ");

            Console.Write(textoMenu);
            return Enum.Parse<MainMenuChoices>(Console.ReadLine());
        }
    }
}
