import tkinter as tk
from tkinter import scrolledtext
import subprocess
import requests

# Variáveis globais para armazenar link e headers
link_global = None
headers_global = None


def atualizar_texto(texto, estado='normal'):
    texto_resultado.configure(state=estado)
    texto_resultado.delete(1.0, tk.END)
    texto_resultado.insert(tk.END, texto)
    texto_resultado.configure(state='disabled')


def executar_arquivo(comando):
    retorno = subprocess.run(comando, capture_output=True, text=True, encoding='utf-8')
    atualizar_texto(retorno.stdout)


def executar_login():
    global link_global, headers_global

    usuario = campo_usuario.get()
    senha = campo_senha.get()
    dominio = campo_dominio.get()

    link = 'https://rhid.com.br/v2'
    login = requests.post(f'{link}/login.svc/',
                          json={'email': usuario, 'password': senha,
                                'domain': dominio})

    if login.status_code == 200:
        login_data = login.json()
        if login_data['accessToken'] is not None:
            atualizar_texto('Login bem-sucedido!\r\n' + login_data['accessToken'])
            sessao = login_data['accessToken']
            headers = {
                'authorization': 'Bearer ' + sessao
            }
            # Atualiza os valores globais
            link_global = link
            headers_global = headers
            return link_global, headers_global
        else:
            pegarDominio = [item['domain'] for item in login_data['listCustomer']]
            atualizar_texto(f'Esse login possui mais de um domínio, pegue algum dos domínios abaixo !\r\n' + '\n'.join(
                pegarDominio))
            return link_global, headers_global
    else:
        atualizar_texto('Falha no login. Verifique suas credenciais.')
        return link_global, headers_global


def apaga_usuarios_ativos():
    confirmacao_janela = tk.Toplevel(janela)
    confirmacao_janela.title('Confirmação')
    confirmacao_janela.geometry('200x100')
    confirmacao_janela.resizable(False, False)

    # Adicionando mensagem de confirmação
    mensagem_label = tk.Label(confirmacao_janela, text='Tem certeza que deseja apagar\r\n usuários ativos?')
    mensagem_label.pack(pady=5)

    def sim():
        global link_global, headers_global
        if link_global is not None and headers_global is not None:
            confirmacao_janela.destroy()  # Fechando a janela de confirmação
            ListarUsuarios = requests.get(
                f'{link_global}/customerdb/person.svc/a_status/ativo?draw=1&columns%5B0%5D%5Bdata%5D=id'
                f'&columns%5B0%5D%5Bname%5D=&columns%5B0%5D%5Bsearchable%5D=true&columns%5B0%5D'
                f'%5Borderable%5D=true&columns%5B0%5D%5Bsearch%5D%5Bvalue%5D=&columns%5B0%5D%5Bsearch'
                f'%5D%5Bregex%5D=false&columns%5B1%5D%5Bdata%5D=id&columns%5B1%5D%5Bname%5D=&columns'
                f'%5B1%5D%5Bsearchable%5D=true&columns%5B1%5D%5Borderable%5D=true&columns%5B1%5D'
                f'%5Bsearch%5D%5Bvalue%5D=&columns%5B1%5D%5Bsearch%5D%5Bregex%5D=false&order%5B0%5D'
                f'%5Bcolumn%5D=1&order%5B0%5D%5Bdir%5D=asc&start=0&length=10000&search%5Bvalue%5D'
                f'=&search%5Bregex%5D=false', headers=headers_global)
            ListarUsuarios_data = ListarUsuarios.json()
            Ids = [item['id'] for item in ListarUsuarios_data['data']]
            IdsCompany = [item['idCompany'] for item in ListarUsuarios_data['data']]
            Pis = [item['pis'] for item in ListarUsuarios_data['data']]
            Cpf = [item['cpf'] for item in ListarUsuarios_data['data']]

            if len(Ids) == 0:
                atualizar_texto('não há usuarios ativos para apagar\r\n')
            else:
                pass

            # Inativando e apagando usuarios   'status':1,

            for n in range(len(Ids)):
                InativaUsuario = requests.put(f'{link_global}/customerdb/person.svc/a', headers=headers_global, json={
                    'excluded': False,
                    'id': Ids[n],
                    'cpf': Cpf[n],
                    'idCompany': IdsCompany[n],
                    'pis': Pis[n],
                    'status': 0
                })
                DeletaUsuario = requests.delete(f'{link_global}/customerdb/person.svc/a/{Ids[n]}',
                                                headers=headers_global)
                DeletaUsuario_data = DeletaUsuario.json()
                DeletaUsuario_data_retorno = DeletaUsuario_data['error']
                atualizar_texto(f'{DeletaUsuario_data_retorno}')

        else:
            confirmacao_janela.destroy()  # Fechando a janela de confirmação
            atualizar_texto('Por favor faça o login')

    def nao():
        confirmacao_janela.destroy()  # Fechando a janela de confirmação

    botao_sim = tk.Button(confirmacao_janela, text='Sim', command=sim)
    botao_sim.pack(side=tk.LEFT, padx=10, ipadx=5)

    botao_nao = tk.Button(confirmacao_janela, text='Não', command=nao)
    botao_nao.pack(side=tk.RIGHT, padx=10, ipadx=50)


