using xadrez_console.Tabuleiro.Entities;
using xadrez_console.Tabuleiro.Entities.Enums;
using xadrez_console.Tabuleiro.Entities.Exceptions;

namespace xadrez_console.Xadrez.Entities {

    internal class PartidaDeXadrez {
        public Tab Tab { get; private set; }
        public int Turno { get; private set; }
        public TabuleiroCor JogadorAtual { get; private set; }
        public bool Terminada { get; private set; }
        private HashSet<Peca> _pecas;
        private HashSet<Peca> _capturadas;
        public bool xeque { get; private set; }

        public PartidaDeXadrez() {
            Tab = new Tab(8, 8);
            Turno = 1;
            JogadorAtual = TabuleiroCor.Branca;
            Terminada = false;
            xeque = false;
            _pecas = new HashSet<Peca>();
            _capturadas = new HashSet<Peca>();
            ColocarPecas();
        }

        public Peca ExecutaMovimento(Posicao origem, Posicao destino) {
            Peca p = Tab.RetirarPeca(origem);
            p.IncrementarQteMovimentos();
            Peca pecaCapturada = Tab.RetirarPeca(destino);
            Tab.ColocarPeca(p, destino);
            if (pecaCapturada != null) {
                _capturadas.Add(pecaCapturada);
            }
            return pecaCapturada;
        }

        public void DesfazMovimento(Posicao origem, Posicao destino, Peca pecaCapturada) {
            Peca p = Tab.RetirarPeca(destino);
            p.DecrementarQteMovimentos();
            if (pecaCapturada != null) {
                Tab.ColocarPeca(pecaCapturada, destino);
                _capturadas.Remove(pecaCapturada);
            }
            Tab.ColocarPeca(p, origem);
        }

        public void RealizaJogada(Posicao origem, Posicao destino) {
            Peca pecaCapturada = ExecutaMovimento(origem, destino);

            if (EstaEmXeque(JogadorAtual)) {
                DesfazMovimento(origem, destino, pecaCapturada);
                throw new TabuleiroException("Você não pode se colocar em xeque!");
            }

            if (EstaEmXeque(Adversaria(JogadorAtual))) {
                xeque = true;
            }
            else {
                xeque = false;
            }

            if (TesteXequeMate(Adversaria(JogadorAtual))) {
                Terminada = true;
            }
            else {
                Turno++;
                MudaJogador();
            }
        }

        public void ValidarPosicaoDeOrigem(Posicao pos) {
            if (Tab.Peca(pos) == null) {
                throw new TabuleiroException("Não existe peça na posição de origem escolhida!");
            }
            if (JogadorAtual != Tab.Peca(pos).Cor) {
                throw new TabuleiroException("A peça de origem escolhida não é sua!");
            }
            if (!Tab.Peca(pos).ExisteMovimentosPossiveis()) {
                throw new TabuleiroException("Não há mmovimentos possiveis para a peça de origem escolhida!");
            }
        }

        public void ValidarPosicaoDeDestino(Posicao origem, Posicao destino) {
            if (!Tab.Peca(origem).MovimentoPossivel(destino)) {
                throw new TabuleiroException("Posição de destino inválida!");
            }
        }

        private void MudaJogador() {
            if (JogadorAtual == TabuleiroCor.Branca) {
                JogadorAtual = TabuleiroCor.Preta;
            }
            else {
                JogadorAtual = TabuleiroCor.Branca;
            }
        }

