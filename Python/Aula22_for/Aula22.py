"""
For in em Python
Iterando strings com for
função range (start=0, stop, step=1)
"""
texto = 'Python'

for numero in range(0, 11, 2):
    print(numero)

print('##################')

for n in range(100):
    if n % 8 == 0:
        print(n)

print('##################')

texto = 'Python'
nova_string = ''

# continue: pula para proxima iteração
# break: quebra o laço

for letra in texto:
    if letra == 't':
        nova_string = nova_string + letra.upper()
    elif letra == 'h':
        nova_string = nova_string + letra.upper()
    else:
        nova_string = nova_string + letra

print(nova_string)
