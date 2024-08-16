nome = input("qual o seu nome ? ")
contador = len(nome)

print(f'o {nome} tem {contador} caracteres e seu tipo é {type(contador)}\n')

if contador < 6:
    print('voce precisa digitar pelo menos 7 caracteres')

else:
    print('ok')
