import requests
import time

cartao_numero = 1
nome_numero = 1
id_usuario = 1
login = "admin"
senha = "admin"

login = requests.post("http://192.168.0.129/login.fcgi", json={
    "login": login,
    "password": senha
})
print(login.status_code)
print(login.reason)
login_data = login.json()
sessao = login_data['session']

for n in range(10001):
    resposta = requests.post(f"http://192.168.0.129/create_objects.fcgi?session={sessao}", json={
        "object": "users",
        "values": [
            {
                "id": id_usuario,
                "name": f'Douglas Miguel{nome_numero}',
                "registration": "",
                "password": "",
                "salt": ""
            }
        ]
    })
    print(f'{resposta.status_code} <-usuario')
    print(resposta.request)
    nome_numero += 1

    resposta1 = requests.post(f"http://192.168.0.129/create_objects.fcgi?session={sessao}", json={
        "object": "cards",
        "values": [
            {
                "value" : cartao_numero,
                "user_id": id_usuario
            }
        ]
    })
    print(f'{resposta1.status_code} <-cartão')
    cartao_numero += 1
    id_usuario += 1
