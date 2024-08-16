import requests

#fazendo login no equipamento
login = requests.post ("http://192.168.0.129/login.fcgi", json={
    "login": "admin",
    "password": "admin"
})
print(login.status_code)
print(login.reason)
login_data = login.json()
sessao = login_data['session']

#iniciando a coleta de todos os ID's de usuarios com foto
lista_usuario_foto = requests.get(f"http://192.168.0.129/user_list_images.fcgi?get_timestamp=1&session={sessao}")

print(lista_usuario_foto.status_code)
print(lista_usuario_foto.reason)
lista_usuario_foto_data = lista_usuario_foto.json()
ids = lista_usuario_foto_data ['image_info']
conta_lista = len(ids)
numero = 0
lista_ids = []
for n in range(conta_lista):
    ids = lista_usuario_foto_data ['image_info'][numero]['user_id']
    lista_ids.append(ids)
    numero += 1

# pegando a lista de imagem de usuarios, esse endpoint possui limitação de 100 ID's por requisição
resposta = requests.post(f"http://192.168.0.129/user_get_image_list.fcgi?session={sessao}", json={
    "user_ids": lista_ids
})

print(resposta.status_code)
print(resposta.reason)

response_data = resposta.json()
print(response_data)