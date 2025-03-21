namespace ServidorOnlineAcess {
    public class Screen {

        public static async Task Load() {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Configurador Equipamento\r\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Deseja configurar o equipamento ? (1 Sim/ 2 Não): ");
            int option = int.Parse(Console.ReadLine());
            switch (option) {
                case 1:
                    await ConfigureDevice();
                    break;

                case 2:
                    break;

                default:
                    Console.WriteLine("Opção inválida");
                    Thread.Sleep(1500);
                    await Load();
                    break;
            }

        }

        public static async Task ConfigureDevice() {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Configuração do Equipamento\r\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Digite o IP do equipamento: ");
            Configuration.IpDevice = Console.ReadLine();
            Console.Write("Digite o login do equipamento: ");
            Configuration.LoginDevice = Console.ReadLine();
            Console.Write("Digite a senha do equipamento: ");
            Configuration.PasswordDevice = Console.ReadLine();

            var a = new Funcionalidades();
            var loginResult = await a.FazerLogin();

            if (loginResult == "OK") {
                await StartOnlineMode();
            }
            else {
                Console.WriteLine("Erro ao fazer login... Aperte qualquer tecla para tentar novamente");
                Console.ReadKey();
                await ConfigureDevice();
            }

        }

        public static async Task StartOnlineMode() {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Configuração do Equipamento\r\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Deseja configurar o equipamento para modo online ? (1 Sim/ 2 Não): ");
            int onlineOption = int.Parse(Console.ReadLine());
            switch (onlineOption) {
                case 1:
                    await Funcionalidades.ConfiguraMonitor();
                    await Funcionalidades.CadastraServidor();
                    await Funcionalidades.ConfiguraServidor();
                    await CreateUser();
                    break;
                case 2:
                    await Funcionalidades.ConfiguraMonitor();
                    await CreateUser();
                    break;
                default:
                    Console.WriteLine("Opção inválida");
                    Thread.Sleep(1500);
                    await StartOnlineMode();
                    break;
            }
        }

        public static async Task CreateUser() {
            Console.Clear();
            Console.Write("1 Facial / 2 Digital / 3 Não informar: ");
            int option = int.Parse(Console.ReadLine());
            switch (option) {
                case 1:
                    await Funcionalidades.CadastraUsuario();
                    await Funcionalidades.CadastraFace();
                    break;
                case 2:
                    await Funcionalidades.CadastraUsuario();
                    await Funcionalidades.CadastraDigital();
                    break;
                case 3:
                    break;
                default:
                    Console.WriteLine("Opção inválida");
                    Thread.Sleep(1500);
                    await ConfigureDevice();
                    break;
            }
        }

    }
}
