namespace GeradorDeSenha {
    class Screen {

        public static async Task Load() {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Gerador de Senha Root ControlID\r\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("1 - Gerar senha root da linha de acesso");
            Console.WriteLine("2 - Gerar senha de desbloqueio do REP");
            Console.WriteLine("para sair aperte: Ctrl C\r\n");
            Console.Write("Digite a opção desejada: ");
            int option = int.Parse(Console.ReadLine());
            switch (option) {
                case 1:
                    await GenerateRootPassword();
                    break;
                case 2:
                    await GenerateRepPassword();
                    break;
                default:
                    Console.WriteLine("Opção inválida");
                    Console.ReadKey();
                    await Load();
                    break;
            }
        }

        public static async Task GenerateRootPassword() {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Senha root linha de acesso");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Número de série do equipamento: ");
            string? serial = Console.ReadLine();
            string senha = await Funcionalidades.GerarSenhaRootAcesso(serial);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\r\n{senha}\r\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Aperte qualquer tecla para voltar");
            Console.ReadKey();
            await Load();
        }

        public static async Task GenerateRepPassword() {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Desbloqueio do REP");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Número de série do equipamento: ");
            string? serial = Console.ReadLine();
            Console.Write("Senha do REP: ");
            string? senha = Console.ReadLine();
            string contraSenha = await Funcionalidades.GerarContraSenhaRep(serial, senha);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\r\n{contraSenha}\r\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Aperte qualquer tecla para voltar");
            Console.ReadKey();
            await Load();
        }
    }
}
