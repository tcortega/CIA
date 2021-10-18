using CIA.DTOs;
using CIA.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CIA.Menus
{
    class InventoryMenu : BaseMenu, IMenu<InventoryMenuChoices>
    {
        private readonly InventoryService _inventoryService;

        public InventoryMenu(InventoryService productService)
        {
            _inventoryService = productService;
        }

        public InventoryMenuChoices DisplayAndGetChoice()
        {
            StringBuilder textoMenu = new();
            textoMenu.AppendLine($"MENU DE ESTOQUE {Environment.NewLine}");
            textoMenu.AppendLine("1 - Cadastrar Estoque");
            textoMenu.AppendLine("2 - Excluir Estoque");
            textoMenu.AppendLine("3 - Alterar Estoque");
            textoMenu.AppendLine("4 - Visualizar Estoques");
            textoMenu.AppendLine("0 - Sair");
            textoMenu.AppendLine("");

            textoMenu.Append("Escolha uma opção: ");

            while (true)
            {
                try
                {
                    Console.Write(textoMenu);
                    return Enum.Parse<InventoryMenuChoices>(Console.ReadLine());
                }
                catch (ArgumentException)
                {
                    DisplayInvalidChoice();
                }
            }
        }

        public void CreateInventory()
        {
            Console.Clear();

            /*Console.WriteLine("Insira o id da loja: ");
            var inventoryName = Console.ReadLine();

            Console.WriteLine("Insira o nome do estoque: ");
            var inventoryName = Console.ReadLine();*/

            Console.WriteLine("Insira o preco: ");
            var inventoryPrice = Console.ReadLine();

            Console.WriteLine("Insira a quantidade: ");
            var inventoryQuantity = Console.ReadLine();

            if (!string.IsNullOrEmpty(inventoryPrice)
                && !string.IsNullOrEmpty(inventoryQuantity))
            {
                var inventory = new InventoryDto()
                {
                    Price = decimal.Parse(inventoryPrice),
                    Quantity = int.Parse(inventoryQuantity)
                };

                _inventoryService.AddInventory(inventory);

                Console.WriteLine("Estoque Criado com Sucesso!");
                Thread.Sleep(1500);
            }
            else
            {
                DisplayInvalidChoice();
            }
        }

        public void DeleteInventory()
        {
            Console.Clear();

            var inventoryList = _inventoryService.GetAllInventories();
            var inventoryId = GetInventoryToDelete(inventoryList);

            if (int.TryParse(inventoryId, out var id) && inventoryList.Any(x => x.Id == id))
            {
                _inventoryService.RemoveById(id);

                Console.WriteLine("Estoque Deletado com Sucesso!");
                Thread.Sleep(1500);
            }
        }

        public void ListInventories()
        {
            Console.Clear();

            var inventoryList = _inventoryService.GetAllInventories();
            var inventoryListMenuText = GetInventoriesAsString(inventoryList);

            Console.WriteLine(inventoryListMenuText);
            Console.WriteLine("Pressione qualquer coisa para voltar...");
            Console.ReadKey();
        }

        private string GetInventoriesAsString(IEnumerable<InventoryDto> inventoryList)
        {
            StringBuilder returnstring = new();
            returnstring.AppendLine("Estoques cadastrados:");
            returnstring.AppendLine("");

            foreach (var inventory in inventoryList)
            {
                returnstring.AppendLine(inventory.ToString());
            }

            return returnstring.ToString();
        }

        private string GetInventoryToDelete(IEnumerable<InventoryDto> inventoryList)
        {
            StringBuilder textoMenu = new();
            textoMenu.AppendLine(GetInventoriesAsString(inventoryList));

            textoMenu.AppendLine("");
            textoMenu.AppendLine("Insira o Id do estoque que deseja deletar: ");

            Console.Write(textoMenu);
            return Console.ReadLine();
        }
    }
}
