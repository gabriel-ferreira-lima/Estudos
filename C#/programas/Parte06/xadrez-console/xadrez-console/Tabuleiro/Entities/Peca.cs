using xadrez_console.Tabuleiro.Entities.Enums;

namespace xadrez_console.Tabuleiro.Entities {

    internal abstract class Peca {
        public Posicao Posicao { get; set; }
        public TabuleiroCor Cor { get; set; }
        public int QteMovimentos { get; protected set; }
        public Tab Tab { get; protected set; }

        public Peca() {
        }

        public Peca(TabuleiroCor cor, Tab tab) {
            Posicao = null;
            Cor = cor;
            QteMovimentos = 0;
            Tab = tab;
        }

        public void IncrementarQteMovimentos() {
            QteMovimentos++;
        }

        public void DecrementarQteMovimentos() {
            QteMovimentos--;
        }

        public bool ExisteMovimentosPossiveis() {
            bool[,] mat = MovimentosPossiveis();
            for (int i = 0; i < Tab.Linhas; i++) {
                for (int j = 0; j < Tab.Linhas; j++) {
                    if (mat[i, j]) {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool MovimentoPossivel(Posicao pos) {
            return MovimentosPossiveis()[pos.Linha, pos.Coluna];
        }

        public abstract bool[,] MovimentosPossiveis();
    }
}