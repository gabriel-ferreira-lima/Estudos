import requests

# fazendo login no equipamento
login = requests.post("http://192.168.0.129/login.fcgi", json={
    "login": "admin",
    "password": "admin"
})
print(login.status_code)
print(login.reason)
login_data = login.json()
sessao = login_data['session']

# pegando a lista de usuarios sem foto
resposta = requests.post(f"http://192.168.0.129/load_objects.fcgi?session={sessao}", json={
    "object": "users",
    "where": [
        {
            "object": "users",
            "field": "image_timestamp",
            "operator": "IS NULL",
            "value": "",
            "connector": "OR"
        },
        {
            "object": "users",
            "field": "image_timestamp",
            "operator": "=",
            "value": 0
        }
    ]
})

print(resposta.status_code)
print(resposta.reason)
response_data = resposta.json()
ids = response_data['users']
conta_lista = len(ids)
numero = 0
lista_ids = []

for n in range(conta_lista):
    ids = response_data ['users'][numero]['id']
    lista_ids.append(ids)
    numero += 1

print(lista_ids)