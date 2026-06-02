import requests
import urllib3
import logging

urllib3.disable_warnings()
logging.captureWarnings(False)

link = 'https://main.idsecure.com.br:5000'
user = 'gabriel.lima@controlid.com.br'
password = 'Controlid1818'
tenantId = '2756'

# fazendo login no IDSecure
login = requests.post(f'{link}/api/v1/operators/login', verify=False, json={
    'email': user,
    'password': password,
    'tenantId': tenantId
})
print(login.status_code)
login_data = login.json()
sessao = login_data['data']['token']
headers = {
    'authorization': 'Bearer ' + sessao
}

# Carrega Lista de usuarios
ListaUsuario = requests.get(
    f'{link}/api/v1/persons?pageSize=10000000&pageNumber=1&status=1&sortField=id&personType=Person&sortOrder=desc',
    verify=False, headers=headers)

ListaUsuario_data = ListaUsuario.json()
Ids = [item["id"] for item in ListaUsuario_data["data"]["data"]]

print(Ids)

# IDs que não devem ser apagados
skip_ids = {1, 10311}

# Apagando usuarios
for user_id in Ids:
    if user_id in skip_ids:
        print(f"Pulando ID {user_id}")
    else:
        ApagaUsuario = requests.delete(f'{link}/api/v1/persons/{user_id}?erase=true',
                                       verify=False, headers=headers)
        print(user_id, ApagaUsuario.status_code)
