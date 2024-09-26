using xadrez_console.Tabuleiro.Entities;

namespace xadrez_console.Xadrez.Entities {

    internal class PosicaoXadrez {
        public char Coluna { get; set; }
        public int Linha { get; set; }

        public PosicaoXadrez() {
        }

        public PosicaoXadrez(char coluna, int linha) {
            Coluna = coluna;
            Linha = linha;
        }

        public Posicao ToPosicao() {
            return new Posicao(8 - Linha, Coluna - 'a');
        }

        public override string ToString() {
            return "" + Coluna + Linha;
        }
    }
}