'''
CPF =168.995.350-09
----------------------------------------------
1 * 10 = 10              #     1 * 11 = 11
6 * 9 = 54               #     6 * 10 = 60
8 * 8 = 64               #     8 *  9 = 72
9 * 7 = 63               #     9 *  8 = 72
9 * 6 = 54               #     9 *  7 = 63
5 * 5 = 25               #     5 *  6 = 30
3 * 4 = 12               #     3 *  5 = 15
5 * 3 = 15               #     5 *  4 = 20
0 * 2 = 0                #     0 *  3 = 0
                         #     0 *  2 = 0
        297              #              343
11 - (297 % 11) = 11     #       11 - (343 % 11) = 9
11 > 9 = 0               #
Digito 1 = 0             #     Digito 2 = 9
'''

cpf = input('digite um CPF ')
final_digito1 = 0
final_digito2 = 0
multiplicador = 10
multiplicador2 = 11
novo_cpf = cpf[:-2]

for valor in cpf[:9]:
    if valor in cpf:
        valor = int(valor)
        valor *= multiplicador
        final_digito1 += valor
        multiplicador -= 1

final_digito1 = 11 - (final_digito1 % 11)
if final_digito1 > 9:
    final_digito1 = 0
else:
    final_digito1 = final_digito1


for valor2 in cpf[:9]:
    if valor2 in cpf:
        valor2 = int(valor2)
        valor2 *= multiplicador2
        final_digito2 += valor2
        multiplicador2 -= 1

digito1_temp = final_digito1 * 2
final_digito2 += digito1_temp
final_digito2 = 11 - (final_digito2 % 11)

if final_digito2 > 9:
    final_digito2 = 0

final_digito1 = str(final_digito1)
final_digito2 = str(final_digito2)
novo_cpf += final_digito1 + final_digito2
sequencia = novo_cpf == str(novo_cpf[0]) * len(cpf)

if novo_cpf == cpf and not sequencia:
    print('que legal o cpf é valido')
else:
    print('ops esse não é um cpf valido')


# conclusão do professor

# Loop infinito
# while True:
#     # cpf = '16899535009'
#     cpf = input('Digite um CPF: ')
#     novo_cpf = cpf[:-2]                 # Elimina os dois últimos digitos do CPF
#     reverso = 10                        # Contador reverso
#     total = 0
#
#     # Loop do CPF
#     for index in range(19):
#         if index > 8:                   # Primeiro índice vai de 0 a 9,
#             index -= 9                  # São os 9 primeiros digitos do CPF
#
#         total += int(novo_cpf[index]) * reverso  # Valor total da multiplicação
#
#         reverso -= 1                    # Decrementa o contador reverso
#         if reverso < 2:
#             reverso = 11
#             d = 11 - (total % 11)
#
#             if d > 9:                   # Se o digito for > que 9 o valor é 0
#                 d = 0
#             total = 0                   # Zera o total
#             novo_cpf += str(d)          # Concatena o digito gerado no novo cpf
#
#     # Evita sequencias. Ex.: 11111111111, 00000000000...
#     sequencia = novo_cpf == str(novo_cpf[0]) * len(cpf)
#
#     # Descobri que sequências avaliavam como verdadeiro, então também
#     # adicionei essa checagem aqui
#     if cpf == novo_cpf and not sequencia:
#         print('Válido')
#     else:
#         print('Inválido')