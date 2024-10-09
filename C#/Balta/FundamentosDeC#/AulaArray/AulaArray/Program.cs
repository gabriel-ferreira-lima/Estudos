namespace AulaArray {
    internal class Program {
        static void Main(string[] args) {
            /*
            int[] meuArray = {1,2,3,4,5 }; // inserindo valores no array
            Console.WriteLine(meuArray[0]);

            // criando um array de struct
            Teste[] arrayComStruct = new Teste[2];
            arrayComStruct[0] = new Teste();
            Console.WriteLine(arrayComStruct[0].Id);

            int[] meuArray2 = { 1, 2, 3, 4, 5 };
            meuArray2[0] = 12;

            //percorrendo o array com for
            for (int i = 0; i < meuArray2.Length; i++) {
                Console.WriteLine(meuArray2[i]);
            }

            //percorrendo o array com foreach
            foreach (var i in meuArray2)
                Console.WriteLine(i);
            */

            //criando um array de struct e percorrendo o foreach

            Teste[] teste = new Teste[5];
            teste[0] = new Teste() { Id = 2579, Name = "Gabriel" };

            foreach (Teste i in teste) { 
                Console.WriteLine(i.Id);
                Console.WriteLine(i.Name);
            }
        }

        struct Teste {
            public int Id { get; set; }
            public string Name { get; set; }

        }
    }
}
