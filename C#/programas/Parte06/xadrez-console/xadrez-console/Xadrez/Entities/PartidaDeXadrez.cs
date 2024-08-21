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
        public Peca VulneravelEnPassant { get; private set; }

        public PartidaDeXadrez() {
            Tab = new Tab(8, 8);
            Turno = 1;
            JogadorAtual = TabuleiroCor.Branca;
            Terminada = false;
            xeque = false;
            VulneravelEnPassant = null;
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

            // # Jogada especial roque pequeno
            if (p is Rei && destino.Coluna == origem.Coluna + 2) {
                Posicao origemT = new Posicao(origem.Linha, origem.Coluna + 3);
                Posicao destinoT = new Posicao(origem.Linha, origem.Coluna + 1);
                Peca T = Tab.RetirarPeca(origemT);
                T.IncrementarQteMovimentos();
                Tab.ColocarPeca(T, destinoT);
            }

            // # Jogada especial roque grande
            if (p is Rei && destino.Coluna == origem.Coluna - 2) {
                Posicao origemT = new Posicao(origem.Linha, origem.Coluna - 4);
                Posicao destinoT = new Posicao(origem.Linha, origem.Coluna - 1);
                Peca T = Tab.RetirarPeca(origemT);
                T.IncrementarQteMovimentos();
                Tab.ColocarPeca(T, destinoT);
            }

            // # Jogada especial en passant
            if (p is Peao) {
                if (origem.Coluna != destino.Coluna && pecaCapturada == null) {
                    Posicao posP;
                    if (p.Cor == TabuleiroCor.Branca) {
                        posP = new Posicao(destino.Linha + 1, destino.Coluna);
                    }
                    else {
                        posP = new Posicao(destino.Linha - 1, destino.Coluna);
                    }
                    pecaCapturada = Tab.RetirarPeca(posP);
                    _capturadas.Add(pecaCapturada);
                }
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

            // # Jogada especial roque pequeno
            if (p is Rei && destino.Coluna == origem.Coluna + 2) {
                Posicao origemT = new Posicao(origem.Linha, origem.Coluna + 3);
                Posicao destinoT = new Posicao(origem.Linha, origem.Coluna + 1);
                Peca T = Tab.RetirarPeca(destinoT);
                T.DecrementarQteMovimentos();
                Tab.ColocarPeca(T, origemT);
            }

            // # Jogada especial roque grande
            if (p is Rei && destino.Coluna == origem.Coluna - 2) {
                Posicao origemT = new Posicao(origem.Linha, origem.Coluna - 4);
                Posicao destinoT = new Posicao(origem.Linha, origem.Coluna - 1);
                Peca T = Tab.RetirarPeca(destinoT);
                T.IncrementarQteMovimentos();
                Tab.ColocarPeca(T, origemT);
            }

            // # Jogada especial en passant
            if (p is Peao) {
                if (origem.Coluna != destino.Coluna && pecaCapturada == VulneravelEnPassant) {
                    Peca peao = Tab.RetirarPeca(destino);
                    Posicao posP;
                    if (p.Cor == TabuleiroCor.Branca) {
                        posP = new Posicao(3, destino.Coluna);
                    }
                    else {
                        posP = new Posicao(4, destino.Coluna);
                    }
                    Tab.ColocarPeca(peao, posP);
                }
            }
        }

        public void RealizaJogada(Posicao origem, Posicao destino) {
            Peca pecaCapturada = ExecutaMovimento(origem, destino);

            if (EstaEmXeque(JogadorAtual)) {
                DesfazMovimento(origem, destino, pecaCapturada);
                throw new TabuleiroException("Você não pode se colocar em xeque!");
            }

            Peca p = Tab.Peca(destino);

            // # Jogada especial promocao
            if (p is Peao) {
                if ((p.Cor == TabuleiroCor.Branca && destino.Linha == 0) || (p.Cor == TabuleiroCor.Preta && destino.Linha == 7)) {
                    p = Tab.RetirarPeca(destino);
                    _pecas.Remove(p);
                    Peca dama = new Dama(p.Cor, Tab);
                    Tab.ColocarPeca(dama, destino);
                    _pecas.Add(dama);
                }
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

            // # Jogada especial en passant
            if (p is Peao && (destino.Linha == origem.Linha - 2 || destino.Linha == origem.Linha + 2)) {
                VulneravelEnPassant = p;
            }
            else {
                VulneravelEnPassant = null;
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
            ColocarNovaPeca('e', 1, new Rei(TabuleiroCor.Branca, Tab, this));
            ColocarNovaPeca('f', 1, new Bispo(TabuleiroCor.Branca, Tab));
            ColocarNovaPeca('g', 1, new Cavalo(TabuleiroCor.Branca, Tab));
            ColocarNovaPeca('h', 1, new Torre(TabuleiroCor.Branca, Tab));
            ColocarNovaPeca('a', 2, new Peao(TabuleiroCor.Branca, Tab, this));
            ColocarNovaPeca('b', 2, new Peao(TabuleiroCor.Branca, Tab, this));
            ColocarNovaPeca('c', 2, new Peao(TabuleiroCor.Branca, Tab, this));
            ColocarNovaPeca('d', 2, new Peao(TabuleiroCor.Branca, Tab, this));
            ColocarNovaPeca('e', 2, new Peao(TabuleiroCor.Branca, Tab, this));
            ColocarNovaPeca('f', 2, new Peao(TabuleiroCor.Branca, Tab, this));
            ColocarNovaPeca('g', 2, new Peao(TabuleiroCor.Branca, Tab, this));
            ColocarNovaPeca('h', 2, new Peao(TabuleiroCor.Branca, Tab, this));

            ColocarNovaPeca('a', 8, new Torre(TabuleiroCor.Preta, Tab));
            ColocarNovaPeca('b', 8, new Cavalo(TabuleiroCor.Preta, Tab));
            ColocarNovaPeca('c', 8, new Bispo(TabuleiroCor.Preta, Tab));
            ColocarNovaPeca('d', 8, new Dama(TabuleiroCor.Preta, Tab));
            ColocarNovaPeca('e', 8, new Rei(TabuleiroCor.Preta, Tab, this));
            ColocarNovaPeca('f', 8, new Bispo(TabuleiroCor.Preta, Tab));
            ColocarNovaPeca('g', 8, new Cavalo(TabuleiroCor.Preta, Tab));
            ColocarNovaPeca('h', 8, new Torre(TabuleiroCor.Preta, Tab));
            ColocarNovaPeca('a', 7, new Peao(TabuleiroCor.Preta, Tab, this));
            ColocarNovaPeca('b', 7, new Peao(TabuleiroCor.Preta, Tab, this));
            ColocarNovaPeca('c', 7, new Peao(TabuleiroCor.Preta, Tab, this));
            ColocarNovaPeca('d', 7, new Peao(TabuleiroCor.Preta, Tab, this));
            ColocarNovaPeca('e', 7, new Peao(TabuleiroCor.Preta, Tab, this));
            ColocarNovaPeca('f', 7, new Peao(TabuleiroCor.Preta, Tab, this));
            ColocarNovaPeca('g', 7, new Peao(TabuleiroCor.Preta, Tab, this));
            ColocarNovaPeca('h', 7, new Peao(TabuleiroCor.Preta, Tab, this));
        }
    }
}