using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIA.Menus
{
    public class SalesMenu : BaseMenu, IMenu<SalesMenuChoices>
    {
        public SalesMenuChoices DisplayAndGetChoice()
        {
            StringBuilder textoMenu = new();
            textoMenu.AppendLine($"MENU DE VENDAS {Environment.NewLine}");
            textoMenu.AppendLine("1 - Iniciar Venda");
            textoMenu.AppendLine("2 - Excluir Venda");
            textoMenu.AppendLine("3 - Alterar Venda");
            textoMenu.AppendLine("4 - Visualizar Vendas");
            textoMenu.AppendLine("0 - Sair");

            while (true)
            {
                try
                {
                    Console.Write(textoMenu);
                    return Enum.Parse<SalesMenuChoices>(Console.ReadLine());
                }
                catch (ArgumentException)
                {
                    DisplayInvalidChoice();
                }
            }
        }
    }
}
