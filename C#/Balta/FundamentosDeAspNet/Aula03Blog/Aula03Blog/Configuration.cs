namespace Aula03Blog {
    public static class Configuration {
        // Token - JWT - Json Web Token
        public static string JwtKey { get; set; } =
            "NDhmYTExOTA1MTY4NDA3NTlkYmE2ZWQ2NDkzZDFhM2Y="; // essa chave será essencial para gerar os tokens nesse caso peguei um guid
        // Guid.NewGuid(); depois transformei ele em base64


        // criando um conceito diferente de criar uma chave além do JWT, essa aqui não expira nunca
        // ver na pasta attributes e na homeController
        public static string ApiKeyName { get; set; } = "APIKey";
        public static string ApiKey { get; set; } = "curso_api_IlTevUM/z0ey3NwCV/unWg==";
        
        
        
        public static SmtpConfiguration Smtp { get; set; } = new ();
        public class SmtpConfiguration {
            
            public string Host { get; set; }
            public int Port { get; set; } = 25;
            public string Username { get; set; }
            public string Password { get; set; }
        }
    }
}