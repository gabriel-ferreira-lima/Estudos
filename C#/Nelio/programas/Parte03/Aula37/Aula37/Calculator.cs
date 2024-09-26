namespace Aula37 {
    internal class Calculator {

        // Utilizando REF
        public static void Triple(ref int x) {
            x = x * 3;
        }

        // Utilizando OUT
        public static void Triple2(int origin, out int x) {
            x = origin * 3;
        }
    }
}
