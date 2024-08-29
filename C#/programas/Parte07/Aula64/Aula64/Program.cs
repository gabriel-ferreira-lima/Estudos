namespace Aula64 {
    internal class Program {
        static void Main(string[] args) {

            string sourcePath = @"C:\Users\gabri\OneDrive\Área de Trabalho\backup Gabriel\file.csv";

            try {
                string[] lines = File.ReadAllLines(sourcePath);
                
            }
            catch (IOException e) {
                Console.WriteLine("An error occurred");
                Console.WriteLine(e.Message);
            }


        }
    }
}
