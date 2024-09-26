namespace Aula43 {
    internal class Program {
        static void Main(string[] args) {
            string[] vect = Console.ReadLine().Split(" ");

            int l = int.Parse(vect[0]);
            int c = int.Parse(vect[1]);

            int[,] mat = new int[l, c];

            for (int i = 0; i < l; i++) {
                string[] vect1 = Console.ReadLine().Split(" ");
                for (int j = 0; j < c; j++) {
                    mat[i, j] = int.Parse(vect1[j]);

                }
            }

            int number = int.Parse(Console.ReadLine());

            for (int i = 0; i < l; i++) {
                for (int j = 0; j < c; j++) {
                    if (mat[i, j] == number) {
                        Console.WriteLine("Position " + i + "," + j + ":");
                        if (j > 0) {
                            Console.WriteLine("left: " + mat[i, j - 1]);
                        }
                        if (i > 0) {
                            Console.WriteLine("Up: " + mat[i - 1, j]);
                        }
                        if (i < l - 1) {
                            Console.WriteLine("Down: " + mat[i + 1, j]);
                        }
                        if (j < c -1 ) {
                            Console.WriteLine("Right: " + mat[i, j + 1]);
                        }
                    }
                }
            }
        }
    }
}
