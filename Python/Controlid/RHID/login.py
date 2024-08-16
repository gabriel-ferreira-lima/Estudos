import requests

def fazer_login(usuario, senha):
    link = 'https://rhid.com.br/v2/login.svc/'  # URL do endpoint de login
    domain = 'gabrieltesteaaaaaaaa'  # Domínio para o login (se aplicável)
    payload = {'email': usuario, 'password': senha, 'domain': domain}

    # Fazendo a solicitação POST para fazer login
    response = requests.post(link, json=payload)

    # Verificando o status da resposta
    if response.status_code == 200:
        print("Login bem-sucedido!")
        # Aqui você pode retornar ou fazer qualquer ação adicional após o login
        # Por exemplo, você pode extrair o token de sessão da resposta e usá-lo para fazer outras solicitações
    else:
        print("Falha no login. Verifique suas credenciais.")

# Variáveis de usuário e senha
usuario = ''
senha = ''

# Fazendo login com as credenciais fornecidas
fazer_login(usuario, senha)
