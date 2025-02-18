namespace Exercicio01.Screens.UserRoleScreen;

public class MenuUserRoleScreen {
    public static void Load() {
        Console.Clear();
        Console.WriteLine("Gestão Usuario/Perfil");
        Console.WriteLine("---------------");
        Console.WriteLine("O que deseja fazer ?");
        Console.WriteLine();
        Console.WriteLine("1 - Listar usuarios e seus perfis");
        Console.WriteLine("2 - Cadastrar usuario a um perfil");
        Console.WriteLine("3 - Atualizar perfil de usuario");
        Console.WriteLine("4 - Excluir perfil de usuario");
        Console.WriteLine("5 - Voltar");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("Opção: ");
        try {
            var option = short.Parse(Console.ReadLine()!);

            switch (option) {
                case 1:
                    ListarUserRoleScreen.Load(); break;
                
                // case 2:
                //     AdicionarUserScreen.Load(); break;
                //
                // case 3:
                //     AtualizarUserScreen.Load(); break;
                //
                // case 4:
                //     ExcluirUserScreen.Load(); break;

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