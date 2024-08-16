import requests
import time
import urllib3
import logging

urllib3.disable_warnings()
logging.captureWarnings(False)

nome_numero = 1
code = 1
pis = 1000000001
registration = 	1
rfid = 1
ip = '192.168.0.129'

# fazendo login no equipamento
login = requests.post(f"https://{ip}/login.fcgi", verify=False, json={
    "login": "admin",
    "password": "admin"
})
print(login.status_code)
print(login.reason)
login_data = login.json()
sessao = login_data['session']


for n in range(3001):
    resposta = requests.post(f"https://{ip}/add_users.fcgi?session={sessao}", verify=False, json={
        "users": [
            {
                "admin": False,
                "bars": "",
                "code": code,
                "name": f'usuario{nome_numero}',
                "password": "",
                "pis": pis,
                "registration": registration,
                "remove_templates": False,
                "rfid": rfid,
                "templates": [

                ]
            }
        ]
    })
    print(resposta.status_code)
    print(resposta.reason)
    resposta_data = resposta.json()
    print(resposta_data)

    nome_numero += 1
    code += 1
    pis += 1
    registration += 1
    rfid += 1
