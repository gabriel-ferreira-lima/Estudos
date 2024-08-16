# Substitua esta string pela sua string completa de nomes
nomes_str = """

"""

# Separar os nomes em uma lista
nomes_lista = nomes_str.split('\n')

# Adicionar aspas duplas e vírgula a cada nome
nomes_formatados = [f'"{nome.strip()}",' for nome in nomes_lista]

# Juntar todos os nomes formatados em uma única string
resultado = '\n'.join(nomes_formatados)

# Exibir o resultado
print(resultado)
