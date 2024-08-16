#  o input sempre vira como STRING

nome = input('qual o seu nome ? ')
idade = input('qual a sua idade ? ')
ano_nascimento = 2022 - int(idade)


print(f'o nome dele é {nome} e a variavel é do tipe {type(nome)}')
print(f'tem {idade} anos de idade {type(idade)}')
print(f'nasceu no ano de {ano_nascimento}')



num_1 = int(input('digite um numero '))
num_2 = int(input('digite um numero '))
print()
print(num_1 + num_2)
