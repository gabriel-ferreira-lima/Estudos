using Exercicio01.Screens.CategoryScreen;
using Exercicio01.Screens.RoleScreen;
using Exercicio01.Screens.TagScreen;
using Exercicio01.Screens.UserScreen;
using Exercicio01.Screens.PostScreen;
using Exercicio01.Screens.UserRoleScreen;
using Microsoft.Data.SqlClient;

namespace Exercicio01 {
    internal class Program {

        private const string CONNECTION_STRING = @"Server=localhost,1433;Database=Blog;User ID=sa;Password=Gordaojoga10;Trusted_Connection=False; TrustServerCertificate=True;";

        static void Main(string[] args) {
            try {
                Database.Connection = new SqlConnection(CONNECTION_STRING);
                Database.Connection.Open();
                Load();
                Database.Connection.Close();
                Console.ReadKey();
            }
            catch (SqlException e) {
                Console.WriteLine(e.Message);
                Console.WriteLine();
                Console.WriteLine("ESC - Para encerrar");
                while (Console.ReadKey().Key != ConsoleKey.Escape) {
                    Environment.Exit(0);
                }                 
            }
        }

        public static void Load() {
                Console.Clear();
                Console.WriteLine("Meu Blog");
                Console.WriteLine("-----------------");
                Console.WriteLine("O que deseja fazer?");
                Console.WriteLine();
                Console.WriteLine("1 - Gestão de usuário");
                Console.WriteLine("2 - Gestão de perfil");
                Console.WriteLine("3 - Gestão de categoria");
                Console.WriteLine("4 - Gestão de tag");
                Console.WriteLine("5 - Gestão de Posts");
                Console.WriteLine("6 - Vincular perfil/usuário");
                Console.WriteLine("7 - Vincular post/tag");
                Console.WriteLine("8 - Relatórios");
                Console.WriteLine("CTRL + C - Encerrar programa");
                Console.WriteLine();
                Console.WriteLine();
                Console.Write("Opção: ");

                try {
                    var option = short.Parse(Console.ReadLine()!);

                    switch (option) {
                        case 1:
                            MenuUserScreen.Load(); break;

                        case 2:
                            MenuRoleScreen.Load(); break;

                        case 3:
                            MenuCategoryScreen.Load(); break;

                        case 4:
                            MenuTagScreen.Load(); break;

                        case 5:
                            MenuPostScreen.Load(); break;

                        case 6:
                            MenuUserRoleScreen.Load(); break;
                        
                        case 7:
                            Console.WriteLine("MenuPostTagScreen.Load()"); break;
                        
                        case 8:
                            Console.WriteLine("MenuReportsScreen.Load()"); break;

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
