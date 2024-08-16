'''
mostrar esse print abaixo com while ou for

0 10
1 9
2 8
3 7
4 6
5 5
6 4
7 3
8 2
'''

# com while
contador = 0
contador1 = 10

while contador <= 8 and contador1 >=2:
    print(contador, contador1)
    contador += 1
    contador1 -= 1

print()
# com for
valor2 = 10
for valor in range(9):
    print(valor, valor2)
    valor2 -= 1

print()
# Solução do professor

for p, r in enumerate(range(10 , 1 , -1)):
    print(p, r)