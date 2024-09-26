using Aula64.Entities;
using System.Globalization;

namespace Aula64 {
    internal class Program {
        static void Main(string[] args) {

            Console.Write("Entre source path: ");
            string sourcePath = Console.ReadLine();

            try {                
                string sourceFolderPath = Path.GetDirectoryName(sourcePath);
                string targetFolderPath = sourceFolderPath + @"\out";
                string targetFilePath = targetFolderPath + @"\summary.csv";

                Directory.CreateDirectory(targetFolderPath);

                string[] lines = File.ReadAllLines(sourcePath);

                using (StreamWriter sw = new StreamWriter(targetFilePath)) {
                    foreach (string line in lines) {

                        string[] fields = line.Split(',');
                        string name = fields[0];
                        double value = double.Parse(fields[1], CultureInfo.InvariantCulture);
                        int quantity = int.Parse(fields[2]);

                        Product p = new Product(name, value, quantity);

                        sw.WriteLine(p);

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
