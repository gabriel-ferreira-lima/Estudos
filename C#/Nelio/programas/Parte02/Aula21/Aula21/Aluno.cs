using System.Globalization;
using System;

namespace Aula21 {
    internal class Aluno {

        public string Nome;
        public double N1;
        public double N2;
        public double N3;

        public double NotaFinal() {
            return N1 + N2 + N3;
        }

        public bool Aprovado() {
            if (NotaFinal() >= 60) {
                return true;
            }
            else {
                return false;
            }
        }
        public double NotaRestante() {
            if(Aprovado() == true) {
                return 0.0;
            }
            else {
                return 60.0 - NotaFinal();
            }

        }
    }



}

