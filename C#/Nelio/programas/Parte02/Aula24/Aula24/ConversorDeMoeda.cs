using System.Globalization;
using System.Security.Cryptography;

namespace Aula24 {
    internal class ConversorDeMoeda {

        public static double Iof = 0.06;

        public static double Conversor(double quantia, double cotacao) {
            return quantia * cotacao + (quantia * cotacao * Iof);
        }
    }
}
