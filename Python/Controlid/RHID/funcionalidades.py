import requests
from Controlid.RHID.util import atualizar_texto

def ListaUsuarioComfotoRuimOuSemFoto(link, headers, texto_resultado):
    if link != None:
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

        if len(Ids) == 0:
            atualizar_texto('não há usuarios para apagar', texto_resultado)
        else:
            pass

        # listando usuario a usuario para ver se tem foto

        for n in range(len(Ids)):
            VerificaFoto = requests.get(f'{link}/customerdb/person.svc/a/{Ids[n]}', headers=headers)
            VerificaFoto_data = VerificaFoto.json()
            temfoto = VerificaFoto_data['foto']
            if temfoto is None:
                atualizar_texto(f'usuario de ID: {Ids[n]} sem foto', texto_resultado)
            else:
                FeedBackFoto = VerificaFoto_data['facialFeedback']
                if FeedBackFoto != '':
                    atualizar_texto(f'Usuario de ID: {Ids[n]} retornou o seguinte erro: {FeedBackFoto}', texto_resultado)
                else:
                    atualizar_texto(f'Usuario de ID: {Ids[n]} OK', texto_resultado)
    else:
        pass


def ApagaUsuariosAtivos(link, headers, texto_resultado):
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
        atualizar_texto('não há usuarios ativos para apagar\r\n', texto_resultado)
    else:
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
        DeletaUsuario_data = DeletaUsuario.json()
        DeletaUsuario_data_retorno = DeletaUsuario_data['error']
        atualizar_texto(f'{DeletaUsuario_data_retorno}', texto_resultado)

def ApagaUsuariosInativos(link, headers, texto_resultado):
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
        atualizar_texto('não há usuarios inativos para apagar ', texto_resultado)
    else:
        pass

    # apagando usuarios Inativos

    for n in range(len(Ids)):
        DeletaUsuario = requests.delete(f'{link}/customerdb/person.svc/a/{Ids[n]}', headers=headers)
        DeletaUsuario_data = DeletaUsuario.json()
        DeletaUsuario_data_retorno = DeletaUsuario_data['error']
        atualizar_texto(DeletaUsuario_data_retorno, texto_resultado)
