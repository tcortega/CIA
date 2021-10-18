using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIA.DTOs
{
    public class CustomerDto : BaseDto
    {

        public string Name { get; set; }

        public string Address { get; set; }

        public DateTime Birthdate { get; set; }

        public string Gender { get; set; }

        public override string ToString()
        {
            return $"Id: {Id} | Nome: {Name} | Endereço: {Address} | Data de Nascimento: {Birthdate:dd/MM/yyyy} | Gênero: {Gender}";
        }

    }
}