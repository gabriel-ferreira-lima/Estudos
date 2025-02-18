using Exercicio01.Repositories;

namespace Exercicio01.Screens.UserRoleScreen;

public class ListarUserRoleScreen {
    public static void Load() {
        Console.Clear();
        Console.WriteLine("Lista de Usuarios e seus Perfis");
        Console.WriteLine("-------------");
        List();
        Console.ReadKey();
        MenuUserRoleScreen.Load();
    }

    private static void List() {
        var repository = new UserRepository(Database.Connection);

        var users = repository.GetWithRoles();
        foreach (var item in users) {
            Console.WriteLine($"{item.Id} | {item.Name} | {item.Email}");
            foreach (var role in item.Roles) {
                Console.WriteLine($" - {role.Name}");
            }
        }
    }
}