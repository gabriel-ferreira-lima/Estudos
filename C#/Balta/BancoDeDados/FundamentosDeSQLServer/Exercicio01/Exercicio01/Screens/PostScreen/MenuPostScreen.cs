namespace Exercicio01.Screens.PostScreen;

public class MenuPostScreen
{
    public static void Load() {
        Console.Clear();
        Console.WriteLine("Gestão de Posts");
        Console.WriteLine("---------------");
        Console.WriteLine("O que deseja fazer ?");
        Console.WriteLine();
        Console.WriteLine("1 - Listar Posts");
        Console.WriteLine("2 - Listar Post por usuario");
        Console.WriteLine("3 - Criar Post");
        Console.WriteLine("4 - Editar Post");
        Console.WriteLine("5 - Exculir Post");
        Console.WriteLine("6 - Voltar");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("Opção: ");
        try {
            var option = short.Parse(Console.ReadLine()!);

            switch (option) {
                case 1:
                    ListarPostScreen.Load(); break;

                case 2:
                    ListarPostUserScreen.Load(); break;
                case 3:
                    AdicionarPostScreen.Load(); break;

                case 6:
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