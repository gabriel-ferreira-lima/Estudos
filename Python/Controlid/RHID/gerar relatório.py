import time
import requests

link = 'https://rhid.com.br/v2'
user = 'samuel@jczeng.com.br'
password = '51109013'
headers_global = None


# fazendo login no RHID
def FazerLogin():
    global headers_global
    request = requests.post(f'{link}/login.svc/', json={
        'email': user,
        'password': password
    })
    login_data = request.json()
    sessao = login_data['accessToken']
    headers_global = {
        'authorization': 'Bearer ' + sessao
    }
    return headers_global


# Gerando reltório de inconsistência

def GerarRelatorio(headers):
    request = requests.post(f'{link}/report.svc/ponto', headers=headers, json={
            "pdfCartaoPontoParameters": {
                "fontSizeTitle": 12,
                "fontSizeData": 8,
                "fontSizeHeader": 9,
                "fontSizeHeaderSmall": 8,
                "fontSizeFooter": 8,
                "fontName": "Helvetica",
                "listIdStr": [],
                "listCostCenterStr": [],
                "listDepartmentStr": [],
                "listPersonRoleStr": [],
                "listCompanyStr": [],
                "listShiftStr": []
            },
            "ini": "20240403",
            "fim": "20240503",
            "listColumns": [
                "strHorarioContratualSimples",
                "horasTotalNaoExtra",
                "horasTotalNoturno",
                "faltasDiasInteiro",
                "horasFaltaAtraso",
                "minutosAbono",
                "horaExtraPorPercentual",
                "extraDiurna",
                "extraNoturna",
                "saldoBancoAjustadoMaisCredDeb",
                "saldoBancoFinalDia"
            ],
            "listPersonInfo": [
                "Person.name",
                "Person.registration",
                "PersonRole.name"
            ],
            "formatoSaida": "CSV",
            "relatorio": "inconsistencias",
            "inconsistenciasParameters": {
                "alertId": [
                    1
                ]
            },
            "formatoHoras": 1,
            "status": 1
        })
    request_data = request.json()
    guid = request_data['guid']
    print(f'Pegando o valor da Guid : {guid}')

    # Gerenado loop para verificar criação de relatório
    percent = 0
    while percent < 100:
        request = requests.get(f'{link}/customerdb/notify.svc/specificGuid/?guid={guid}', headers=headers_global)
        request_data = request.json()
        percent = request_data['percent']
        print(f'Porcentagem para conclusão do relátorio : {percent}%')
        time.sleep(3)

    # Baixando o arquivo em formato CSV
    request = requests.post(f'{link}/customerdb/notify.svc/save_file/?format=CSV&guid={guid}', headers=headers_global)

    file_path = 'C:/Relatório de Inconsistências.csv'
    with open(file_path, 'wb') as file:
        file.write(request.content)
    print(f'CSV salvo com sucesso em {file_path}')
    print(request.text)

FazerLogin()
GerarRelatorio(headers_global)
