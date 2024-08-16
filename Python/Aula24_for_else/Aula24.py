"""
For / Else em Python
"""

variavel = ['Gabriel Ferreira Lima', 'Luiz Otavio', 'João Pereira']
comeca_com_j = False

for valor in variavel:
    if valor.lower().startswith('j'):
        break
else:
    print('não existe uma palavra que começa com J')