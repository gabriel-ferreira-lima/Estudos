namespace Aula60 {
    internal class Program {
        static void Main(string[] args) {


            string path = @"C:\Users\gabri\OneDrive\Área de Trabalho\backup Gabriel\file1.txt";
            try {
                using (StreamReader sr = File.OpenText(path)) {
                    while (!sr.EndOfStream) {
                        string line = sr.ReadLine();
                        Console.WriteLine(line);
                    }
                }

            }
            catch (IOException e) {
                Console.WriteLine("An error occurred");
                Console.WriteLine(e.Message);
            }
        }
    }
}
