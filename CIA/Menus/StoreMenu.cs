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
    public class StoreMenu : BaseMenu, ISubMenu
    {
        private readonly StoreService _storeService;

        public StoreMenu(StoreService storeService)
        {
            _storeService = storeService;
        }

        public SubMenuChoices DisplayAndGetChoice()
        {
            StringBuilder textoMenu = new();
            textoMenu.AppendLine($"==== MENU DE LOJAS ====");
            textoMenu.AppendLine("");

            textoMenu.AppendLine("1 - Cadastrar uma loja");
            textoMenu.AppendLine("2 - Deletar uma loja");
            textoMenu.AppendLine("3 - Atualizar lojas cadastradas");
            textoMenu.AppendLine("4 - Listar todas lojas cadastradas");
            textoMenu.AppendLine("0 - Sair");
            textoMenu.AppendLine("");

            textoMenu.Append("Escolha uma opção: ");
            while (true)
            {
                try
                {
                    Console.Write(textoMenu);
                    return Enum.Parse<SubMenuChoices>(Console.ReadLine());
                }
                catch (ArgumentException)
                {
                    DisplayInvalidChoice();
                }
            }
        }

        public void Create()
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

        public void Delete()
        {
            Console.Clear();

            var storeList = _storeService.GetAll();
            var storeId = ChooseStore(storeList);

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

        public void View()
        {
            Console.Clear();

            var storeList = _storeService.GetAll();
            var storeListMenuText = GetStoresAsString(storeList);

            Console.WriteLine(storeListMenuText);
            Console.WriteLine("Pressione qualquer tecla para voltar...");
            Console.ReadKey();
        }

        public void Update()
        {
            Console.Clear();

            var storeList = _storeService.GetAll();
            var storeId = ChooseStore(storeList);

            if (int.TryParse(storeId, out var id) && storeList.Any(x => x.Id == id))
            {
                Console.Clear();
                var store = storeList.FirstOrDefault(x => x.Id == id);

                Console.Write("Insira o novo nome da loja (Deixe em branco para manter): ");
                var newName = Console.ReadLine();

                if (!string.IsNullOrEmpty(newName))
                {
                    store.Name = newName;
                    _storeService.Update(store);
                }

                Console.WriteLine("Loja Alterada com Sucesso!");
                Thread.Sleep(1500);
            }
        }

        public static string GetStoresAsString(List<StoreDto> storeList)
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

        public static string ChooseStore(List<StoreDto> storeList)
        {
            StringBuilder textoMenu = new();
            textoMenu.AppendLine(GetStoresAsString(storeList));

            textoMenu.AppendLine("");
            textoMenu.Append("Insira o Id da loja em que deseja realizar a operação: ");

            Console.Write(textoMenu);
            return Console.ReadLine();
        }
    }
}
