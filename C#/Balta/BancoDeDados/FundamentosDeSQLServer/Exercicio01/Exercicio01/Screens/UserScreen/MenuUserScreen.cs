using Exercicio01.Screens.TagScreen;

namespace Exercicio01.Screens.UserScreen {

    internal class MenuUserScreen {
        public static void Load() {
            Console.Clear();
            Console.WriteLine("Gestão de Usuarios");
            Console.WriteLine("---------------");
            Console.WriteLine("O que deseja fazer ?");
            Console.WriteLine();
            Console.WriteLine("1 - Listar usuarios");
            Console.WriteLine("2 - Cadastrar usuario");
            Console.WriteLine("3 - Atualizar usuario");
            Console.WriteLine("4 - Excluir usuario");
            Console.WriteLine("5 - Voltar");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("Opção: ");
            try {
                var option = short.Parse(Console.ReadLine()!);

                switch (option) {
                    case 1:
                        ListarUserScreen.Load(); break;

                    case 2:
                        AdicionarUserScreen.Load(); break;

                    case 3:
                        AtualizarUserScreen.Load(); break;

                    case 4:
                        ExcluirUserScreen.Load(); break;

                    case 5:
                        Program.Load(); break;

                    default:
                        Load(); break;
                }
            }
            catch (FormatException) {
                Console.WriteLine("Por favor insira apenas numeros");
                Console.ReadKey();
                Load();
            }
        }
    }
}