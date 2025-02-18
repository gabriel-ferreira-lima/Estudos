import requests


link = 'https://rhid.com.br/v2'
user = 'integracao@controlid.com.br'
password = 'Cid1836@'
domain = ''

def apagandousuarios():
    # fazendo login no RHID
    login = requests.post(f'{link}/login.svc/', json={
        'email': user,
        'password': password,
        'domain' : domain
    })
    login_data = login.json()['accessToken']
    headers = {
        'authorization': 'Bearer ' + login_data
    }

    # Pegando o ID de todos os usuarios

    ListarUsuarios = requests.get(f'{link}/customerdb/person.svc/a_status/ativo?draw=1&columns%5B0%5D%5Bdata%5D=id'
                                  f'&columns%5B0%5D%5Bname%5D=&columns%5B0%5D%5Bsearchable%5D=true&columns%5B0%5D'
                                  f'%5Borderable%5D=true&columns%5B0%5D%5Bsearch%5D%5Bvalue%5D=&columns%5B0%5D%5Bsearch'
                                  f'%5D%5Bregex%5D=false&columns%5B1%5D%5Bdata%5D=id&columns%5B1%5D%5Bname%5D=&columns'
                                  f'%5B1%5D%5Bsearchable%5D=true&columns%5B1%5D%5Borderable%5D=true&columns%5B1%5D'
                                  f'%5Bsearch%5D%5Bvalue%5D=&columns%5B1%5D%5Bsearch%5D%5Bregex%5D=false&order%5B0%5D'
                                  f'%5Bcolumn%5D=1&order%5B0%5D%5Bdir%5D=asc&start=0&length=10000&search%5Bvalue%5D'
                                  f'=&search%5Bregex%5D=false', headers=headers)
    ListarUsuarios_data = ListarUsuarios.json()
    Ids = [item['id'] for item in ListarUsuarios_data['data']]
    IdsCompany = [item['idCompany'] for item in ListarUsuarios_data['data']]
    Pis = [item['pis'] for item in ListarUsuarios_data['data']]
    Cpf = [item['cpf'] for item in ListarUsuarios_data['data']]

    if len(Ids) == 0:
        print('não há usuarios ativos para apagar')
    else :
        pass

    # Inativando e apagando usuarios   "status":1,

    for n in range(len(Ids)):
        InativaUsuario = requests.put(f'{link}/customerdb/person.svc/a', headers=headers, json={
            "excluded": False,
            "id": Ids[n],
            "cpf": Cpf[n],
            "idCompany": IdsCompany[n],
            "pis": Pis[n],
            "status": 0
        })
        DeletaUsuario = requests.delete(f'{link}/customerdb/person.svc/a/{Ids[n]}', headers=headers)

        print(InativaUsuario.status_code)
        print(InativaUsuario.json())
        print(DeletaUsuario.status_code)
        print(DeletaUsuario.json())

def acerta_erro() :
    try :
        apagandousuarios()
    except:
        print("errooooooooooooooooooooo")
        acerta_erro()

acerta_erro()