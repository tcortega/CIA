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
    public class ProductMenu : BaseMenu, ISubMenu
    {

        private readonly ProductService _productService;

        public ProductMenu(ProductService productService)
        {
            _productService = productService;
        }

        public SubMenuChoices DisplayAndGetChoice()
        {
            StringBuilder textoMenu = new();
            textoMenu.AppendLine($"==== MENU DE PRODUTOS ====");
            textoMenu.AppendLine($"");

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

            Console.WriteLine("Insira o nome do produto: ");
            var productName = Console.ReadLine();

            if (!string.IsNullOrEmpty(productName))
            {
                var product = new ProductDto()
                {
                    Name = productName
                };

                _productService.Add(product);

                Console.WriteLine("Produto Criado com Sucesso!");
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

            var productList = _productService.GetAll();
            var productId = ChooseProduct(productList);

            if(int.TryParse(productId, out var id) && productList.Any(x => x.Id == id))
            {
                _productService.RemoveById(id);

                Console.WriteLine("Produto Deletado com Sucesso!");
                Thread.Sleep(1500);
            }
        }

        public void Update()
        {
            Console.Clear();

            var productList = _productService.GetAll();
            var productId = ChooseProduct(productList);

            if (int.TryParse(productId, out var id) && productList.Any(x => x.Id == id))
            {
                Console.Clear();
                var product = productList.FirstOrDefault(x => x.Id == id);

                Console.Write("Insira o novo nome do produto (Deixe em branco para manter): ");
                var newName = Console.ReadLine();

                if (!string.IsNullOrEmpty(newName))
                {
                    product.Name = newName;
                    _productService.Update(product);
                }

                Console.WriteLine("Produto Alterado com Sucesso!");
                Thread.Sleep(1500);
            }
        }

        public void View()
        {
            Console.Clear();

            var productList = _productService.GetAll();
            var productListMenuText = GetProductsAsString(productList);

            Console.WriteLine(productListMenuText);
            Console.WriteLine("Pressione qualquer tecla para voltar...");
            Console.ReadKey();
        }


        public static string GetProductsAsString(IEnumerable<ProductDto> productList)
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

        public static string ChooseProduct(IEnumerable<ProductDto> productList)
        {

            StringBuilder textoMenu = new();
            textoMenu.AppendLine(GetProductsAsString(productList));

            textoMenu.AppendLine("");
            textoMenu.AppendLine("Insira o Id do produto que deseja selecionar: ");

            Console.Write(textoMenu);
            return Console.ReadLine();
        }
    }
}
