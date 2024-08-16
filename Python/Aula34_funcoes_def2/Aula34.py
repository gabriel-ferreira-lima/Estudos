"""
Funções - def em Python (Parte 2)
"""


def divisao(n1, n2):
    if n2 == 0:
        return
    return n1 / n2

divide = divisao(10, 0)

if divide:
    print(divide)
else:
    print("invalida")


# uma função pode retornar qualquer coisa, inclusive outra função, como no exemplo abaixo
# def f(var):
#     print(var)
#
# def dumb():
#     return f
#
# var = dumb()
# print(id(var), id(f))
#
# if var == f:
#     print('var é igual a f')
# else:
#     print('blaaaaaaaaaa')
#

# def dumb():
#     return ('Luiz', 'otavio')
#
# var = dumb()
#
# print(var[1], type(var))