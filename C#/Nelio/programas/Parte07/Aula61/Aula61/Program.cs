namespace Aula61 {
    internal class Program {
        static void Main(string[] args) {

            string sourcePath = @"C:\Users\gabri\OneDrive\Área de Trabalho\backup Gabriel\file1.txt";
            string targetPath = @"C:\Users\gabri\OneDrive\Área de Trabalho\backup Gabriel\file2.txt";

            try {
                string[] lines = File.ReadAllLines(sourcePath);

                using (StreamWriter sw = File.AppendText(targetPath)) {
                    foreach (string line in lines) { 
                        sw.WriteLine(line.ToUpper());
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
