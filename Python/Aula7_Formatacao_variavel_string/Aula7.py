nome = "Gabriel"
idade = 24
altura = 1.74
peso = 79
e_maior = idade >= 18
IMC = peso / altura ** 2

print(nome, 'tem', idade, 'anos de idade e seu IMC é', IMC)
print(f'{nome} tem {idade} anos de idade e seu IMC é {IMC:.2f}')  # f=format string
print('{} tem {} anos de idade e seu IMC é {:.2f}' .format(nome, idade, IMC))  # .format para colocar a variavel depois
print('{n} tem {i} anos de idade e seu IMC é {im:.2f}' .format(n=nome, i=idade, im=IMC))  # .format melhorado
