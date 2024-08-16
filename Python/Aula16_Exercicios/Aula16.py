'''
Faça um programa que peça ao usuário para digitar um número inteiro,
informe se este número é par ou ímpar. Caso o usuário não digite um numero
inteiro, informe que não é um numero inteiro.
'''
num1 = input('digite um numero: ')

try:
    num1 = int(num1)
    if num1 % 2 == 0:
        print(f'{num1} é um numero par')
    else:
        print(f'{num1}  é um numero impar')
except:
    print('Erro Isto não é um numero inteiro')


print()

'''
Faça um programa que pergunte a hora ao usuario e, basendo-se no horario
descrito, exiba a saudação apropriada. EX
Bom dia 0-11, Boa tarde 12-17 e Boa noite 18-23.
'''
horario = input('digite um horario: ')

try:
    horario = int(horario)
    if horario >= 0 and horario <= 11:
        print('Bom dia')
    elif horario >= 12 and horario <= 17:
        print('Boa tarde')
    elif horario >= 18 and horario <= 23:
        print('Boa noite')
    else:
        print('Digite um numero de 1 até 23')
except:
    print('Erro Isto não é um numero inteiro')


print()

'''
Faça um programa que peça o primeiro nome do usuário. Se o nome tiver 4 letras ou
menos escreva "seu nome é curto"; se tiver entre 5 e 6 letras, escreva
"seu nome é normal"; maior que 6 escreva "seu nome é muito grande".
'''
nome = input('digite seu nome: ')
digitos = len(nome)

if digitos <= 4:
    print('seu nome é muito curto')
elif digitos == 5 or digitos == 6:
    print('seu nome é normal')
else:
    print('seu nome é muito grande')
