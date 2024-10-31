using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetSafe
{
    public class PetRepository
    {
        private readonly PetSafe _context;

        public PetRepository(PetSafe context)
        {
            _context = context;
        }

        // Salvar no banco
        public void SalvarPetNoBanco(Pet pet)
        {
            var existingPet = _context.Pets.Find(pet.IDPet);
            if (existingPet != null)
            {
                _context.Entry(existingPet).CurrentValues.SetValues(pet); // Atualiza se já existe
            }
            else
            {
                _context.Pets.Add(pet); // Adiciona se não existe
            }
            _context.SaveChanges();
        }

        //Deletar pet no banco
        public void DeletarPetNoBanco(int id)
        {
            var pet = _context.Pets.Find(id);
            if (pet != null)
            {
                _context.Pets.Remove(pet); // Remove se encontrado
                _context.SaveChanges();
            }
        }

        public List<Pet> ExibirPetDoBanco()
        {
            return _context.Pets.ToList();
        }
    }
}
