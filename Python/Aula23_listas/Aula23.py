"""
Listas em Python
fatiamento
append = adicionar um valor no final da lista
insert = pode inserir um valor em qualquer indice da lista
pop = apaga um indice da fila
del = apaga varios elementos da fila
clear =
extend = junta duas listas
min = mostra o valor do menor indice da lista
max = mostra o valor do maior indice da lista
range = aula 22
"""
# Indice  0    1    2    3    4     5
# l1 = [1, 2, 3, 4, 5, 6, 7, 8, 9]
# del(l1[3:5])
#
# print(min(l1))
# print(max(l1))

# l2 = list(range(1, 10))
#
# soma = 0
# for valor in l2:
#     print(valor)
#     soma = soma + valor
#     print(soma)

# l3 = ['STRING', True, 1, 10.5]
#
# for elemento in l3:
#     print(f'{type(elemento)}')


# jogo da forca

secreta = 'perfume'
digitadas = []
chances = 3

while True:
    if chances <= 0:
        print('você perdeu')
        break
    letra = (input('Digite uma letra '))
    if len(letra) > 1:
        print('Ahhhh isso não vale, digite apenas uma letra.')
        continue
    digitadas.append(letra)

    if letra in secreta:
        print(f'Resposta correta esta "{letra}" existe no palavra secreta')
    else:
        print (f'OPS esta {letra} não existe na palavra secreta')
        digitadas.pop()

    secreto_temporario = ''
    for letra_secreta in secreta:
        if letra_secreta in digitadas:
            secreto_temporario += letra_secreta
        else:
            secreto_temporario += '*'

    if secreto_temporario == secreta:
        print('que legal você ganhou')
        break
    else:
        print(f'a palavra secreta esta assim : {secreto_temporario}')

    if letra not in secreta:
        chances -= 1
    print (f'voce ainda tem {chances}')
