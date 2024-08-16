"""
similar com tupla/lista, porem você controla o indice
"""

d1 = {'chave1':1, 'chave2':2}

d1['nova_chave'] = '3' # adicionando valor ao dicionario

print(d1)
print(d1['chave2'])

d1['chave1'] = 5 # alterei o valor da chave
d1.update({'nova_chave':10}) # outra forma de alterar o valor da chave

print(d1)

del d1['chave2'] # apaguei um indice da chave

print(d1)

print('chave1' in d1)
print('chave1' in d1.keys()) # checando se chave1 existe dentro do dicionario
print(5 in d1.values()) # checando de 5 existe dentro de algum valor das chaves do dicionario

print(len(d1)) # checa quantos pares de chaves (indices) existe no dicionario

for k, v in d1.items():
    print (k, v)

print()
print()

clientes = {
    'cliente1': {
        'nome':'Gabriel',
        'sobrenome':'Ferreira',
    },
    'cliente2': {
        'nome': 'Pedro',
        'sobrenome': 'Lima',
    },
    'cliente3': {
        'nome': 'Alice',
        'sobrenome': 'Silva',
    },
}

for clientes_k, clientes_v in clientes.items():
    print(f'Exibindo {clientes_k}')
    for dados_k, dados_v in clientes_v.items():
        print(f'\t{dados_k} = {dados_v}')


# Não é possivel criar uma variavel para alterar o valor do dicionario

# transformar uma lista (pode ser uma tupla) em um dicionario

lista = [
    [1, 'a'],
    [2, 'b'],
    [3, 'c']
]

z = dict(lista)
print(z)


#juntas dicionarios
d2 = {1:'a', 2:'b', 3:'c'}

d2.update(d1)
print(d2)