import requests
import urllib3
import logging
import base64
import os
import csv

urllib3.disable_warnings()
logging.captureWarnings(False)

link = 'https://main.idsecure.com.br:5000'
user = 'gabriel.lima@controlid.com.br'
password = 'Controlid1818'
tenant = "2756"

# Caminho base
base_dir = 'C:/Users/gabri/Desktop/Integração/images10k'

# Criando array com base64 das fotos
conteudo = os.listdir(base_dir)
baseFotos = []
template = []
nome_numero = 1

for arquivo in conteudo:
    if arquivo.lower().endswith((".jpg", ".jpeg", ".png")):  # garante só imagens
        with open(os.path.join(base_dir, arquivo), 'rb') as imageFile:
            string = base64.b64encode(imageFile.read())
            baseFotos.append(string.decode())

# Lendo os templates do CSV

with open(os.path.join(base_dir, "digitais.csv"), newline="", encoding="utf-8") as csvfile:
    reader = csv.reader(csvfile)
    next(reader)
    for row in reader:
        template.append(row[0])

# fazendo login no IDSecure
login = requests.post(f'{link}/api/v1/operators/login', verify=False, json={
    'email': user,
    'password': password,
    'tenantId': tenant
})
print("Login:", login.status_code)
login_data = login.json()
sessao = login_data['data']['token']
headers = {
    'authorization': 'Bearer ' + sessao
}

#Cadastrando cartão ficticio
codigo = 6553601

for idx in range(len(baseFotos)):
    CadastraUsuario = requests.post(f'{link}/api/v1/persons', verify=False, headers=headers, json={
        'personType': 'Person',
        'name': f'Fulano de Tal {idx+1}',
        'personGroup': [{'groupId': 1001}],
        'personPhoto': {
            'type': 1,
            'status': 0,
            'photo': baseFotos[idx],
            'id': 0,
            'personId': 0
        },
        "personFingerPrint": [
            {
                "templateType": 2,
                "template": template[idx],  # pega da lista preenchida pelo CSV
                "isDuress": False,
                "isEnabled": True,
                "personFingerPrintImage": []
            }
        ],
        "personCard": [
            {
                "type": 5,
                "cardNumber": codigo,
                "readableCode": f"{codigo}"
            }
        ]
    })
    
    if CadastraUsuario.status_code != 200 :
        print (f'status code {CadastraUsuario.status_code} : {CadastraUsuario.json()}')
    print(f"Usuário {idx+1}: {CadastraUsuario.status_code}")
    codigo += 1