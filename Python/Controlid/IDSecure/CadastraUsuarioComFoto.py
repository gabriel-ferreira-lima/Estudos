import requests
import urllib3
import logging
import base64
import os

urllib3.disable_warnings()
logging.captureWarnings(False)

link = 'https://main.idsecure.com.br:5000'
user = 'gabriel.lima@controlid.com.br'
password = 'Controlid1818'

# Criando array com 10k de foto
conteudo = os.listdir('C:/Users/gabri/OneDrive/Área de Trabalho/Integração/images10k')
baseFotos = []
nome_numero = 1

for n in range(len(conteudo)):
    with open(f'C:/Users/gabri/OneDrive/Área de Trabalho/Integração/images10k/{conteudo[n]}', 'rb') as imageFile:
        string = base64.b64encode(imageFile.read())
        decodado = string.decode()
    baseFotos.append(decodado)

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

# Cadastrando usuario com foto
for n in range(len(baseFotos)):
    CadastraUsuario = requests.post(f'{link}/api/v1/persons', verify=False, headers=headers, json={
        'personType': 'Person',
        'name': f'Fulano de Tal {nome_numero}',
        'personGroup': [{'groupId': 1}],
        'personPhoto': {'type': 1,'status': 0,'photo': f'{baseFotos[n]}','id': 0,'personId': 0}
    })
    print(CadastraUsuario.status_code)
    nome_numero += 1
