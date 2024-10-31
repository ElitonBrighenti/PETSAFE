using Microsoft.EntityFrameworkCore;

namespace PetSafe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new PetSafe())
            {
                // Inicialização dos repositórios e serviços
                var usuarioRepository = new UsuarioRepository(context);
                var usuarioService = new UsuarioService(usuarioRepository);

                var petRepository = new PetRepository(context);
                var petService = new PetService(petRepository);

                // Loop principal do menu
                while (true)
                {
                    Console.WriteLine("Escolha uma opção:");
                    Console.WriteLine("1. Exibir usuários");
                    Console.WriteLine("2. Criar/Atualizar usuário");
                    Console.WriteLine("3. Remover usuário");
                    Console.WriteLine("4. Exibir pets");
                    Console.WriteLine("5. Criar/Atualizar pet");
                    Console.WriteLine("6. Remover pet");
                    Console.WriteLine("7. Sair");

                    string escolha = Console.ReadLine();

                    switch (escolha)
                    {
                        case "1":
                            ExibirUsuarios(usuarioService);
                            break;
                        case "2":
                            CriarOuAtualizarUsuario(usuarioService);
                            break;
                        case "3":
                            RemoverUsuario(usuarioService);
                            break;
                        case "4":
                            ExibirPets(petService);
                            break;
                        case "5":
                            CriarOuAtualizarPet(petService);
                            break;
                        case "6":
                            RemoverPet(petService);
                            break;
                        case "7":
                            Console.WriteLine("Saindo...");
                            return; // Sai do programa
                        default:
                            Console.WriteLine("Opção inválida. Tente novamente.");
                            break;
                    }
                }
            }

            static void ExibirUsuarios(UsuarioService usuarioService)
            {
                var usuarios = usuarioService.ExibirUsuarios();
                foreach (var usuario in usuarios)
                {
                    Console.WriteLine($"Usuário: {usuario.Nome}, Email: {usuario.Email}");
                    foreach (var pet in usuario.Pets)
                    {
                        Console.WriteLine($"  Pet: {pet.Nome}, Raça: {pet.Raca}");
                    }
                }
            }

            static void ExibirPets(PetService petService)
            {
                var pets = petService.ExibirPets();
                foreach (var pet in pets)
                {
                    Console.WriteLine($"Pet: {pet.Nome}, Raça: {pet.Raca}, Idade: {pet.Idade}, Peso: {pet.Peso}, ID Usuário: {pet.IDUsuario}");
                }
            }

            static void CriarOuAtualizarUsuario(UsuarioService usuarioService)
            {
                Console.Write("Informe o ID do usuário (ou 0 para criar um novo): ");
                int id = int.Parse(Console.ReadLine());

                var usuario = new Usuario
                {
                    IDUsuario = id,
                    Nome = Prompt("Nome: "),
                    Email = Prompt("Email: "),
                    Senha = Prompt("Senha: "),
                    Telefone = Prompt("Telefone: "),
                    Endereco = Prompt("Endereço: "),
                    DataCriacao = DateTime.UtcNow
                };

                usuarioService.SalvarUsuario(usuario);
                Console.WriteLine("Usuário salvo com sucesso!");
            }

            static void RemoverUsuario(UsuarioService usuarioService)
            {
                Console.Write("Informe o ID do usuário a ser removido: ");
                int id = int.Parse(Console.ReadLine());
                usuarioService.RemoverUsuario(id);
                Console.WriteLine("Usuário removido com sucesso!");
            }

            static void CriarOuAtualizarPet(PetService petService)
            {
                Console.Write("Informe o ID do pet (ou 0 para criar um novo): ");
                int id = int.Parse(Console.ReadLine());

                var pet = new Pet
                {
                    IDPet = id,
                    Nome = Prompt("Nome do pet: "),
                    Raca = Prompt("Raça do pet: "),
                    Idade = int.Parse(Prompt("Idade do pet: ")),
                    Peso = decimal.Parse(Prompt("Peso do pet: ")),
                    DataCadastro = DateTime.UtcNow,
                    IDUsuario = int.Parse(Prompt("ID do usuário associado: "))
                };

                petService.SalvarPet(pet);
                Console.WriteLine("Pet salvo com sucesso!");
            }

            static void RemoverPet(PetService petService)
            {
                Console.Write("Informe o ID do pet a ser removido: ");
                int id = int.Parse(Console.ReadLine());
                petService.RemoverPet(id);
                Console.WriteLine("Pet removido com sucesso!");
            }

            static string Prompt(string message)
            {
                Console.Write(message);
                return Console.ReadLine();
            }

        }
    }
}
