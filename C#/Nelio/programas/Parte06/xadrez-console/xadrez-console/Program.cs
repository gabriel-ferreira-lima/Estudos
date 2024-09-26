using xadrez_console.Tabuleiro.Entities;
using xadrez_console.Tabuleiro.Entities.Exceptions;
using xadrez_console.Xadrez.Entities;

namespace xadrez_console {

    internal class Program {

        private static void Main(string[] args) {
            try {
                PartidaDeXadrez partida = new PartidaDeXadrez();

                while (!partida.Terminada) {
                    try {
                        Console.Clear();
                        Tela.ImprimirPartida(partida);

                        Console.WriteLine();
                        Console.Write("Origem: ");
                        Posicao origem = Tela.LerPosicaoXadrez().ToPosicao();
                        partida.ValidarPosicaoDeOrigem(origem);

                        bool[,] PosicoesPossiveis = partida.Tab.Peca(origem).MovimentosPossiveis();

                        Console.Clear();
                        Tela.ImprimirTabuleiro(partida.Tab, PosicoesPossiveis);

                        Console.WriteLine();
                        Console.Write("Destino: ");
                        Posicao destino = Tela.LerPosicaoXadrez().ToPosicao();
                        partida.ValidarPosicaoDeDestino(origem, destino);

                        partida.RealizaJogada(origem, destino);
                    }
                    catch (TabuleiroException e) {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }

                Console.Clear();
                Tela.ImprimirPartida(partida);
            }
            catch (TabuleiroException e) {
                Console.WriteLine(e.Message);
            }
        }
    }
}