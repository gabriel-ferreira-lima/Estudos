"""
While em Python
Utilizado para realizar ações enquanto
uma condição for verdadeira.

Requisitos: entender condições e operadores
"""
x = 0

while x < 10:
    if x == 3:
        x = x + 1
        continue
    print(x)
    x = x + 1

print('acabou!')


x2 = 0

while x2 < 10:
    if x2 == 3:
        x2 = x2 + 1
        break
    print(x2)
    x2 = x2 + 1

print('acabou2!')


A = 0

while A < 10:
    B = 0
    while B < 5:
        print(f'X vale{A} e Y vale {B}')
        B = B + 1
    A = A + 1

print('acabou3!')


# CALCULADORA SIMPLES

while True:
    print()
    num_1 = input('Digite um número: ')
    num_2 = input('Digite um número: ')
    operador = input('Digite um operador: ')
    if not num_1.isnumeric() or not num_2.isnumeric():
        print('por favor digite um numero')
        continue
    num_1 = int(num_1)
    num_2 = int(num_2)
    if operador == '+':
        print(num_1 + num_2)
    elif operador == '-':
        print(num_1 - num_2)
    elif operador == '*':
        print(num_1 * num_2)
    elif operador == '/':
        print(num_1 / num_2)
    else:
        print('por favor coloque um operador valido')
