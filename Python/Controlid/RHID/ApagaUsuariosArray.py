import requests
import json

link = 'https://rhid.com.br/v2/api.svc'
user = 'implantacao@controlid.com'
password = 'Controlid123'
domain = 'SOLVIESSENCIS-CLOUD'

# fazendo login no RHID
request = requests.post(f'{link}/login', json={
    'email': user,
    'password': password,
    'domain': domain
})
login_data = request.json()['accessToken']
headers = {
    'authorization': 'Bearer ' + login_data
}

lista = [6476, 6477, 6478, 6479, 6480, 6481, 6482, 6483, 6484, 6485, 6486,6487, 6488, 6489, 6490, 6491, 6492]

for n in range(len(lista)):
    request = requests.get(f'{link}/person/{lista[n]}', headers=headers)
    data = request.json()

    bar_code = data['barCode']
    code = data['code']
    cpf = data['cpf']
    get_templates = data['getTemplates']
    user_id = data['id']
    company_id = data['idCompany']
    department_id = data['idDepartment']
    is_admin = data['isAdmin']
    linked_device_ids = data['linkedDeviceIds']
    name = data['name']
    number_of_templates = data['numberOfTemplates']
    password = data['password']
    pis = data['pis']
    registration = data['registration']
    rfid = data['rfid']
    status = data['status']
    templates = data['templates']

    request = requests.put(f'{link}/person', headers=headers, json={
        "barCode": bar_code,
        "code": code,
        "cpf": cpf,
        "getTemplates": get_templates,
        "id": user_id,
        "idCompany": company_id,
        "idDepartment": department_id,
        "isAdmin": is_admin,
        "linkedDeviceIds": linked_device_ids,
        "name": name,
        "numberOfTemplates": number_of_templates,
        "password": password,
        "pis": pis,
        "registration": registration,
        "rfid": rfid,
        "status": 0,
        "templates": templates
    })
    if request.status_code == 200:
        print(f'Inativado o usaurio ID:{user_id}, nome:{name}')
    else :
        print(f'erro na requisição: {request.status_code}')

    request = requests.delete(f'{link}/person/{user_id}', headers=headers)
    if request.status_code == 200:
        print(f'Deletado o usaurio ID:{user_id}, nome:{name}')
    else :
        print(f'erro na requisição: {request.status_code}')