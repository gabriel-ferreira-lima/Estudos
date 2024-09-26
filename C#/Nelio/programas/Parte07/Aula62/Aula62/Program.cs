namespace Aula62 {
    internal class Program {
        static void Main(string[] args) {

            string path = @"C:\Users\gabri\OneDrive\Área de Trabalho\backup Gabriel\myfolder";

            try {
                IEnumerable<string> folders = Directory.EnumerateDirectories(path, "*.*", SearchOption.AllDirectories);
                Console.WriteLine("FOLDERS");
                foreach (string c in folders) {
                    Console.WriteLine(c);
                }
                Console.WriteLine();

                IEnumerable<string> files = Directory.EnumerateFiles(path, "*.*", SearchOption.AllDirectories);
                Console.WriteLine("Files");
                foreach (string c in files) {
                    Console.WriteLine(c);
                }

                Directory.CreateDirectory(path + @"\newfolder");

            }
            catch (IOException e) {
                Console.WriteLine("An error occurred");
                Console.WriteLine(e.Message);
            }
        }
    }
}
