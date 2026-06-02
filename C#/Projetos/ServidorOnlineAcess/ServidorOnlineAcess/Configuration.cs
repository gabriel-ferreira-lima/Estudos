using System.Net;

namespace ServidorOnlineAcess {
    public static class Configuration {

        public static string IpDevice { get; set; } = "192.168.0.129";
        public static string LoginDevice { get; set; } = "admin";
        public static string PasswordDevice { get; set; } = "admin";
        public static string TokenDevice { get; set; } = null!;
        public static DateTime PushExample { get; set; } = DateTime.Now;

        public static string IpServer { get; set; } = Dns.GetHostAddresses(Dns.GetHostName())
                  .FirstOrDefault(ip => ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)?
                  .ToString() ?? null!;
        public static string PortServer { get; set; } = null!;

        public static void Initialize(IConfiguration configuration) {
            Configuration.PortServer = configuration.GetValue<string>("ServerSettings:Port")!;
        }

    }
}
