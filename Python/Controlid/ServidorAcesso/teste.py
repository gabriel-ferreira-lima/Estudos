import requests
import socket
import base64
from flask import Flask, request, jsonify, send_file
app = Flask(__name__)

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
    tipoDispositivo = input("digital 1 / facial 2 / não informar 3: ")
    if tipoDispositivo == '1' or tipoDispositivo == '2' or tipoDispositivo == '3':
        pass
    else :
        print("Insira um tipo de dispositivo Valido...")
        InsereDadosDoDispositivo()

    sessao = FazerLogin(ip, usuario, senha)
    if sessao:
        Criaservidor(ip, sessao)
        CadastraUsuario(ip, sessao)
        if tipoDispositivo == '1' or tipoDispositivo == '2':
            CadastraCredencial(ip, sessao, tipoDispositivo)
        else :
            pass

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
                "id" : -3,
                "name": "Flask Server",
                "ip": f"{ipServidor}:3035"
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
          "server_id" : "-3"
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


responseAutorizado = {
    "result": {
        "event": 7,
        "user_id": 6,
        "user_name": "Neal Caffrey",
        "user_image": True,
        "portal_id": 1,
        "actions": [
            {
                "action": "door",
                "parameters": "door=1"
            }
        ]
    }
}

responseNaoAutorizado = {
    "result": {
        "event": 6,
        "user_id": 1,
        "user_name": "não autorizado",
        "user_image": True,
        "portal_id": 1,
        "actions": []
    }
}

responseTeste = {
    "result":{
        "event":3,
        "user_id" : 0,
        "user_name": "",
        "user_image":False,
        "portal_id":0,
        "actions":[]
        }
}


# APIs do modo online
@app.route('/device_is_alive.fcgi', methods=['POST'])
def device_is_alive():
    return jsonify(), 200, print("OK")


@app.route('/new_user_identified.fcgi', methods=['POST'])
def new_user_identified():
    try :
        # Recebendo parâmetros do corpo da requisição
        device_id = request.form.get('device_id', type=int)
        identifier_id = request.form.get('identifier_id', type=int)
        component_id = request.form.get('component_id', type=int)
        event = request.form.get('event', type=int)
        user_id = request.form.get('user_id', type=int)
        duress = request.form.get('duress', type=int)
        face_mask = request.form.get('face_mask', type=lambda x: x.lower() == 'true')
        timestamp = request.form.get('time', type=int)
        portal_id = request.form.get('portal_id', type=int)
        uuid = request.form.get('uuid', type=str)
        block_read_data = request.form.get('block_read_data', type=str)
        block_read_error = request.form.get('block_read_error', type=int)
        card_value = request.form.get('card_value', type=int)
        qrcode_value = request.form.get('qrcode_value', type=str)
        uhf_tag = request.form.get('uhf_tag', type=str)
        pin_value = request.form.get('pin_value', type=str)
        user_has_image = request.form.get('user_has_image', type=int)
        user_name = request.form.get('user_name', type=str)
        password = request.form.get('password', type=str)
        confidence = request.form.get('confidence', type=int)
        log_type_id = request.form.get('log_type_id', type=int)

        if user_id > 0:
            print("Acesso autorizado")
            return jsonify(responseAutorizado), 200
        else:
            print("Acesso negado")
            return jsonify(responseTeste), 200

    except Exception as e :
        return jsonify({"error": str(e)}), 500


@app.route('/new_biometric_image.fcgi', methods=['POST'])
def new_biometric_image():
    try :
        device_id = request.args.get('device_id')
        identifier_id = request.args.get('identifier_id')
        width = request.args.get('width')
        height = request.args.get('height')
        session = request.args.get('session')
        time = request.args.get('time')
        portal_id = request.args.get('portal_id')
        uuid = request.args.get('uuid')
        variance = request.args.get('variance')

        return jsonify(responseAutorizado), 200
        binary_data = request.data


    except Exception as e:
        return jsonify({"error": str(e)}), 500


@app.route('/new_biometric_template.fcgi', methods=['POST'])
def new_biometric_template():
    try :
        device_id = request.args.get('device_id')
        identifier_id = request.args.get('identifier_id')
        session = request.args.get('session')
        time = request.args.get('time')
        portal_id = request.args.get('portal_id')
        uuid = request.args.get('uuid')
        variance = request.args.get('variance')

        # Recebendo o conteúdo binário
        binary_data = request.data
        encoded_data = base64.b64encode(binary_data)

        return jsonify(responseAutorizado), 200, print(encoded_data)

    except Exception as e:
        return jsonify({"error": str(e)}), 500


