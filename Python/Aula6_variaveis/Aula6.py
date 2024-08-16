nome = "Gabriel"
idade = 24
altura = 1.74
peso = 78.5
e_maior = idade >= 18
IMC = peso / (altura * altura)

print('Nome:', nome)
print('Idade:', idade)
print('Altura:', altura)
print('Peso:', peso)
print('É maior:', e_maior)

#  Exercicio, como calcular IMC

print(nome, 'tem', idade, 'anos de idade e seu IMC é', (peso / (altura * altura)))
#  ou
print(nome, 'tem', idade, 'anos de idade e seu IMC é', IMC)
