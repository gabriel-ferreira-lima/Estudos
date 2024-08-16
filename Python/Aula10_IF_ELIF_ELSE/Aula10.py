'''
Esta aula abrange a aula 10, 11 e 12

Aula 10
IF (se)
elif (senão se)
else (senão)

Aula 11
operadores relacionais
==
> maior
< menor
>= maior que ou igual a
<= menor que ou igual a
!= diferente

Aula 12
Operadores Lógicos
and (e)
or (ou)
not < este operador serve para inverter a operação
in < existe dentro do valor ou variavel
not in < não existe dentro do valor ou variavel
'''

print('Aula 10')
# Aula 10
if False:
    print('blablabla')
elif False:
    print('blablabla')
else:
    print('opaaaaaaa\n')

print('Aula 11')
# Aula 11

nome = input('Qual o seu nome ? ')
idade = int(input('quantos anos você tem ? '))
idade_menor = 18
idade_maior = 30

if idade >= idade_menor:
    print(f'{nome} pode pegar o empréstimo')
else:
    print(f'{nome} não tem direito ao empréstimo')


if idade >= idade_menor and idade <= idade_maior:
    print(f'{nome} Pode pegar o emprestimo\n')
elif idade <= idade_menor:
    print(f'{nome} é muito novo para pegar emprestimo\n')
else:
    print(f'{nome} é muito velho para pegar emprestimo\n')

print('Aula 12')
# Aula 12

# exemplo de NOT
a = 2
b = 3
if not b > a:
    print('B é maior do que A. ')
else:
    print('A é maior do que B. ')


# exemplo de in

if 'G' in nome:
    print(f'A letra "G" existe dentro do nome do {nome}')
else:
    print(f'A letra "G" não existe dentro do nome do {nome}')
