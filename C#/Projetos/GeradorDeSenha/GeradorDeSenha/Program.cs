using GeradorDeSenha;
using System.Threading.Tasks;

public class Program {
    public static string Email { get; set; } = "Gladson.vinicius@controlid.com.br";
    public static string Senha { get; set; } = "Controlid@123";
    public static string TokenDevice { get; set; }

    static async Task Main(string[] args) {

        string a = await Funcionalidades.FazerLogin();

        if (a == "OK") {
            await Screen.Load();
        }
        else {
            Console.WriteLine($"Erro ao fazer Login: {a}"); ;
        }
    }
}