def apaga_usuarios_inativos():
    confirmacao_janela = tk.Toplevel(janela)
    confirmacao_janela.title('Confirmação')
    confirmacao_janela.geometry('200x100')
    confirmacao_janela.resizable(False, False)
    confirmacao_janela.grab_set()

    # Adicionando mensagem de confirmação
    mensagem_label = tk.Label(confirmacao_janela, text='Tem certeza que deseja apagar\r\n usuários ativos?')
    mensagem_label.pack(pady=5)

    def sim():
        global link_global, headers_global
        if link_global is not None and headers_global is not None:
            confirmacao_janela.destroy()  # Fechando a janela de confirmação
            ListarUsuarios = requests.get(
                f'{link_global}/customerdb/person.svc/a_status/inativo?draw=3&columns%5B0%5D%5Bdata%5D=id'
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
                f'=&matriculaPerson=', headers=headers_global)

            ListarUsuarios_data = ListarUsuarios.json()
            Ids = [item['id'] for item in ListarUsuarios_data['data']]

            if len(Ids) == 0:
                atualizar_texto('não há usuarios inativos para apagar ')
            else:
                pass

            # apagando usuarios Inativos

            for n in range(len(Ids)):
                DeletaUsuario = requests.delete(f'{link_global}/customerdb/person.svc/a/{Ids[n]}',
                                                headers=headers_global)
                DeletaUsuario_data = DeletaUsuario.json()
                DeletaUsuario_data_retorno = DeletaUsuario_data['error']
                atualizar_texto(DeletaUsuario_data_retorno)
        else:
            confirmacao_janela.destroy()  # Fechando a janela de confirmação
            atualizar_texto('Por favor faça o login')

    def nao():
        confirmacao_janela.destroy()  # Fechando a janela de confirmação

    botao_sim = tk.Button(confirmacao_janela, text='Sim', command=sim)
    botao_sim.pack(side=tk.LEFT, padx=10, ipadx=5)

    botao_nao = tk.Button(confirmacao_janela, text='Não', command=nao)
    botao_nao.pack(side=tk.RIGHT, padx=10, ipadx=50)


