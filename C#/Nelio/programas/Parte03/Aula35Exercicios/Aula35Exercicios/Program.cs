namespace Aula35Exercicios {
    internal class Program {
        static void Main(string[] args) {


            Pensao[] vect = new Pensao[10];

            Console.Write("How many rooms will be rented? ");
            int quantidade = int.Parse(Console.ReadLine());

            for (int i = 1; i <= quantidade; i++) {
                Console.WriteLine("Rent #" + i + " :");
                Console.Write("Name: ");
                string nome = Console.ReadLine();
                Console.Write("Email: ");
                string email = Console.ReadLine();
                Console.Write("Room: ");
                int quarto = int.Parse(Console.ReadLine());  
                Console.WriteLine();
                vect[quarto] = new Pensao(nome, email);
            }

            Console.WriteLine("Busy rooms:");
            for (int i = 0; i < vect.Length; i++) {
                if (vect[i] != null)
                    Console.WriteLine(i + ": " + vect[i]);
            }


        }
    }
}
