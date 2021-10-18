using CIA.DTOs;
using CIA.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CIA.Menus
{
    public class CustomerMenu : BaseMenu, ISubMenu
    {

        private readonly CustomerService _customerService;
        private readonly SaleService _saleService;

        public CustomerMenu(CustomerService customerService, SaleService saleService)
        {
            _customerService = customerService;
            _saleService = saleService;
        }

        public SubMenuChoices DisplayAndGetChoice()
        {
            StringBuilder textoMenu = new();
            textoMenu.AppendLine($"==== MENU DE CLIENTES ====");
            textoMenu.AppendLine($"");

            textoMenu.AppendLine("1 - Cadastrar novo cliente");
            textoMenu.AppendLine("2 - Excluir cliente");
            textoMenu.AppendLine("3 - Alterar dados de um cliente");
            textoMenu.AppendLine("4 - Visualizar clientes");
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
            try
            {
                Console.Clear();

                Console.Write("Insira o nome completo: ");
                var name = Console.ReadLine();

                Console.Write("Insira o endereço: ");
                var address = Console.ReadLine();

                Console.Write("Insira a data de nascimento (dd/mm/aaaa): ");
                var birthDate = Console.ReadLine();
                var newBirthDate = DateTime.ParseExact(birthDate, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("pt-BR"));

                Console.Write("Insira o gênero: ");
                var gender = Console.ReadLine();

                if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(address) && !string.IsNullOrEmpty(gender) && newBirthDate > DateTime.MinValue)
                {
                    var customer = new CustomerDto()
                    {
                        Name = name,
                        Address = address,
                        Birthdate = newBirthDate,
                        Gender = gender
                    };

                    _customerService.Add(customer);

                    Console.WriteLine("Cliente cadastrado com Sucesso!");
                    Thread.Sleep(1500);
                }
                else
                {
                    throw new ArgumentException();
                }
            }
            catch (ArgumentException)
            {
                DisplayInvalidChoice("Dados inconsistentes encontrados no cadastro do cliente, favor re-fazer o cadastro.");
            }
        }

        public void Delete()
        {
            Console.Clear();

            var customerList = _customerService.GetAll();
            var customerId = ChooseCustomer(customerList);

            if (int.TryParse(customerId, out var id) && customerList.Any(x => x.Id == id))
            {
                if (_saleService.ExistsByCustomerId(id))
                {
                    Console.WriteLine("Não é possível deletar o cliente pois ele já realizou compras.");
                }
                else
                {
                    _customerService.RemoveById(id);

                    Console.WriteLine("Cliente Deletado com Sucesso!");
                }
                Thread.Sleep(1500);
            }
        }

        public void Update()
        {
            Console.Clear();

            var customerList = _customerService.GetAll();
            var customerId = ChooseCustomer(customerList);

            if (int.TryParse(customerId, out var id) && customerList.Any(x => x.Id == id))
            {
                Console.Clear();
                var customer = customerList.FirstOrDefault(x => x.Id == id);

                Console.Write("Insira o novo nome do cliente (Deixe em branco para manter): ");
                var newName = Console.ReadLine();

                Console.Write("Insira o novo endereço do cliente (Deixe em branco para manter): ");
                var newAddress = Console.ReadLine();

                Console.Write("Insira a nova data de nascimento do cliente (dd/mm/aaaa) (Deixe em branco para manter): ");
                var birthDate = Console.ReadLine();
                var newBirthDate = DateTime.MinValue;
                try
                {
                    newBirthDate = DateTime.ParseExact(birthDate, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("pt-BR"));
                }
                catch { }

                Console.Write("Insira o novo genero do cliente (Deixe em branco para manter): ");
                var newGender = Console.ReadLine();

                if (!string.IsNullOrEmpty(newName))
                {
                    customer.Name = newName;
                }

                if (!string.IsNullOrEmpty(newAddress))
                {
                    customer.Address = newAddress;
                }

                if (newBirthDate > DateTime.MinValue)
                {
                    customer.Birthdate = newBirthDate;
                }

                if (!string.IsNullOrEmpty(newGender))
                {
                    customer.Gender = newGender;
                }

                _customerService.Update(customer);

                Console.WriteLine("Cliente Alterado com Sucesso!");
                Thread.Sleep(1500);
            }
        }

        public void View()
        {
            Console.Clear();

            var customerList = _customerService.GetAll();
            var customerListMenuText = GetCustomersAsString(customerList);

            Console.WriteLine(customerListMenuText);
            Console.WriteLine("Pressione qualquer tecla para voltar...");
            Console.ReadKey();
        }


        public static string GetCustomersAsString(IEnumerable<CustomerDto> customerList)
        {
            StringBuilder returnstring = new();
            returnstring.AppendLine("Clientes cadastrados:");
            returnstring.AppendLine("");

            foreach (var customer in customerList)
            {
                returnstring.AppendLine(customer.ToString());
            }

            return returnstring.ToString();
        }

        public static string ChooseCustomer(IEnumerable<CustomerDto> customerList)
        {
            StringBuilder textoMenu = new();
            textoMenu.AppendLine(GetCustomersAsString(customerList));

            textoMenu.AppendLine("");
            textoMenu.Append("Insira o Id do Cliente a realizar a operação: ");

            Console.Write(textoMenu);
            return Console.ReadLine();
        }
    }
}
