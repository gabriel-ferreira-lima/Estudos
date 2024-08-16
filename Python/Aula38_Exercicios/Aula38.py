"""
1 - crie uma função1 que recebe uma função2 como parâmetroe retorne o valor da função2 executada.
"""
def funcao1():
    return 2 + 2

def funcao2():
    return funcao1()

var = funcao2()

print(var)

"""
2 - crie uma função1 que recebe uma função2 como parâmetro e retorne o valor da função2 executada.
Faça a função1 executar duas funções que recebam um número diferente de argumentos.
"""

def func1(funcionalidade, *args):
    return funcionalidade(*args)


def func2(*args):
    return 3

def func3(*args):
    return 4 + 8 + 7 + 5

variavel1 = func1(func2)
variavel2 = func1(func3)


print(variavel1)
print(variavel2)