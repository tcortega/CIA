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
    public class StoreMenu : BaseMenu, IMenu<StoreMenuChoices>
    {
        private readonly StoreService _storeService;

        public StoreMenu(StoreService storeService)
        {
            _storeService = storeService;
        }

        public StoreMenuChoices DisplayAndGetChoice()
        {
            StringBuilder textoMenu = new();
            textoMenu.AppendLine($"MENU DE LOJAS");
            textoMenu.AppendLine("");

            textoMenu.AppendLine("1 - Cadastrar uma loja");
            textoMenu.AppendLine("2 - Deletar uma loja");
            textoMenu.AppendLine("3 - Listar todas lojas cadastradas");
            textoMenu.AppendLine("0 - Sair");
            textoMenu.AppendLine("");

            textoMenu.Append("Escolha uma opção: ");
            while (true)
            {
                try
                {
                    Console.Write(textoMenu);
                    return Enum.Parse<StoreMenuChoices>(Console.ReadLine());
                }
                catch (ArgumentException)
                {
                    DisplayInvalidChoice();
                }
            }
        }

        public void CreateStore()
        {
            Console.Clear();

            Console.WriteLine("Insira o nome da loja: ");
            var storeName = Console.ReadLine();

            if (!string.IsNullOrEmpty(storeName))
            {
                var store = new StoreDto()
                {
                    Name = storeName
                };

                _storeService.AddStore(store);

                Console.WriteLine("Loja criada com sucesso!");
                Thread.Sleep(1500);
            }
            else
            {
                DisplayInvalidChoice();
            }
        }

        public void DeleteStore()
        {
            Console.Clear();

            var storeList = _storeService.GetAllStores();
            var storeId = GetStoreToDelete(storeList);

            if (int.TryParse(storeId, out var id) && storeList.Any(x => x.Id == id))
            {
                _storeService.RemoveById(id);

                Console.WriteLine("Loja deletada com sucesso!");
                Thread.Sleep(1500);
            }
            else
            {
                DisplayInvalidChoice();
            }
        }

        public void ListStores()
        {
            Console.Clear();

            var storeList = _storeService.GetAllStores();
            var storeListMenuText = GetStoresAsString(storeList);

            Console.WriteLine(storeListMenuText);
            Console.WriteLine("Pressione qualquer coisa para voltar...");
            Console.ReadKey();
        }

        private string GetStoresAsString(IEnumerable<StoreDto> storeList)
        {
            StringBuilder returnString = new();
            returnString.AppendLine("Lojas cadastradas:");
            returnString.AppendLine("");

            foreach (var store in storeList)
            {
                returnString.AppendLine(store.ToString());
            }

            return returnString.ToString();
        }

        private string GetStoreToDelete(IEnumerable<StoreDto> storeList)
        {
            StringBuilder textoMenu = new();
            textoMenu.AppendLine(GetStoresAsString(storeList));

            textoMenu.AppendLine("");
            textoMenu.Append("Insira o Id da loja que deseja deletar: ");

            Console.Write(textoMenu);
            return Console.ReadLine();
        }
    }
}
