namespace Aula03Blog {
    public static class Configuration {
        // Token - JWT - Json Web Token
        public static string JwtKey { get; set; } 


        public static string ApiKeyName { get; set; }
        public static string ApiKey { get; set; }


        public static string ImageDirectory { get; set; }


        public static SmtpConfiguration Smtp { get; set; } = new ();
        public class SmtpConfiguration {
            
            public string Host { get; set; }
            public int Port { get; set; } = 25;
            public string Username { get; set; }
            public string Password { get; set; }
        }
    }
}