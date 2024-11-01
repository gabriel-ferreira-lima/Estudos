import requests
import socket


def ColetaIpLocal():
    s = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
    try:
        s.connect(("8.8.8.8", 80))
        ipServidor = s.getsockname()[0]
    except Exception:
        ipServidor = "127.0.0.1"
    finally:
        s.close()
    return ipServidor

def InsereDadosDoDispositivo():
    global ip, usuario, senha, tipoDispositivo
    ip = input("IP do dispositivo: ")
    usuario = input("Usuário do dispositivo: ")
    senha = input("Senha do dispositivo: ")
    tipoDispositivo = input("digital 1 / facial 2: ")
    if tipoDispositivo == '1' or tipoDispositivo == '2':
        pass
    else :
        print("Insira um tipo de dispositivo Valido...")
        InsereDadosDoDispositivo()

    sessao = FazerLogin(ip, usuario, senha)
    if sessao:
        Criaservidor(ip, sessao)
        CadastraUsuario(ip, sessao)
        CadastraCredencial(ip, sessao, tipoDispositivo)

def FazerLogin(ip, usuario, senha):
    try:
        request = requests.post(f"http://{ip}/login.fcgi", json={
            "login": usuario,
            "password": senha
        })

        print(f"Status: {request.status_code} - {request.reason}")
        if request.status_code == 200:
            login_data = request.json()
            sessao = login_data.get('session')
            if sessao:
                print("Login bem-sucedido.")
                return sessao
            else:
                print("Erro ao obter sessão.")
        else:
            print("Falha no login.")
        return None

    except Exception as e:
        print(f"Ocorreu um erro: {e}")
        print("Voltando para a entrada dos dados do dispositivo...")
        InsereDadosDoDispositivo()

def Criaservidor(ip, sessao):
    ipServidor = ColetaIpLocal()
    request = requests.post(f'http://{ip}/create_objects.fcgi?session={sessao}', json={
        "object": "devices",
        "values": [
            {
                "id" : -2,
                "name": "Flask Server",
                "ip": f"{ipServidor}:8002"
            }
        ]
    })

    request = requests.post(f'http://{ip}/set_configuration.fcgi?session={sessao}', json={
        "general": {
            "online": "1",
            "local_identification": "1"
        },
        "online_client": {
          "extract_template": "1",
          "server_id" : "-2"
        }
    })

def CadastraUsuario(ip, sessao):
    try:
        request = requests.post(f"http://{ip}/create_objects.fcgi?session={sessao}", json={
            'object': 'users',
            'values': [{
                'id': 1000,
                'registration': '0',
                'name': 'Usuario Teste',
                'password': "",
                'salt': ""
            }]
        })
        print(f"Cadastro de usuário: {request.status_code}")
    except Exception as e:
        print(f"Erro ao cadastrar usuário: {e}")

def CadastraCredencial(ip, sessao, tipoDispositivo):
    if tipoDispositivo == "2":
        try:
            request = requests.post(f"http://{ip}/remote_enroll.fcgi?session={sessao}", json={
                "type": "face",
                "user_id": 1000,
                "save": True,
                "sync": True,
                "auto": False
            })
            print(f"Cadastro de foto: {request.status_code}")
        except Exception as e:
            print(f"Erro ao cadastrar foto: {e}")
    else :
        try:
            request = requests.post(f"http://{ip}/remote_enroll.fcgi?session={sessao}", json={
                "type": "biometry",
                "user_id": 1000,
                "save": True,
                "sync": True,
                "panic_finger": 0
            })
            print(f"Cadastro de foto: {request.status_code}")
        except Exception as e:
            print(f"Erro ao cadastrar foto: {e}")