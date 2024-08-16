'''
Criar variáveis para nome (str), idade (int),
altura (float) e peso (float) de uma pessoa
criar variável com o ano atual (int)
obter o ano de nascimento da pessoa (baseado na ideade e no ano atual)
obter o IMC da pessoa com 2 casas decimais (peso e na altura da pessoa)
Exibir um texto com todos os valores na tela usando F-strings (com as chaves)
'''

nome = 'Gabriel'
idade = 25
altura = 1.74
peso = 78.5
ano_atual = 2022
imc = peso / altura ** 2
nascimento = ano_atual - idade

print(f'{nome} tem {idade} anos, {altura} de altura e pesa {peso}KG \no IMC de {nome} é {imc:.2f} \n{nome} '
      'nasceu em {nascimento}')