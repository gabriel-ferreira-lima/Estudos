import tkinter as tk
from tkinter import scrolledtext
import sys
from Controlid.RHID.funcionalidades import *
from Controlid.RHID.util import atualizar_texto

# Variáveis globais para armazenar link e headers
link_global = None
headers_global = None


def executar_login():
    global link_global, headers_global

    usuario = campo_usuario.get()
    senha = campo_senha.get()
    dominio = campo_dominio.get()

    link = 'https://rhid.com.br/v2'
    login = requests.post(f'{link}/login.svc/',
                          json={'email': usuario, 'password': senha, 'domain': dominio})

    if login.status_code == 200:
        login_data = login.json()
        if login_data['accessToken'] is not None:
            atualizar_texto("Login bem-sucedido!\r\n", texto_resultado)
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
            atualizar_texto(f'Esse login possui mais de um domínio, pegue algum dos domínios abaixo !\r\n' + "\n".join(
                pegarDominio) + "\n", texto_resultado)
            return link_global, headers_global
    else:
        atualizar_texto("Falha no login. Verifique suas credenciais.\r\n", texto_resultado)
        return link_global, headers_global


# Usando as funções atualizadas nos botões de execução de arquivo e login
def executar_arquivo1():
    global link_global, headers_global
    if link_global is not None and headers_global is not None:
        link, headers = link_global, headers_global
        ApagaUsuariosAtivos(link, headers, texto_resultado)
    else:
        atualizar_texto("Por favor faça o login\r\n", texto_resultado)


def executar_arquivo2():
    global link_global, headers_global
    if link_global is not None and headers_global is not None:
        link, headers = link_global, headers_global
        ApagaUsuariosInativos(link, headers, texto_resultado)
    else:
        atualizar_texto("Por favor faça o login\r\n", texto_resultado)


def executar_arquivo3():
    global link_global, headers_global
    if link_global is not None and headers_global is not None:
        link, headers = link_global, headers_global
        ListaUsuarioComfotoRuimOuSemFoto(link, headers, texto_resultado)
    else:
        atualizar_texto("Por favor faça o login\r\n", texto_resultado)


# Criando a janela principal
janela = tk.Tk()
janela.title("RHID")
janela.geometry("1000x400")
janela.resizable(False, False)

# Criando os campos de texto para inserir o nome de usuário, senha e dominio
label_usuario = tk.Label(janela, text="Usuário:")
label_usuario.grid(row=0, column=0, padx=5, pady=5)
campo_usuario = tk.Entry(janela)
campo_usuario.grid(row=0, column=1, padx=(0, 900), pady=5)

label_senha = tk.Label(janela, text="Senha:")
label_senha.grid(row=1, column=0, padx=5, pady=5)
campo_senha = tk.Entry(janela)  # A senha será exibida como asteriscos
campo_senha.grid(row=1, column=1, padx=(0, 900), pady=5)

label_dominio = tk.Label(janela, text="Domínio:")
label_dominio.grid(row=2, column=0, padx=5, pady=5)
campo_dominio = tk.Entry(janela)
campo_dominio.grid(row=2, column=1, padx=(0, 900), pady=5)

# Criando um frame para o botao login
frame_botao_login = tk.Frame(janela)
frame_botao_login.grid(row=3, columnspan=2)  # Definindo a posição do frame usando grid

# Botão de login
botao_login = tk.Button(frame_botao_login, text="Login", command=executar_login)
botao_login.grid(row=1, column=0, columnspan=1, padx=(0, 850),
                 pady=5)  # Definindo a posição do botão dentro do frame usando grid

# Criando um frame para os botões
frame_botoes = tk.Frame(janela)
frame_botoes.grid(row=4, columnspan=2)  # Definindo a posição do frame usando grid

# Criando os botões dentro do frame_botoes usando grid
botao1 = tk.Button(frame_botoes, text="Apagar Usuarios Ativos", command=executar_arquivo1)
botao1.grid(row=1, column=1, padx=50, pady=5)

botao2 = tk.Button(frame_botoes, text="Apagar Usuarios Inativos", command=executar_arquivo2)
botao2.grid(row=1, column=2, padx=50, pady=5)

botao3 = tk.Button(frame_botoes, text="Lista Usuarios Com foto Ruim Ou Sem Foto", command=executar_arquivo3)
botao3.grid(row=1, column=3, padx=50, pady=5)

# Criando um frame para o resultado das ações
frame_resultado = tk.Frame(janela)
frame_resultado.grid(row=6, columnspan=2, padx=(0, 100), pady=5)  # Definindo a posição usando grid

# Criando a área de texto com scrollbar dentro do frame_resultado
texto_resultado = scrolledtext.ScrolledText(frame_resultado, wrap=tk.WORD, width=120, height=13)
texto_resultado.pack()  # Usando pack para o texto_resultado dentro do frame_resultado

# Loop principal da interface gráfica
janela.mainloop()
