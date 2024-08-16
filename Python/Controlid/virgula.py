numeros = """

"""
# Adiciona uma vírgula no final de cada linha, mantendo as quebras de linha
numeros_com_virgula = "\n".join(f"{linha.strip()}," for linha in numeros.strip().split())

print(numeros_com_virgula)