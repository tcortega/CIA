using CIA.Core.Entities;
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
    public class InventoryMenu : BaseMenu, ISubMenu
    {
        private readonly StoreProductService _storeProductService;
        private readonly StoreService _storeService;
        private readonly ProductService _productService;
        private readonly SaleStoreProductService _saleStoreProductService;
        private StoreDto _store;

        public InventoryMenu(StoreProductService storeProductService, StoreService storeService, ProductService productService,
            SaleStoreProductService saleStoreProductService)
        {
            _storeProductService = storeProductService;
            _storeService = storeService;
            _productService = productService;
            _saleStoreProductService = saleStoreProductService;
        }

        public SubMenuChoices DisplayAndGetChoice()
        {
            StringBuilder textoMenu = new();
            textoMenu.AppendLine($"==== MENU DE ESTOQUE ====");
            textoMenu.AppendLine($"");

            textoMenu.AppendLine("1 - Cadastrar Item ao estoque");
            textoMenu.AppendLine("2 - Excluir Item do estoque");
            textoMenu.AppendLine("3 - Alterar item do estoque");
            textoMenu.AppendLine("4 - Visualizar items no estoque");
            textoMenu.AppendLine("0 - Sair");
            textoMenu.AppendLine("");

            textoMenu.Append("Escolha uma opção: ");

            while (true)
            {
                try
                {
                    ChooseStore();
                    Console.Clear();

                    Console.Write(textoMenu);
                    return Enum.Parse<SubMenuChoices>(Console.ReadLine());
                }
                catch (ArgumentException ex)
                {
                    DisplayInvalidChoice(ex);
                }
            }
        }

        private void ChooseStore()
        {
            Console.Clear();

            var storeList = _storeService.GetAll();
            var storeId = StoreMenu.ChooseStore(storeList);

            if (int.TryParse(storeId, out var id) && storeList.Any(x => x.Id == id))
            {
                _store = storeList.FirstOrDefault(s => s.Id == id);
            }
            else
            {
                DisplayInvalidChoice("A loja escolhida não está na lista ou o id é inválido.");
            }
        }

        public void Create()
        {
            var product = ChooseProduct();

            Console.Write("Insira o preço (Exemplo: 15,50): ");
            var price = Console.ReadLine().Replace(".", ",");

            Console.Write("Insira a quantidade: ");
            var quantity = Console.ReadLine();

            if (decimal.TryParse(price, out var newPrice) && int.TryParse(quantity, out var newQuantity))
            {
                var storeProduct = new StoreProductDto()
                {
                    Store = _store,
                    Product = product,
                    Price = newPrice,
                    Quantity = newQuantity
                };

                _storeProductService.Add(storeProduct);

                Console.WriteLine("Item adicionado ao estoque com sucesso.");
                Thread.Sleep(1500);
            }
            else
            {
                DisplayInvalidChoice("Preço ou Quantidade estão no formato errados.");
            }
        }

        private ProductDto ChooseProduct()
        {
            Console.Clear();

            var storeProducts = _storeProductService.GetAllByStoreId(_store.Id);
            var productList = _productService.GetAll().Where(p => !storeProducts.Any(x => x.Product.Id == p.Id));

            if (productList.Count() == 0)
            {
                throw new ArgumentException("Não existe nenhum produto que já não esteja no estoque.", "M");
            }

            var productId = ProductMenu.ChooseProduct(productList);

            if (int.TryParse(productId, out var id) && productList.Any(x => x.Id == id))
            {
                return productList.FirstOrDefault(s => s.Id == id);
            }
            else
            {
                throw new ArgumentException("O produto selecionado não existe.", "M");
            }
        }

        public void Delete()
        {
            Console.Clear();

            var inventoryList = _storeProductService.GetAllByStoreId(_store.Id);
            var inventoryId = ChooseStoreProduct(inventoryList);

            if (int.TryParse(inventoryId, out var id) && inventoryList.Any(x => x.Id == id))
            {
                if (_saleStoreProductService.ExistsByStoreProductId(id))
                {
                    Console.WriteLine("Não é possível deletar um item do estoque no qual já existem vendas associadas.");
                }
                else
                {
                    _storeProductService.RemoveById(id);

                    Console.WriteLine("Item removido com sucesso do estoque!");
                }

                Thread.Sleep(1500);
            }
        }

        public void Update()
        {
            Console.Clear();

            var storeProductList = _storeProductService.GetAllByStoreId(_store.Id);
            var storeProductId = ChooseStoreProduct(storeProductList);

            if (int.TryParse(storeProductId, out var id) && storeProductList.Any(x => x.Id == id))
            {
                Console.Clear();
                var storeProduct = storeProductList.FirstOrDefault(x => x.Id == id);

                Console.Write("Insira o novo preço (Ex.: 19,90) (Deixe em branco para manter): ");
                var price = Console.ReadLine().Replace(".", ",");

                Console.Write("Insira a nova quantidade (Deixe em branco para manter): ");
                var quantity = Console.ReadLine();

                if (!string.IsNullOrEmpty(price) && decimal.TryParse(price, out var newPrice))
                {
                    storeProduct.Price = newPrice;
                }

                if (!string.IsNullOrEmpty(quantity) && int.TryParse(quantity, out var newQuantity))
                {
                    storeProduct.Quantity = newQuantity;
                }

                _storeProductService.Update(storeProduct);

                Console.WriteLine("Cliente Alterado com Sucesso!");
                Thread.Sleep(1500);
            }
        }

        public void View()
        {
            Console.Clear();

            var inventoryList = _storeProductService.GetAllByStoreId(_store.Id);
            var inventoryListMenuText = GetStoreProductsAsString(inventoryList);

            Console.WriteLine(inventoryListMenuText);
            Console.WriteLine("Pressione qualquer tecla para voltar...");
            Console.ReadKey();
        }

        public static string GetStoreProductsAsString(IEnumerable<StoreProductDto> inventoryList)
        {
            StringBuilder returnstring = new();
            returnstring.AppendLine("Items cadastrados no estoque:");
            returnstring.AppendLine("");

            foreach (var inventory in inventoryList)
            {
                returnstring.AppendLine(inventory.ToString());
            }

            return returnstring.ToString();
        }

        public static string ChooseStoreProduct(IEnumerable<StoreProductDto> inventoryList)
        {
            StringBuilder textoMenu = new();
            textoMenu.AppendLine(GetStoreProductsAsString(inventoryList));

            textoMenu.AppendLine("");
            textoMenu.Append("Insira o Id do item que deseja selecionar: ");

            Console.Write(textoMenu);
            return Console.ReadLine();
        }
    }
}
