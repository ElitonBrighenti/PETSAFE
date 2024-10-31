using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetSafe
{
    public class UsuarioService
    {
        private readonly UsuarioRepository _usuarioRepository;

        public UsuarioService(UsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public void SalvarUsuario(Usuario usuario)
        {
            _usuarioRepository.SalvarUsuarioNoBanco(usuario);
        }

        public void RemoverUsuario(int id)
        {
            _usuarioRepository.DeletarUsuarioNoBanco(id);
        }


        public List<Usuario> ExibirUsuarios()
        {
            return _usuarioRepository.ExibirUsuarioDoBanco();
        }
    }
}
