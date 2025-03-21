using System.Text;
using System.Text.Json;
using static System.Net.WebRequestMethods;

namespace GeradorDeSenha {
    class Funcionalidades {

        public static async Task<string> FazerLogin() {

            using (var httpClient = new HttpClient()) {
                var url = "https://www.rhid.com.br/v2/login.svc/";
                var requestBody = new {
                    email = Program.Email,
                    password = Program.Senha
                };

                var json = JsonSerializer.Serialize(requestBody);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                try {
                    var response = await httpClient.PostAsync(url, content);
                    var responseString = await response.Content.ReadAsStringAsync();

                    using var jsonDoc = JsonDocument.Parse(responseString);
                    var sessionValue = jsonDoc.RootElement.GetProperty("accessToken").GetString();

                    Program.TokenDevice = sessionValue;
                    return response.StatusCode.ToString();

                }
                catch (Exception e) {
                    return e.Message.ToString();
                }
            }
        }

        public static async Task<string> GerarSenhaRootAcesso(string serial) {
            using (var httpClient = new HttpClient()) {

                var url = $"https://rhid.com.br/v2/util.svc/senha_root/?serial={serial.ToUpper()}";
                var request = new HttpRequestMessage(HttpMethod.Get, url);
                request.Headers.Add("Authorization", $"Bearer {Program.TokenDevice}");
                var json = JsonSerializer.Serialize(request);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                try {

                    var response = await httpClient.SendAsync(request);
                    var responseString = await response.Content.ReadAsStringAsync();

                    string[] partes = responseString.Split(',');
                    if (partes[1].Length > 2) {
                        string valor = partes[1].Trim().Trim('"');
                        return valor;
                    }
                    else {
                        string valor = partes[3].Trim().Trim('"', ']');
                        return valor;
                    }
                }
                catch (Exception e) {
                    return e.Message.ToString();
                }
            }
        }

        public static async Task<string> GerarContraSenhaRep(string serial, string senha) {
            using (var httpClient = new HttpClient()) {

                var url = $"https://rhid.com.br/v2/util.svc/desbloqueio_rep_violacao/?serial={serial.ToUpper()}&senha={senha}";
                var request = new HttpRequestMessage(HttpMethod.Get, url);
                request.Headers.Add("Authorization", $"Bearer {Program.TokenDevice}");
                var json = JsonSerializer.Serialize(request);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                try {

                    var response = await httpClient.SendAsync(request);
                    var responseString = await response.Content.ReadAsStringAsync();

                    //["","","Tamanho da senha inválido para iDClass!",""]

                    string[] partes = responseString.Split(',');
                    if (partes[0].Length > 2) {
                        string valor = partes[0].Trim().Trim('"', '[');
                        return valor;
                    }
                    else {
                        string valor = partes[2].Trim().Trim('"');
                        return valor;
                    }
                }
                catch (Exception e) {
                    return e.Message.ToString();
                }
            }
        }
    }
}
