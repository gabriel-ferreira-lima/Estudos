using System.Text;

namespace Exercicio4 {
    public class Editor {

        public static void Show() {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.WriteLine("MODO EDITOR");
            Console.WriteLine("-----------");
            Start();
        }
        public static void Start() {
            StringBuilder file = new StringBuilder();

            while (Console.ReadKey().Key != ConsoleKey.Escape) {
                file.Append(Console.ReadLine());
                file.Append(Environment.NewLine);
            }

            Console.WriteLine("--------------------------------");
            Console.Write("ADeseja Salvar o arquivo (S/N): ");
            char saveFileOption = char.Parse(Console.ReadLine().ToLower());

            if (saveFileOption == 's') {
                Console.WriteLine("Digite o diretório que você deseja Salvar");
                Console.Write("-> ");
                string filename = @"\Documento de Texto.txt";
                string path = Console.ReadLine();
                using (StreamWriter saveFile = new StreamWriter(path + filename)) {
                    saveFile.WriteLine(file);
                }

                Viewer.Show(file.ToString());
            }
            else if (saveFileOption == 'n') {
                Viewer.Show(file.ToString());
            }

        }
    }
}

