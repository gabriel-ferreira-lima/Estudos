import logging
import tkinter as tk
import requests
import urllib3

urllib3.disable_warnings()
logging.captureWarnings(False)

def executar():
    ip = entry_ip.get()
    login = entry_login.get()
    senha = entry_senha.get()

    # Exemplo de como fazer uma chamada à API (adapte conforme necessário)
    try:
        url = f"https://{ip}/login.fcgi"  # Ajuste o endpoint da sua API
        response = requests.post(url, verify=False, json={
            "login": login,
            "password": senha,
        })
        if response.status_code == 200:
            login_data = response.json()['session']
            resultado_label.config(text=f"Sucesso: {response.text}")

            url = f"https://{ip}/count_users.fcgi?session={login_data}"
            response = requests.post(url, verify=False)
            if response.status_code == 200:
                response_data = response.json()['count']
                offset = 0
                lista =[]

                while len(lista) < response_data:
                    url = f"https://{ip}/load_users.fcgi?session={login_data}"
                    response = requests.post(url, verify=False, json = {
                        "limit": 100,
                        "offset": offset,
                    })
                    ids_usuarios = response.json()
                    pis_values = [user["pis"] for user in ids_usuarios["users"]]
                    lista += pis_values
                    offset += 100
                url = f"https://{ip}/remove_users.fcgi?session={login_data}"
                response = requests.post(url, verify=False, json={
                    "users": lista
                })
                resultado_label.config(text=f"Sucesso apagados")

        else:
            resultado_label.config(text=f"Erro: {response.status_code}")
    except Exception as e:
        resultado_label.config(text=f"Erro: {str(e)}")

# Criando a janela principal
janela = tk.Tk()
janela.title("Apagar Usuario REP")
janela.geometry('400x200')
janela.resizable(False, False)

# Criando os campos de entrada
label_ip = tk.Label(janela, text="IP:")
label_ip.grid(row=0, column=0)
entry_ip = tk.Entry(janela)
entry_ip.grid(row=0, column=1)

label_login = tk.Label(janela, text="Login:")
label_login.grid(row=1, column=0)
entry_login = tk.Entry(janela)
entry_login.grid(row=1, column=1)

label_senha = tk.Label(janela, text="Senha:")
label_senha.grid(row=2, column=0)
entry_senha = tk.Entry(janela, show="*")
entry_senha.grid(row=2, column=1)

# Criando o botão de executar
botao_executar = tk.Button(janela, text="Executar", command=executar)
botao_executar.grid(row=3, column=0, columnspan=2)

# Criando a Label para exibir o resultado
resultado_label = tk.Label(janela, text="Resultado: ")
resultado_label.grid(row=4, column=0, columnspan=2)

# Iniciando o loop principal da interface
janela.mainloop()