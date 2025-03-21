using System.Text.Json;
using System.Text;

namespace ServidorOnlineAcess {
    public class Funcionalidades {


        public async Task<string> FazerLogin() {
            using (var client = new HttpClient()) {

                var url = $"http://{Configuration.IpDevice}/login.fcgi";
                var requestData = new {
                    login = Configuration.LoginDevice,
                    password = Configuration.PasswordDevice
                };

                var json = JsonSerializer.Serialize(requestData);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                try {
                    var response = await client.PostAsync(url, content);
                    var responseBody = await response.Content.ReadAsStringAsync();

                    using var jsonDoc = JsonDocument.Parse(responseBody);
                    var sessionValue = jsonDoc.RootElement.GetProperty("session").GetString();

                    Configuration.TokenDevice = sessionValue;
                    return response.StatusCode.ToString();
                }
                catch (Exception e) {
                    return StatusCodes.Status500InternalServerError.ToString();
                }
            }
        }

        public static async Task CadastraUsuario() {
            using (var client = new HttpClient()) {

                var url = $"http://{Configuration.IpDevice}/create_or_modify_objects.fcgi?session={Configuration.TokenDevice}";
                var requestData = new {
                    @object = "users",
                    values = new[] { new {
                            id = 1000,
                            name = "Douglas Miguel",
                            registration = "",
                            password = "",
                            salt = ""
                        }},
                    where = new {
                        users = new {
                            id = 1000
                        }
                    }
                };

                var json = JsonSerializer.Serialize(requestData);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                try {
                    var response = await client.PostAsync(url, content);
                    var responseBody = await response.Content.ReadAsStringAsync();
                }
                catch (Exception e) {
                }
            }
        }

        public static async Task CadastraFace() {
            using (var client = new HttpClient()) {

                var url = $"http://{Configuration.IpDevice}/remote_enroll.fcgi?session={Configuration.TokenDevice}";
                var requestData = new {
                    type = "face",
                    user_id = 1000,
                    save = true,
                    sync = true,
                    auto = false
                };
                var json = JsonSerializer.Serialize(requestData);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                try {
                    var response = await client.PostAsync(url, content);
                    var responseBody = await response.Content.ReadAsStringAsync();
                }
                catch (Exception e) {

                }

            }
        }

        public static async Task CadastraDigital() {
            using (var client = new HttpClient()) {

                var url = $"http://{Configuration.IpDevice}/remote_enroll.fcgi?session={Configuration.TokenDevice}";
                var requestData = new {
                    type = "biometry",
                    user_id = 1000,
                    save = true,
                    sync = true,
                    panic_finger = 0
                };
                var json = JsonSerializer.Serialize(requestData);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                try {
                    var response = await client.PostAsync(url, content);
                    var responseBody = await response.Content.ReadAsStringAsync();
                }
                catch (Exception e) {

                }

            }
        }

        public static async Task CadastraServidor() {
            using (var client = new HttpClient()) {

                var url = $"http://{Configuration.IpDevice}/create_or_modify_objects.fcgi?session={Configuration.TokenDevice}";
                var requestData = new {
                    @object = "devices",
                    values = new[] { new {
                            id = -2,
                            name = "C# Server",
                            ip = $"{Configuration.IpServer}:{Configuration.PortServer}"
                        }},
                    where = new {
                        devices = new {
                            id = -2
                        }
                    }
                };

                var json = JsonSerializer.Serialize(requestData);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                try {
                    var response = await client.PostAsync(url, content);
                    var responseBody = await response.Content.ReadAsStringAsync();

                }
                catch (Exception e) {
                }
            }
        }

        public static async Task ConfiguraServidor() {
            using (var client = new HttpClient()) {

                var url = $"http://{Configuration.IpDevice}/set_configuration.fcgi?session={Configuration.TokenDevice}";
                var requestData = new {
                    general = new {
                        online = "1",
                        local_identification = "1"
                    },
                    online_client = new {
                        server_id = "-2",
                        extract_template = "0",
                        max_request_attempts = "3"
                    }
                };

                var json = JsonSerializer.Serialize(requestData);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                try {
                    var response = await client.PostAsync(url, content);
                    var responseBody = await response.Content.ReadAsStringAsync();

                }
                catch (Exception e) {
                }
            }
        }

        public static async Task ConfiguraMonitor() {
            using (var client = new HttpClient()) {

                var url = $"http://{Configuration.IpDevice}/set_configuration.fcgi?session={Configuration.TokenDevice}";
                var requestData = new {
                    monitor = new {
                        request_timeout = "5000",
                        hostname = Configuration.IpServer,
                        port = Configuration.PortServer,
                        path = "api/notifications"

                    }
                };

                var json = JsonSerializer.Serialize(requestData);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                try {

                    var response = await client.PostAsync(url, content);
                    var requestBody = await response.Content.ReadAsStringAsync();
                }
                catch (Exception e) {
                }
            }
        }

    }
}
