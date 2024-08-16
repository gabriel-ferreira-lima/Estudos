"""
Tipos de dados
str - string - textos 'assim' ou "assim"
int - inteiro - 123456 
float - real - 1.4 - 2.0
bool - booleano - True ou False
"""

print(type('Gabriel'))
print(type(123))  #  type mostra qual tipo de dado estou usando
print(type(123.10))
print(type(True))
print(type(10 == 10))
print('a' == 'a', type ("a" == "a"))
print('a' == 'A', type ("a" == "A"))

#  Exercicios: escrever os valore com os tipos de dados corretos
#  String: nome
print('Gabriel', type('Gabriel'))

#  Idade: int
print('24', type(24))

#  Altura: float
print('1.74', type(1.74))

#  É maior de idade
print(24 >= 18, type(24 >= 18))
