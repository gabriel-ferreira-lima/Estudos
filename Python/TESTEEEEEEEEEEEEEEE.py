from datetime import datetime

import requests

ip = "http://192.168.0.128"
usuario = "admin"
senha = "admin"

# fazendo login no rhid
login = requests.post(f"{ip}/login.fcgi", json={
    "login": usuario,
    "password": senha
})
login_data = login.json()
print(login.status_code)
sessao = login_data['session']

while True:
    horario = int(datetime.now().timestamp())
    cadastra_usuario = requests.post(f"{ip}/create_objects.fcgi?session={sessao}", json={
        'object': 'access_logs',
        'values': [{
                "time": horario,
                "event": 7,
                "device_id": 4408801109216770,
                "identifier_id": 1717658368,
                "user_id": 3,
                "portal_id": 1,
                "identification_rule_id": 1,
                "card_value": 0,
                "qrcode_value": "",
                "pin_value": "",
                "confidence": 1233,
                "mask": 0,
                "log_type_id": -1,
                "component_id": 0
            }]
    })
    cadastra_usuario_data = cadastra_usuario.json()
    print(cadastra_usuario_data)