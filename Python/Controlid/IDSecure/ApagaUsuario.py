import requests
import urllib3
import logging

urllib3.disable_warnings()
logging.captureWarnings(False)

link = 'https://main.idsecure.com.br:5000'
user = 'metadados@idsecure.com.br'
password = 'api123456'

# fazendo login no IDSecure
login = requests.post(f'{link}/api/v1/operators/login', verify=False, json={
    'email': user,
    'password': password
})
print(login.status_code)
login_data = login.json()
sessao = login_data['data']['token']
headers = {
    'authorization': 'Bearer ' + sessao
}

# Carrega Lista de usuarios e remove o user ID = 1
ListaUsuario = requests.get(
    f'{link}/api/v1/persons?pageSize=10000000&pageNumber=1&status=1&sortField=id&personType=Person&sortOrder=desc',
    verify=False, headers=headers)

cont = 0
ListaUsuario_data = ListaUsuario.json()
print(ListaUsuario_data)
Ids = [item["id"] for item in ListaUsuario_data["data"]["data"]]

print(Ids)

"""
# Apagando Usuario
for n in range(len(Ids)):
    if Ids[cont] == 1:
        print(Ids[cont])
    else:
        ApagaUsuario = requests.delete(f'{link}/api/v1/persons/{Ids[cont]}?erase=true', verify=False, headers=headers)
        print(ApagaUsuario.status_code)
        cont += 1
"""