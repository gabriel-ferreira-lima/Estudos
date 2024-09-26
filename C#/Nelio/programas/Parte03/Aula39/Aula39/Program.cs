using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace Aula39 {
    internal class Program {
        static void Main(string[] args) {

            //Adicionando elementos na lista logo que é instanciada 
            List<string> lista = new List<string> { "Maria", "Alex" };

            List<string> lista2 = new List<string>();

            Console.WriteLine("----------- Adicionando valores na lista");
            lista2.Add("Maria");
            lista2.Add("Alex");
            lista2.Add("Bob");
            lista2.Add("Anna");
            lista2.Insert(2, "Marco");

            foreach (string n in lista2) {
                Console.WriteLine(n);
            }
            Console.WriteLine("List count: " + lista2.Count);

            Console.WriteLine("------------- Procurando valores na lista a partir de uma condição");
            string s1 = lista2.Find(x => x[0] == 'A');
            Console.WriteLine("First 'A' : " + s1);

            string s2 = lista2.FindLast(x => x[0] == 'A');
            Console.WriteLine("Last 'A' : " + s2);

            Console.WriteLine("------------- Procurando indices na lista a partir de uma condição");
            int pos1 = lista2.FindIndex(x => x[0] == 'A');
            Console.WriteLine("First position 'A'" + pos1);

            int pos2 = lista2.FindLastIndex(x => x[0] == 'A');
            Console.WriteLine("Last position 'A'" + pos2);

            Console.WriteLine("------------- Procurando varios valores na lista a partir de uma condição");
            List<string> lista3 = lista2.FindAll(x => x.Length == 5);
            foreach (string n in lista3) {
                Console.WriteLine(n);
            }

            Console.WriteLine("------------- Removendo um valor da lista");
            lista2.Remove("Alex");
            foreach (string n in lista2) {
                Console.WriteLine(n);
            }
            Console.WriteLine("------------- Removendo varios valores da lista a partir de uma condiçãos");
            lista2.RemoveAll(x => x[0] == 'M');
            foreach (string n in lista2) {
                Console.WriteLine(n);
            }

            Console.WriteLine("------------- Removendo um elemento a partir de sua posição na lista");
            lista2.RemoveAt(0);
            foreach (string n in lista2) {
                Console.WriteLine(n);
            }

            Console.WriteLine("------------- apenas adicionando para continuar o exemplo");
            lista2.Add("Maria");
            lista2.Add("Alex");
            lista2.Add("Bob");
            foreach (string n in lista2) {
                Console.WriteLine(n);
            }

            Console.WriteLine("------------- Removendo varios elementos de uma faixa");
            lista2.RemoveRange(0, 3);
            foreach (string n in lista2) {
                Console.WriteLine(n);
            }
        }
    }
}