def Lista_Usuario_Com_Foto_Ruim_Ou_Sem_Foto():
    global link_global, headers_global
    if link_global is not None and headers_global is not None:
        ListarUsuarios = requests.get(
            f'{link_global}/customerdb/person.svc/a_status/ativo?draw=1&columns%5B0%5D%5Bdata%5D=id'
            f'&columns%5B0%5D%5Bname%5D=&columns%5B0%5D%5Bsearchable%5D=true&columns%5B0%5D'
            f'%5Borderable%5D=true&columns%5B0%5D%5Bsearch%5D%5Bvalue%5D=&columns%5B0%5D%5Bsearch'
            f'%5D%5Bregex%5D=false&columns%5B1%5D%5Bdata%5D=id&columns%5B1%5D%5Bname%5D=&columns'
            f'%5B1%5D%5Bsearchable%5D=true&columns%5B1%5D%5Borderable%5D=true&columns%5B1%5D'
            f'%5Bsearch%5D%5Bvalue%5D=&columns%5B1%5D%5Bsearch%5D%5Bregex%5D=false&order%5B0%5D'
            f'%5Bcolumn%5D=1&order%5B0%5D%5Bdir%5D=asc&start=0&length=10000&search%5Bvalue%5D'
            f'=&search%5Bregex%5D=false', headers=headers_global)
        ListarUsuarios_data = ListarUsuarios.json()
        Ids = [item['id'] for item in ListarUsuarios_data['data']]

        if len(Ids) == 0:
            atualizar_texto('não há usuarios para verificar foto')
        else:
            pass

        # listando usuario a usuario para ver se tem foto

        for n in range(len(Ids)):
            VerificaFoto = requests.get(f'{link_global}/customerdb/person.svc/a/{Ids[n]}', headers=headers_global)
            VerificaFoto_data = VerificaFoto.json()
            temfoto = VerificaFoto_data['foto']
            if temfoto is None:
                atualizar_texto(f'usuario de ID: {Ids[n]} sem foto')
            else:
                FeedBackFoto = VerificaFoto_data['facialFeedback']
                if FeedBackFoto != '':
                    atualizar_texto(f'Usuario de ID: {Ids[n]} retornou o seguinte erro: {FeedBackFoto}')
                else:
                    atualizar_texto(f'Usuario de ID: {Ids[n]} OK')
    else:
        atualizar_texto('Por favor faça o login')


# Criando a janela principal
janela = tk.Tk()
janela.title('RHID')
janela.geometry('1000x400')
janela.resizable(False, False)

# Criando os campos de texto para inserir o nome de usuário, senha e dominio
label_usuario = tk.Label(janela, text='Usuário:')
label_usuario.grid(row=0, column=0, padx=5, pady=5)
campo_usuario = tk.Entry(janela)
campo_usuario.grid(row=0, column=1, padx=(0, 900), pady=5)

label_senha = tk.Label(janela, text='Senha:')
label_senha.grid(row=1, column=0, padx=5, pady=5)
campo_senha = tk.Entry(janela)
campo_senha.grid(row=1, column=1, padx=(0, 900), pady=5)

label_dominio = tk.Label(janela, text='Domínio:')
label_dominio.grid(row=2, column=0, padx=5, pady=5)
campo_dominio = tk.Entry(janela)
campo_dominio.grid(row=2, column=1, padx=(0, 900), pady=5)

# Criando um frame para o botao login
frame_botao_login = tk.Frame(janela)
frame_botao_login.grid(row=3, columnspan=2)

# Botão de login
botao_login = tk.Button(frame_botao_login, text='Login', command=executar_login)
botao_login.grid(row=1, column=0, columnspan=1, padx=(0, 850), pady=5)

# Criando um frame para os botões
frame_botoes = tk.Frame(janela)
frame_botoes.grid(row=4, columnspan=2)

# Criando os botões dentro do frame_botoes usando grid
botao1 = tk.Button(frame_botoes, text='Lista Usuarios Com foto Ruim Ou Sem Foto',
                   command=Lista_Usuario_Com_Foto_Ruim_Ou_Sem_Foto)
botao1.grid(row=1, column=1, padx=50, pady=5)

botao2 = tk.Button(frame_botoes, text='Apagar Usuarios Inativos', command=apaga_usuarios_inativos)
botao2.grid(row=1, column=2, padx=50, pady=5)

botao3 = tk.Button(frame_botoes, text='Apagar Usuarios Ativos', command=apaga_usuarios_ativos)
botao3.grid(row=1, column=3, padx=50, pady=5)

# Criando um frame para o resultado das ações
frame_resultado = tk.Frame(janela)
frame_resultado.grid(row=6, columnspan=2, padx=(0, 100), pady=5)  # Definindo a posição usando grid

# Criando a área de texto com scrollbar dentro do frame_resultado
texto_resultado = scrolledtext.ScrolledText(frame_resultado, wrap=tk.WORD, width=120, height=13)
texto_resultado.pack()

# Loop principal da interface gráfica
janela.mainloop()
