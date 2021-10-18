using CIA.Core.Entities;
using CIA.DTOs;
using CIA.Helpers;
using CIA.Services;
using CIA.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CIA.Menus
{
    public class SalesMenu : BaseMenu, ISubMenu
    {
        private readonly CustomerService _customerService;
        private readonly StoreService _storeService;
        private readonly StoreProductService _storeProductService;
        private readonly SaleService _saleService;
        private readonly SaleStoreProductService _saleStoreProductService;

        public SalesMenu(CustomerService customerService, StoreService storeService, StoreProductService storeProductService,
            SaleService saleService, SaleStoreProductService saleStoreProductService)
        {
            _customerService = customerService;
            _storeService = storeService;
            _storeProductService = storeProductService;
            _saleService = saleService;
            _saleStoreProductService = saleStoreProductService;
        }

        public SubMenuChoices DisplayAndGetChoice()
        {
            StringBuilder textoMenu = new();
            textoMenu.AppendLine($"==== MENU DE VENDAS ====");
            textoMenu.AppendLine($"");

            textoMenu.AppendLine("1 - Simular Venda");
            textoMenu.AppendLine("2 - Cancelar Venda");
            textoMenu.AppendLine("3 - Alterar Venda");
            textoMenu.AppendLine("4 - Visualizar Vendas");
            textoMenu.AppendLine("0 - Sair");
            textoMenu.AppendLine("");

            textoMenu.Append("Escolha um menu: ");

            while (true)
            {
                try
                {
                    Console.Write(textoMenu);
                    return Enum.Parse<SubMenuChoices>(Console.ReadLine());
                }
                catch (ArgumentException ex)
                {
                    DisplayInvalidChoice(ex);
                }
            }
        }

        public void Create()
        {
            Console.Clear();

            var customer = ChooseCustomer();
            var store = ChooseStore();
            var saleStoreProducts = ChooseProductsToBuy(store.Id);

            if (saleStoreProducts.Count == 0)
                return;

            var sale = new SaleDto()
            {
                Customer = customer,
                TotalPrice = saleStoreProducts.Sum(x => x.Quantity * x.StoreProduct.Price),
                Status = SaleStatus.Pending,
                Quantity = saleStoreProducts.Sum(x => x.Quantity)
            };

            Console.WriteLine($"DETALHES DA VENDA {Environment.NewLine}");
            Console.WriteLine($"Quantidade de Produtos: {sale.Quantity}");
            Console.WriteLine($"Valor Total: {sale.TotalPrice} {Environment.NewLine}");

            Console.WriteLine(Environment.NewLine);

            string choice = string.Empty;
            while (choice != "S" && choice != "N")
            {
                Console.Write("Deseja Prosseguir? (S/N): ");
                choice = Console.ReadLine().ToUpper();
            }

            if (choice == "N")
            {
                Console.Clear();
                Console.WriteLine("Operação cancelada!");
                Thread.Sleep(2000);
                return;
            }

            var saleId = _saleService.Add(sale);
            sale.Id = saleId;

            foreach (var item in saleStoreProducts)
            {
                item.Sale = sale;
            };

            _saleStoreProductService.Add(saleStoreProducts);
        }

        public void Delete()
        {
            Console.Clear();

            var salesList = _saleService.GetAll();
            var saleDto = ChooseSale(salesList);
            CancelSale(saleDto);
        }

        public void Update()
        {
            var salesList = _saleService.GetAll();
            var saleDto = ChooseSale(salesList);

            Console.WriteLine($"Venda Selecionada: {saleDto}");
            Console.WriteLine();
            Console.WriteLine($"Operações possíveis:");
            Console.WriteLine("1 - Cancelar pedido");
            Console.WriteLine("2 - Confirmar pedido");
            Console.WriteLine("3 - Alterar status para pendente");
            Console.WriteLine();
            Console.Write("Escolha uma opção: ");
            var choice = Console.ReadLine();

            if (int.TryParse(choice, out var updateChoice) && updateChoice > 0 && updateChoice <= 3)
            {
                if (updateChoice == 1)
                {
                    CancelSale(saleDto);
                }
                else if (updateChoice == 2)
                {
                    ConfirmSale(saleDto);
                }
                else
                {
                    SaleStatusToPending(saleDto);
                }
            } else
            {
                DisplayInvalidChoice("A operação escolhida é inválida.");
            }

        }

        public void View()
        {
            Console.Clear();

            var salesList = _saleService.GetAll();
            var salesListMenuText = GetSalesAsString(salesList);

            Console.WriteLine(salesListMenuText);
            Console.WriteLine("Pressione qualquer tecla para voltar...");
            Console.ReadKey();
        }

        private void CancelSale(SaleDto saleDto)
        {
            saleDto.Status = SaleStatus.Cancelled;

            _saleService.Update(saleDto);
            _saleStoreProductService.CancelSaleProducts(saleDto.Id);
        }

        private void ConfirmSale(SaleDto saleDto)
        {
            saleDto.Status = SaleStatus.Confirmed;

            _saleService.Update(saleDto);
        }

        private void SaleStatusToPending(SaleDto saleDto)
        {
            saleDto.Status = SaleStatus.Pending;
            _saleService.Update(saleDto);
        }

        public static SaleDto ChooseSale(List<SaleDto> salesList)
        {
            Console.Clear();
            var salesListMenuText = GetSalesAsString(salesList);

            Console.WriteLine(salesListMenuText);
            Console.WriteLine("");
            Console.WriteLine("Informe o Id do item no qual deseja selecionar: ");
            var saleId = Console.ReadLine();

            if (int.TryParse(saleId, out var id) && salesList.Any(x => x.Id == id))
            {
                return salesList.FirstOrDefault(x => x.Id == id);
            }

            throw new ArgumentException("O id da venda escolhida é inválido.");
        }

        public static string GetSalesAsString(List<SaleDto> productList)
        {
            StringBuilder returnstring = new();
            returnstring.AppendLine("Vendas cadastrados:");
            returnstring.AppendLine("");

            foreach (var product in productList)
            {
                returnstring.AppendLine(product.ToString());
            }

            return returnstring.ToString();
        }

        private List<SaleStoreProductDto> ChooseProductsToBuy(int storeId)
        {
            var productList = _storeProductService.GetAllByStoreId(storeId)
                .Where(x => x.Quantity > 0);

            var returnList = new List<SaleStoreProductDto>();
            while (true)
            {
                if (productList.Count() == 0)
                {
                    break;
                }

                Console.Clear();
                ConsoleUtilities.Danger("AVISO: DEIXE EM BRANCO CASO DEJESE PARAR!");
                var storeProductId = InventoryMenu.ChooseStoreProduct(productList);

                if (string.IsNullOrEmpty(storeProductId))
                {
                    break;
                }

                var storeProduct = GetStoreProduct(storeProductId, productList);

                Console.WriteLine(Environment.NewLine);
                Console.WriteLine($"Produto Selecionado: {Environment.NewLine}{storeProduct}{Environment.NewLine}{Environment.NewLine}");
                Console.Write("Quantidade que deseja comprar: ");
                var quantityChoice = Console.ReadLine();

                if (int.TryParse(quantityChoice, out var quantity))
                {
                    if (quantity > storeProduct.Quantity)
                    {
                        Console.WriteLine("A quantidade selecionada é inválida.");
                        Thread.Sleep(2000);
                    }
                    else
                    {
                        returnList.Add(new()
                        {
                            StoreProduct = storeProduct,
                            Quantity = quantity
                        });

                        productList = productList.Where(p => p.Id != storeProduct.Id);

                        Console.WriteLine("\nProduto adicionado à venda com sucesso!");
                        Thread.Sleep(1500);
                    }
                }
                else
                {
                    Console.WriteLine("O valor inserido é inválido.");
                }
            }

            Console.Clear();
            return returnList;
        }

        public CustomerDto ChooseCustomer()
        {
            var customerList = _customerService.GetAll();
            var customerId = CustomerMenu.ChooseCustomer(customerList);

            if (!string.IsNullOrEmpty(customerId) && int.TryParse(customerId, out var id))
            {
                return customerList.FirstOrDefault(x => x.Id == id);
            }
            else
            {
                throw new ArgumentException("O cliente escolhido não existe", "M");
            }
        }

        private StoreDto ChooseStore()
        {
            Console.Clear();

            var storeList = _storeService.GetAll();
            var storeId = StoreMenu.ChooseStore(storeList);

            if (int.TryParse(storeId, out var id) && storeList.Any(x => x.Id == id))
            {
                return storeList.FirstOrDefault(s => s.Id == id);
            }
            else
            {
                throw new ArgumentException("A loja escolhida não está na lista ou o id é inválido.", "M");
            }
        }

        private StoreProductDto GetStoreProduct(string storeProductId, IEnumerable<StoreProductDto> storeProductList)
        {
            if (int.TryParse(storeProductId, out var id) && storeProductList.Any(x => x.Id == id))
            {
                return storeProductList.FirstOrDefault(s => s.Id == id);
            }
            else
            {
                throw new ArgumentException("O produto escolhido não está na lista ou o id é inválido.", "M");
            }
        }
    }
}
