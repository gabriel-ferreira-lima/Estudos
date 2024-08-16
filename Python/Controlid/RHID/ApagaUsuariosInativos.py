import requests


link = 'https://rhid.com.br/v2'
user = 'gabriel.lima@controlid.com.br'
password = 'Controlid1818'
domain = 'gabrieltesteaaaaaaaa'

# fazendo login no RHID
login = requests.post(f'{link}/login.svc/', json={
    'email': user,
    'password': password,
    'domain' : domain
})
login_data = login.json()
sessao = login_data['accessToken']
headers = {
    'authorization': 'Bearer ' + sessao
}

# Pegando o ID de todos os usuarios

ListarUsuarios = requests.get(f'{link}/customerdb/person.svc/a_status/inativo?draw=3&columns%5B0%5D%5Bdata%5D=id'
                              f'&columns%5B0%5D%5Bname%5D=&columns%5B0%5D%5Bsearchable%5D=true&columns%5B0%5D'
                              f'%5Borderable%5D=true&columns%5B0%5D%5Bsearch%5D%5Bvalue%5D=&columns%5B0%5D%5Bsearch'
                              f'%5D%5Bregex%5D=false&columns%5B1%5D%5Bdata%5D=name&columns%5B1%5D%5Bname%5D=&columns'
                              f'%5B1%5D%5Bsearchable%5D=true&columns%5B1%5D%5Borderable%5D=true&columns%5B1%5D'
                              f'%5Bsearch%5D%5Bvalue%5D=&columns%5B1%5D%5Bsearch%5D%5Bregex%5D=false&columns%5B2%5D'
                              f'%5Bdata%5D=companyTradingName&columns%5B2%5D%5Bname%5D=&columns%5B2%5D%5Bsearchable'
                              f'%5D=true&columns%5B2%5D%5Borderable%5D=false&columns%5B2%5D%5Bsearch%5D%5Bvalue%5D'
                              f'=&columns%5B2%5D%5Bsearch%5D%5Bregex%5D=false&columns%5B3%5D%5Bdata%5D=departmentName'
                              f'&columns%5B3%5D%5Bname%5D=&columns%5B3%5D%5Bsearchable%5D=true&columns%5B3%5D'
                              f'%5Borderable%5D=false&columns%5B3%5D%5Bsearch%5D%5Bvalue%5D=&columns%5B3%5D%5Bsearch'
                              f'%5D%5Bregex%5D=false&columns%5B4%5D%5Bdata%5D=statusStr&columns%5B4%5D%5Bname%5D'
                              f'=&columns%5B4%5D%5Bsearchable%5D=true&columns%5B4%5D%5Borderable%5D=false&columns%5B4'
                              f'%5D%5Bsearch%5D%5Bvalue%5D=&columns%5B4%5D%5Bsearch%5D%5Bregex%5D=false&columns%5B5'
                              f'%5D%5Bdata%5D=&columns%5B5%5D%5Bname%5D=&columns%5B5%5D%5Bsearchable%5D=true&columns'
                              f'%5B5%5D%5Borderable%5D=false&columns%5B5%5D%5Bsearch%5D%5Bvalue%5D=&columns%5B5%5D'
                              f'%5Bsearch%5D%5Bregex%5D=false&columns%5B6%5D%5Bdata%5D=&columns%5B6%5D%5Bname%5D'
                              f'=&columns%5B6%5D%5Bsearchable%5D=true&columns%5B6%5D%5Borderable%5D=false&columns%5B6'
                              f'%5D%5Bsearch%5D%5Bvalue%5D=&columns%5B6%5D%5Bsearch%5D%5Bregex%5D=false&columns%5B7'
                              f'%5D%5Bdata%5D=&columns%5B7%5D%5Bname%5D=&columns%5B7%5D%5Bsearchable%5D=true&columns'
                              f'%5B7%5D%5Borderable%5D=false&columns%5B7%5D%5Bsearch%5D%5Bvalue%5D=&columns%5B7%5D'
                              f'%5Bsearch%5D%5Bregex%5D=false&order%5B0%5D%5Bcolumn%5D=1&order%5B0%5D%5Bdir%5D=asc'
                              f'&start=0&length=10000&search%5Bvalue%5D=&search%5Bregex%5D=false&pisPerson'
                              f'=&matriculaPerson=', headers=headers)

ListarUsuarios_data = ListarUsuarios.json()
Ids = [item['id'] for item in ListarUsuarios_data['data']]

if len(Ids) == 0:
    print('não há usuarios inativos para apagar ')
else :
    pass

#apagando usuarios Inativos ,

for n in range(len(Ids)):
    DeletaUsuario = requests.delete(f'{link}/customerdb/person.svc/a/{Ids[n]}', headers=headers)

    print(DeletaUsuario.status_code)
    print(DeletaUsuario.json())

