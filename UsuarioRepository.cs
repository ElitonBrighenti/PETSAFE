using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetSafe
{
    public class UsuarioRepository
    {
        private readonly PetSafe _context;

        public UsuarioRepository(PetSafe context)
        {
            _context = context;
        }
        public void SalvarUsuarioNoBanco(Usuario usuario)
        {
            var existingUser = _context.Usuarios.Find(usuario.IDUsuario);
            if (existingUser != null)
            {
                // Atualiza o usuário existente
                _context.Entry(existingUser).CurrentValues.SetValues(usuario);
            }
            else
            {
                // Adiciona um novo usuário
                _context.Usuarios.Add(usuario);
            }
            _context.SaveChanges();
        }

        public void DeletarUsuarioNoBanco(int id)
        {
            var usuario = _context.Usuarios.Find(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
                _context.SaveChanges();
            }
        }

        public List<Usuario> ExibirUsuarioDoBanco()
        {
            // Inclui os pets relacionados ao usuário
            return _context.Usuarios.Include(u => u.Pets).ToList();
        }
    }
}
