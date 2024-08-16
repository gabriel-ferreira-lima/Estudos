import base64
import os
import requests

conteudo = os.listdir('C:/ProgramData/Control iD/iDSecure/images')
baseFotos = []
baseUsuarios = []

for n in range(len(conteudo)):
    with open(f"C:/ProgramData/Control iD/iDSecure/images/{conteudo[n]}", "rb") as imageFile:
        string = base64.b64encode(imageFile.read())
        decodado = string.decode()
    baseFotos.append(decodado)

for n in range(len(baseFotos)):
    baseUsuarios.append(f'usuario-{n + 1}')

print("total de fotos :", len(baseFotos))
cadastraUsuario = []

for n in range(len(baseFotos)):
    data = {
        "id": n + 1,
        "name": baseUsuarios[n],
        "registration": "",
        "password": "",
        "salt": "",
    }
    cadastraUsuario.append(data)

print("total de usuarios :", len(cadastraUsuario))

ip = "http://192.168.0.130"
login = "admin"
password = "admin"

request = requests.post(f"{ip}/login.fcgi", json={
    "login": login,
    "password": password
})
print(f"login : {request.status_code}")
login_data = request.json()
sessao = login_data['session']

request = requests.post(f"{ip}/create_objects.fcgi?session={sessao}", json={
    "object": "users",
    "values": cadastraUsuario
})
print(f'Cadastrou Usuarios : {request.status_code}')

iduser = 1
cadastraFoto = []

for n in range(len(baseFotos)):
    data = {
        "user_id": iduser,
        "timestamp": 1,
        "image": baseFotos[n]
    }
    cadastraFoto.append(data)
    iduser += 1

segundo_array = []

# Percorre o primeiro array em blocos de 61 elementos
for i in range(0, len(cadastraFoto), 61):
    bloco = cadastraFoto[i:i+61]
    segundo_array.append(bloco)

listadesucesso = []

for n in range(len(segundo_array)):
    request = requests.post(f"{ip}/user_set_image_list.fcgi?session={sessao}", json={
        "match": False,
        "user_images": segundo_array[n]
    })
    print(f'{request.status_code} <-foto')
    request_data = request.json()
    for result in request_data['results']:
       listadesucesso.append(result['user_id'])

print(listadesucesso)
print(len(listadesucesso))
