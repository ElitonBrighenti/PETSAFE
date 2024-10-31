using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetSafe
{
    public class PetService
    {
        private readonly PetRepository _petRepository;

        public PetService(PetRepository repository)
        {
            _petRepository = repository;
        }

        public void SalvarPet(Pet pet)
        {
            _petRepository.SalvarPetNoBanco(pet);
            Console.WriteLine("Pet salvo no banco.");
        }

        public void RemoverPet(int id)
        {
            _petRepository.DeletarPetNoBanco(id);
        }

        public List<Pet> ExibirPets()
        {
            return _petRepository.ExibirPetDoBanco();
        }
    }
}
