namespace Exercicio01.Screens.RoleScreen {
    internal class MenuRoleScreen {
        public static void Load() {
            Console.Clear();
            Console.WriteLine("Gestão de Perfis");
            Console.WriteLine("---------------");
            Console.WriteLine("O que deseja fazer ?");
            Console.WriteLine();
            Console.WriteLine("1 - Listar Perfis");
            Console.WriteLine("2 - Cadastrar Perfis");
            Console.WriteLine("3 - Atualizar Perfis");
            Console.WriteLine("4 - Excluir Perfis");
            Console.WriteLine("5 - Voltar");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("Opção: ");
            try {
                var option = short.Parse(Console.ReadLine()!);

                switch (option) {
                    case 1:
                        ListarRoleScreen.Load(); break;

                    case 2:
                        AdicionarRoleScreen.Load(); break;

                    case 3:
                        AtualizarRoleScreen.Load(); break;

                    case 4:
                        ExcluirRoleScreen.Load(); break;

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
