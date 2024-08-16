"""
Funções (def) em Python - *args **kwargs -
Aula 16 (parte 3)
"""


def func(*args, **kwargs):
    print(args)

    idade = kwargs.get('idade')
    if idade != None:
        print(idade)
    else:
        print('não tem idade')

lista = [1,2,3,4,5]
lista2 = [10,20,30,40,50]
func(*lista, *lista2, nome='Gabriel', sobrenome='Ferreira')