using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetSafe
{
    public class Usuario
    {
        public int IDUsuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public DateTime DataCriacao { get; set; }

        // Relacionamento: Um usuário pode ter vários pets
        public List<Pet> Pets { get; set; }
    }
}
