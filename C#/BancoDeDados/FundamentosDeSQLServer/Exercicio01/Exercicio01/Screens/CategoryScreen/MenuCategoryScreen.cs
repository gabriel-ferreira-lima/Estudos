namespace Exercicio01.Screens.CategoryScreen {
    internal class MenuCategoryScreen {
        public static void Load() {
            Console.Clear();
            Console.WriteLine("Gestão de Categoria");
            Console.WriteLine("---------------");
            Console.WriteLine("O que deseja fazer ?");
            Console.WriteLine();
            Console.WriteLine("1 - Listar Categorias");
            Console.WriteLine("2 - Cadastrar Categoria");
            Console.WriteLine("3 - Atualizar Categoria");
            Console.WriteLine("4 - Excluir Categoria");
            Console.WriteLine("5 - Voltar");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("Opção: ");
            try {
                var option = short.Parse(Console.ReadLine()!);

                switch (option) {
                    case 1:
                        ListarCategoryScreen.Load(); break;

                    case 2:
                        AdicionarCategoryScreen.Load(); break;

                    case 3:
                        AtualizarCategoryScreen.Load(); break;

                    case 4:
                        ExcluirCategoryScreen.Load(); break;

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
