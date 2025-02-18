namespace Exercicio01.Screens.TagScreen {

    internal class MenuTagScreen {
        public static void Load() {
            Console.Clear();
            Console.WriteLine("Gestão de tags");
            Console.WriteLine("---------------");
            Console.WriteLine("O que deseja fazer ?");
            Console.WriteLine();
            Console.WriteLine("1 - Listar tags");
            Console.WriteLine("2 - Cadastrar tags");
            Console.WriteLine("3 - Atualizar tags");
            Console.WriteLine("4 - Excluir tags");
            Console.WriteLine("5 - Voltar");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("Opção: ");
            try {
                var option = short.Parse(Console.ReadLine()!);

                switch (option) {
                    case 1:
                        ListarTagScreen.Load(); break;

                    case 2:
                        AdicionarTagScreen.Load(); break;

                    case 3:
                        AtualizarTagScreen.Load(); break;

                    case 4:
                        ExcluirTagScreen.Load(); break;

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