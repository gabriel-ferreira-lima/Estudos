import tkinter as tk

def atualizar_texto(texto, texto_resultado):
    estado_atual = texto_resultado.cget("state")  # Obtém o estado atual do widget
    texto_resultado.configure(state="normal")  # Muda para o estado "normal" para permitir a modificação
    texto_resultado.insert(tk.END, texto + '\n')  # Adiciona o novo texto no final
    texto_resultado.see(tk.END)  # Faz a scrollbar rolar até o final para mostrar o novo texto
    texto_resultado.configure(state=estado_atual)  # Retorna ao estado original do widget
