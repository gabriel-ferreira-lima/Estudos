using System.Net;

namespace ServidorOnlineAcess {
    public static class Configuration {

        public static string IpDevice { get; set; }
        public static string LoginDevice { get; set; }
        public static string PasswordDevice { get; set; }
        public static string TokenDevice { get; set; }

        public static string IpServer { get; set; } = Dns.GetHostAddresses(Dns.GetHostName())
                  .FirstOrDefault(ip => ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)?
                  .ToString() ?? null;
        public static string PortServer { get; set; }

        public static void Initialize(IConfiguration configuration) {
            Configuration.PortServer = configuration.GetValue<string>("ServerSettings:Port");
        }

    }
}