@app.route('/new_card.fcgi', methods=['POST'])
def new_card():
    try :
        device_id = request.form.get('device_id', type=int)
        identifier_id = request.form.get('identifier_id', type=int)
        card_value = request.form.get('card_value', type=int)
        panic = request.form.get('panic', type=int)
        time = request.form.get('time', type=int)
        portal_id = request.form.get('portal_id', type=int)
        uuid = request.form.get('uuid', type=str)
        block_read_error = request.form.get('block_read_error', type=int)
        block_read_data = request.form.get('block_read_data', type=str)

        return jsonify(responseAutorizado), 200, print(f"Autorizado")
    except Exception as e:
        return jsonify({"error": str(e)}), 500


@app.route('/new_qrcode.fcgi', methods=['POST'])
def new_qrcode():
    try :
        device_id = request.form.get('device_id', type=int)
        identifier_id = request.form.get('identifier_id', type=int)
        qrcode_value = request.form.get('qrcode_value', type=str)
        time = request.form.get('time', type=int)
        portal_id = request.form.get('portal_id', type=int)
        uuid = request.form.get('uuid', type=str)

        return jsonify(responseAutorizado), 200, print(f"Autorizado")

    except Exception as e:
        return jsonify({"error": str(e)}), 500


@app.route('/new_uhf_tag.fcgi', methods=['POST'])
def new_uhf_tag():
    try :
        device_id = request.form.get('device_id', type=int)
        identifier_id = request.form.get('identifier_id', type=int)
        uhf_tag = request.form.get('uhf_tag', type=str)
        time = request.form.get('time', type=int)
        portal_id = request.form.get('portal_id', type=int)
        uuid = request.form.get('uuid', type=str)

        return jsonify(responseAutorizado), 200, print(f"Autorizado")

    except Exception as e:
        return jsonify({"error": str(e)}), 500


@app.route('/new_user_id_and_password.fcgi', methods=['POST'])
def new_user_id_and_password():
    try :
        device_id = request.form.get('device_id', type=int)
        identifier_id = request.form.get('identifier_id', type=int)
        user_id = request.form.get('user_id', type=int)
        password = request.form.get('password', type=str)
        time = request.form.get('time', type=int)
        portal_id = request.form.get('portal_id', type=int)
        uuid = request.form.get('uuid', type=str)

        return jsonify(responseAutorizado), 200, print(f"Autorizado")

    except Exception as e:
        return jsonify({"error": str(e)}), 500


@app.route('/new_rex_log.fcgi', methods=['POST'])
def new_rex_log():
    return jsonify(), 200, print("OK")


@app.route('/user_get_image.fcgi', methods=['GET'])
def get_user_image():
    path = 'images.jpg'
    user_id = request.args.get('user_id', type=int)
    try:
        return send_file(path), 200
    except Exception as e:
        return "Internal Server Error", 500


# API do remote enroll (online)
@app.route('/card_create.fcgi', methods=['POST'])
def card_create():
    try:
        data = request.get_json()
        user_id = data.get('user_id')
        card_value = data.get('card_value')
        device_id = data.get('device_id')

        return jsonify(), 200, print(f"cartão recebido: {card_value}")
    except Exception as e:
        return "Internal Server Error", 500


@app.route('/fingerprint_create.fcgi', methods=['POST'])
def fingerprint_create():
    try:
        data = request.get_json()
        user_id = data.get('user_id')
        finger_type = data.get('finger_type')
        device_id = data.get('device_id')
        fingerprints = data.get('fingerprints')

        return jsonify(), 200, print(f"Digitais recebidas: {fingerprints}")


    except Exception as e:
        return "Internal Server Error", 500


@app.route('/template_create.fcgi', methods=['POST'])
def template_create():
    try :
        # Recebendo parâmetros da URL
        card_id = request.args.get('card_id')
        device_id = request.args.get('device_id')
        finger_type = request.args.get('finger_type')
        size0 = request.args.get('size0')
        temp_num = request.args.get('temp_num')
        user_id = request.args.get('user_id')

        binary_data = request.data
        encoded_data = base64.b64encode(binary_data)

        return jsonify(), 200, print(f"Template recebido: {encoded_data}")
    except Exception as e:
        return jsonify({"error": str(e)}), 500


@app.route('/face_create.fcgi', methods=['POST'])
def face_create():
    try:
        data = request.get_json()
        user_id = data.get('user_id')
        device_id = data.get('device_id')
        face = data.get('face')

        return jsonify(), 200, print(f"face recebida: {face}")
    except Exception as e:
        return "Internal Server Error", 500

@app.route('/api/notifications/access_photo', methods=['POST'])
def access_photo():
    return jsonify(), 200

if __name__ == '__main__':
    #InsereDadosDoDispositivo()
    app.run(host='0.0.0.0', port=3035)