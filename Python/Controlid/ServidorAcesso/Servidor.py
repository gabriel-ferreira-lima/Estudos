import base64
from logging import exception
import time
import requests

from flask import Flask, request, jsonify, send_file

app = Flask(__name__)

responseAutorizado = {
    "result": {
        "event": 7,
        "user_id": 6,
        "user_name": "Neal Caffrey",
        "user_image": True,
        "portal_id": 1,
        "actions": [
            {"action": "sec_box", "parameters": "id=65793, reason=1"}
        ]
    }
}

responseNaoAutorizado = {
    "result": {
        "event": 3,
        "user_id": 0,
        "user_name": "",
        "user_image": False,
        "portal_id": 1,
        "actions": []
    }
}

"""
responseNaoAutorizado2 = {
    "result":{
        "event":6,
        "portal_id":1,
        "user_id":0,
        "user_image":False,
        "user_name":"Usu\u00c3\u00a1rio n\u00c3\u00a3o identificado"
    }
}
"""

# APIs do modo online
@app.route('/device_is_alive.fcgi', methods=['POST'])
def device_is_alive():
    return jsonify(), 200, print("OK")


@app.route('/new_user_identified.fcgi', methods=['POST'])
def new_user_identified():
    try :
        device_id = request.form.get('device_id', type=int)
        identifier_id = request.form.get('identifier_id', type=int)
        component_id = request.form.get('component_id', type=int)
        event = request.form.get('event', type=int)
        user_id = request.form.get('user_id', type=int)
        duress = request.form.get('duress', type=int)
        face_mask = request.form.get('face_mask', type=lambda x: x.lower() == 'true')
        time_value = request.form.get('time', type=int)
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

        # Responda com base no user_id

        if user_id > 0:
            print(f"Autorizado")
            return jsonify(responseAutorizado), 200
        else:
            time.sleep(10)
            print("Acesso negado")
            return jsonify(responseNaoAutorizado), 200

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


# API Monitor
