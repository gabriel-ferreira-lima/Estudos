'''
print(123456)
print('Gabriel', 'Ferreira', 'Lima')
print('Gabriel', 'Ferreira', sep='-', end='#####')
print('Gabriel', 'e', 'Ferreira', sep='-', end='')
'''

# sep='' <-- posso adicionar um separador entre as palavras dentro do print
# end='' <-- evita que ocorra quebra de linha e inserir algo ao fim do texto
'''
Exercicio 1 : pegar um cpf sem máscara e coloca-lo no 
formato padrão utilizando 'SEP' e 'END'
CPF utilizado 42348922894
'''
print(423, 489, 228, sep='.', end='-94')
print()  # apenas para quebrar a linha

print(423, 489, 228, sep='.', end='-')
print(94)
