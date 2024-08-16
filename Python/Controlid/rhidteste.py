import requests

link = 'https://www.rhid.com.br/v2/api.svc'
user = 'gabriel.lima@controlid.com.br'
password = 'Controlid1818'
domain = 'gabrieltesteaaaaaaaa'

request = requests.post(f'{link}/login', json={
    "email": user,
    "password": password,
    "domain": domain
})

login_data = request.json()["accessToken"]
headers = {
    'authorization': 'Bearer ' + login_data
}

request = requests.get(f'{link}/report/afd/download?idEquipamento=15&nsrInicial=1&limit=1', headers=headers)

afd_data = request.json()

print(afd_data)
