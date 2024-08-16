"""
Funções - def em Python (Parte 1)
"""


def saudacao(msg='ola', nome='usuario'):
    nome = nome.replace('e', '3')
    msg = msg.replace('e', '3')
    print(msg, nome)


saudacao("ola amigo", "gabriel")
saudacao("tudo bem", "ferreira")
saudacao("com voce", "lima")
saudacao()
saudacao(nome='zezinho')
saudacao(nome='zezinho', msg='ola')


# abaixo a forma mais correta de se utilizar def (não deixar um print dentro da função)

def saudacao1(msg='hello', nome='gabriel'):
    nome = nome.replace('e', '3')
    msg = msg.replace('e', '3')
    return f'{msg} {nome}'

variavel = saudacao1()

print(variavel)

