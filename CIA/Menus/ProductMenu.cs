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
    public class ProductMenu : BaseMenu, IMenu<ProductMenuChoices>
    {

        private readonly ProductService _productService;

        public ProductMenu(ProductService productService)
        {
            _productService = productService;
        }

        public ProductMenuChoices DisplayAndGetChoice()
        {
            StringBuilder textoMenu = new();
            textoMenu.AppendLine($"MENU DE PRODUTOS {Environment.NewLine}");
            textoMenu.AppendLine("1 - Cadastrar Produto");
            textoMenu.AppendLine("2 - Excluir Produto");
            textoMenu.AppendLine("3 - Alterar Produto");
            textoMenu.AppendLine("4 - Visualizar Produtos");
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


        public void CreateProduct()
        {
            Console.Clear();

            Console.WriteLine("Insira o nome do produto: ");
            var productName = Console.ReadLine();

            if (!string.IsNullOrEmpty(productName))
            {
                var product = new ProductDto()
                {
                    Name = productName
                };

                _productService.AddProduct(product);

                Console.WriteLine("Produto Criado com Sucesso!");
                Thread.Sleep(1500);
            }
            else
            {
                DisplayInvalidChoice();
            }
        }

        public void DeleteProduct()
        {
            Console.Clear();

            var productList = _productService.GetAllProducts();
            var productId = GetProductToDelete(productList);

            if(int.TryParse(productId, out var id) && productList.Any(x => x.Id == id))
            {
                _productService.RemoveById(id);

                Console.WriteLine("Produto Deletado com Sucesso!");
                Thread.Sleep(1500);
            }
        }

        public void ListProducts()
        {
            Console.Clear();

            var productList = _productService.GetAllProducts();
            var productListMenuText = GetProductsAsString(productList);

            Console.WriteLine(productListMenuText);
            Console.WriteLine("Pressione qualquer coisa para voltar...");
            Console.ReadKey();
        }


        private string GetProductsAsString(IEnumerable<ProductDto> productList)
        {
            StringBuilder returnstring = new();
            returnstring.AppendLine("Produtos cadastrados:");
            returnstring.AppendLine("");

            foreach (var product in productList)
            {
                returnstring.AppendLine(product.ToString());
            }

            return returnstring.ToString();
        }

        private string GetProductToDelete(IEnumerable<ProductDto> productList)
        {

            StringBuilder textoMenu = new();
            textoMenu.AppendLine(GetProductsAsString(productList));

            textoMenu.AppendLine("");
            textoMenu.AppendLine("Insira o Id do produto que deseja deletar: ");

            Console.Write(textoMenu);
            return Console.ReadLine();
        }
    }
}
