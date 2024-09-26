namespace Aula58 {
    internal class Program {
        static void Main(string[] args) {

            string sourcePath = @"C:\Users\gabri\OneDrive\Área de Trabalho\file1.txt";
            string targetPath = @"C:\Users\gabri\OneDrive\Área de Trabalho\file2.txt";

            try {
                FileInfo fileInfo = new FileInfo(sourcePath);
                fileInfo.CopyTo(targetPath);
                string[] lines = File.ReadAllLines(sourcePath);
                foreach (string line in lines) {
                    Console.WriteLine(line);
                }
             }
            catch (IOException e) {
                Console.WriteLine("An error occurred");
                Console.WriteLine(e.Message);
            }
        }
    }
}