        public HashSet<Peca> PecasCapturadas(TabuleiroCor cor) {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in _capturadas) {
                if (x.Cor == cor) {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Peca> PecasEmJogo(TabuleiroCor cor) {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in _pecas) {
                if (x.Cor == cor) {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(PecasCapturadas(cor));
            return aux;
        }

        private TabuleiroCor Adversaria(TabuleiroCor cor) {
            if (cor == TabuleiroCor.Branca) {
                return TabuleiroCor.Preta;
            }
            else {
                return TabuleiroCor.Branca;
            }
        }

        private Peca Rei(TabuleiroCor cor) {
            foreach (Peca x in PecasEmJogo(cor)) {
                if (x is Rei) {
                    return x;
                }
            }
            return null;
        }

        public bool EstaEmXeque(TabuleiroCor cor) {
            Peca R = Rei(cor);
            if (R == null) {
                throw new TabuleiroException("Não tem rei da cor" + cor + " no tabuleiro!");
            }
            foreach (Peca x in PecasEmJogo(Adversaria(cor))) {
                bool[,] mat = x.MovimentosPossiveis();
                if (mat[R.Posicao.Linha, R.Posicao.Coluna]) {
                    return true;
                }
            }
            return false;
        }

        public bool TesteXequeMate(TabuleiroCor cor) {
            if (!EstaEmXeque(cor)) {
                return false;
            }
            foreach (Peca x in PecasEmJogo(cor)) {
                bool[,] mat = x.MovimentosPossiveis();
                for (int i = 0; i < Tab.Linhas; i++) {
                    for (int j = 0; j < Tab.Colunas; j++) {
                        if (mat[i, j]) {
                            Posicao origem = x.Posicao;
                            Posicao destino = new Posicao(i, j);
                            Peca pecaCapturada = ExecutaMovimento(origem, destino);
                            bool testeXeque = EstaEmXeque(cor);
                            DesfazMovimento(origem, destino, pecaCapturada);
                            if (!testeXeque) {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        public void ColocarNovaPeca(char coluna, int linha, Peca peca) {
            Tab.ColocarPeca(peca, new PosicaoXadrez(coluna, linha).ToPosicao());
            _pecas.Add(peca);
        }

        private void ColocarPecas() {
            ColocarNovaPeca('a', 1, new Torre(TabuleiroCor.Branca, Tab));
            ColocarNovaPeca('b', 1, new Cavalo(TabuleiroCor.Branca, Tab));
            ColocarNovaPeca('c', 1, new Bispo(TabuleiroCor.Branca, Tab));
            ColocarNovaPeca('d', 1, new Dama(TabuleiroCor.Branca, Tab));
            ColocarNovaPeca('e', 1, new Rei(TabuleiroCor.Branca, Tab));
            ColocarNovaPeca('f', 1, new Bispo(TabuleiroCor.Branca, Tab));
            ColocarNovaPeca('g', 1, new Cavalo(TabuleiroCor.Branca, Tab));
            ColocarNovaPeca('h', 1, new Torre(TabuleiroCor.Branca, Tab));
            ColocarNovaPeca('a', 2, new Peao(TabuleiroCor.Branca, Tab));
            ColocarNovaPeca('b', 2, new Peao(TabuleiroCor.Branca, Tab));
            ColocarNovaPeca('c', 2, new Peao(TabuleiroCor.Branca, Tab));
            ColocarNovaPeca('d', 2, new Peao(TabuleiroCor.Branca, Tab));
            ColocarNovaPeca('e', 2, new Peao(TabuleiroCor.Branca, Tab));
            ColocarNovaPeca('f', 2, new Peao(TabuleiroCor.Branca, Tab));
            ColocarNovaPeca('g', 2, new Peao(TabuleiroCor.Branca, Tab));
            ColocarNovaPeca('h', 2, new Peao(TabuleiroCor.Branca, Tab));

            ColocarNovaPeca('a', 8, new Torre(TabuleiroCor.Preta, Tab));
            ColocarNovaPeca('b', 8, new Cavalo(TabuleiroCor.Preta, Tab));
            ColocarNovaPeca('c', 8, new Bispo(TabuleiroCor.Preta, Tab));
            ColocarNovaPeca('d', 8, new Dama(TabuleiroCor.Preta, Tab));
            ColocarNovaPeca('e', 8, new Rei(TabuleiroCor.Preta, Tab));
            ColocarNovaPeca('f', 8, new Bispo(TabuleiroCor.Preta, Tab));
            ColocarNovaPeca('g', 8, new Cavalo(TabuleiroCor.Preta, Tab));
            ColocarNovaPeca('h', 8, new Torre(TabuleiroCor.Preta, Tab));
            ColocarNovaPeca('a', 7, new Peao(TabuleiroCor.Preta, Tab));
            ColocarNovaPeca('b', 7, new Peao(TabuleiroCor.Preta, Tab));
            ColocarNovaPeca('c', 7, new Peao(TabuleiroCor.Preta, Tab));
            ColocarNovaPeca('d', 7, new Peao(TabuleiroCor.Preta, Tab));
            ColocarNovaPeca('e', 7, new Peao(TabuleiroCor.Preta, Tab));
            ColocarNovaPeca('f', 7, new Peao(TabuleiroCor.Preta, Tab));
            ColocarNovaPeca('g', 7, new Peao(TabuleiroCor.Preta, Tab));
            ColocarNovaPeca('h', 7, new Peao(TabuleiroCor.Preta, Tab));
        }
    }
}