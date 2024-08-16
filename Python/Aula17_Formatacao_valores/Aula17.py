'''
Formatando valores com modificadores

:s - Texto (string)
:d - Inteiro (int)
:f - Números de ponto flutuante (float)
:. (Número) f - Quantidade de casas decimais (float)
: (caractere) (> ou < ou ^) (quantidade) Tipo - s, d ou f)

> - Esquerda
< - Direita
^ - centro
'''

num_1 = 10
num_2 = 3
divisao = num_1 / num_2

print(f'{divisao:.2f}')


nome = 'Gabriel Ferreira Lima'
print (f'{nome:s}')

print (f'{num_1:#^10}')

print(f'{num_2:0>10.2f}')

print(f'{nome:#^50}')

nome_formatado = '{n:@<50}'.format(n=nome)
print(nome_formatado)
