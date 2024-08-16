import requests
import urllib3
import logging

urllib3.disable_warnings()
logging.captureWarnings(False)

# fazendo login no rhid
login = requests.post("https://rhid.com.br/v2/login.svc/", verify=False, json={
    "email": "sistema.rhid@gruposide.com.br",
    "password": "Sucesso178@"
})
login_data = login.json()
sessao = login_data['accessToken']


url = "https://rhid.com.br/v2/customerdb/person.svc/a_status/ativo?draw=1&columns%5B0%5D%5Bdata%5D=id&columns%5B0%5D" \
      "%5Bname%5D=&columns%5B0%5D%5Bsearchable%5D=true&columns%5B0%5D%5Borderable%5D=true&columns%5B0%5D%5Bsearch%5D" \
      "%5Bvalue%5D=&columns%5B0%5D%5Bsearch%5D%5Bregex%5D=false&columns%5B1%5D%5Bdata%5D=id&columns%5B1%5D%5Bname%5D" \
      "=&columns%5B1%5D%5Bsearchable%5D=true&columns%5B1%5D%5Borderable%5D=true&columns%5B1%5D%5Bsearch%5D%5Bvalue%5D" \
      "=&columns%5B1%5D%5Bsearch%5D%5Bregex%5D=false&order%5B0%5D%5Bcolumn%5D=1&order%5B0%5D%5Bdir%5D=asc&start=0" \
      "&length=15000&search%5Bvalue%5D=&search%5Bregex%5D=false"
headers = {
    'authorization': 'Bearer ' + sessao
}

response = requests.get(url, headers=headers)

responsedata = response.json()
ids = responsedata ['data']
conta_lista = len(ids)
numero = 0
lista_ids = []


for n in range(conta_lista):
    ids = responsedata ['data'][numero]['id']
    lista_ids.append(ids)
    numero += 1

i = 0
for n in range(conta_lista):
    url2 = requests.post("https://rhid.com.br/v2/report.svc/apuracao_ponto" ,headers=headers, verify=False, json={
            "idPerson": [
            lista_ids[i]
        ],
        "ini": "20240318",
        "fim": "20240418",
        "afdChanges": [],
        "alertId": [],
        "pagina": 0
    })
    print(url2.status_code)
    print(f'ID usuario : {lista_ids[i]}')
    url2data = url2.json()
    print(f'{url2data} \r')
    i += 1