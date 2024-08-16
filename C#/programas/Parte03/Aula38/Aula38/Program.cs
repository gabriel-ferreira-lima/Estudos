namespace Aula38 {
    internal class Program {
        static void Main(string[] args) {

            string[] vect = new string[] { "Maria", "Alex", "Bob" };

            //utilizando for
            for (int i = 0; i < vect.Length; i++) {
                Console.WriteLine(vect[i]);
            }

            Console.WriteLine("--------------------------------");

            //utilizando foreach
            foreach(string i  in vect) {
                Console.WriteLine(i);
            }
        }
    }
}
