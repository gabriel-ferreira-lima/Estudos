import base64
import os
from datetime import datetime
import requests


ip = "http://192.168.0.129"
usuario = "admin"
senha = "admin"
conteudo = os.listdir('C:/Users/gabri/Desktop/Integração/images10k')
baseFotos = []
nome_numero = 1
id_usuario = 1
cardnumber = 65536

for n in range(len(conteudo)):
    with open(f"C:/Users/gabri/Desktop/Integração/images10k/{conteudo[n]}", "rb") as imageFile:
        string = base64.b64encode(imageFile.read())
        decodado = string.decode()
    baseFotos.append(decodado)

login = requests.post(f"{ip}/login.fcgi", json={
    "login": usuario,
    "password": senha
})
print(login.status_code)
print(login.reason)
login_data = login.json()
sessao = login_data['session']

for n in range(len(baseFotos)):
    
    #cadastra usuario
    resposta = requests.post(f"{ip}/create_objects.fcgi?session={sessao}", json={
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
    horario = int(datetime.now().timestamp())

    #cadastra foto
    resposta1 = requests.post(f"{ip}/user_set_image_list.fcgi?session={sessao}", json={
    "match": False,
    "user_images": [
        {
            "user_id": id_usuario,
            "timestamp": horario,
            "image": f"{baseFotos[n]}"
        }
    ]
    })

    print(f'{resposta1.status_code} <-foto')
    
    #cadastra cartão
    """
    resposta2 = requests.post(f"{ip}/create_objects.fcgi?session={sessao}", json={
	"object": "cards",
	"values": [
		{
			"value": cardnumber,
			"user_id": id_usuario
		}
	]
    })

    print(f'{resposta1.status_code} <-cartão')
    """
    id_usuario += 1    
    cardnumber += 1