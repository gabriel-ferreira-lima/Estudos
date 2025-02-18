import base64
import os
import requests

conteudo = os.listdir('C:/Users/gabri/Desktop/Controlid/Ajuda/Integração/Acesso/10mil/pkg')
baseFotos = []
nome_numero = 1
id_usuario = 1

for n in range(len(conteudo)):
    with open(f"C:/Users/gabri/Desktop/Controlid/Ajuda/Integração/Acesso/10mil/pkg/{conteudo[n]}", "rb") as imageFile:
        string = base64.b64encode(imageFile.read())
        decodado = string.decode()
    baseFotos.append(decodado)

login = requests.post("http://192.168.0.129/login.fcgi", json={
    "login": "admin",
    "password": "admin"
})
print(login.status_code)
print(login.reason)
login_data = login.json()
sessao = login_data['session']

for n in range(len(baseFotos)):
    resposta = requests.post(f"http://192.168.0.129/create_objects.fcgi?session={sessao}", json={
        "object": "users",
        "values": [
            {
                "id": id_usuario,
                "name": f'Douglas Miguel{nome_numero}',
                "registration": "",
                "password": "",
                "salt": "",
            }
        ]
    })
    print(f'{resposta.status_code} <-usuario')
    nome_numero += 1

    resposta1 = requests.post(f"http://192.168.0.129/user_set_image_list.fcgi?session={sessao}", json={
    "match": False,
    "user_images": [
        {
            "user_id": id_usuario,
            "timestamp": 1624997563,
            "image": f"{baseFotos[n]}"
        }
    ]
    })

    print(f'{resposta1.status_code} <-foto')
    id_usuario += 1
    