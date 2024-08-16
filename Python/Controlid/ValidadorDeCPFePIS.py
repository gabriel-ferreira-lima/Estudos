numeros_str = '''
13555294775
'''
# Convertendo a string em uma lista de números inteiros
numeros = [int(numero) for numero in numeros_str.strip().split()]
def validar_cpf(cpf):
    cpf_str = str(cpf).zfill(11)

    if len(cpf_str) < 10 or cpf_str == cpf_str[0] * 11:
        return False

    soma = 0
    for i in range(9):
        soma += int(cpf_str[i]) * (10 - i)
    primeiro_digito = 11 - (soma % 11)
    if primeiro_digito > 9:
        primeiro_digito = 0

    soma = 0
    for i in range(10):
        soma += int(cpf_str[i]) * (11 - i)
    segundo_digito = 11 - (soma % 11)
    if segundo_digito > 9:
        segundo_digito = 0

    if int(cpf_str[9]) != primeiro_digito or int(cpf_str[10]) != segundo_digito:
        return False

    return True

def validar_pis(pis):
    pis_str = str(pis).zfill(11)

    if len(pis_str) != 10 and (len(pis_str) != 11 or pis_str == pis_str[0] * 11):
        return False

    multiplicadores = [3, 2, 9, 8, 7, 6, 5, 4, 3, 2]
    soma = 0
    for i in range(10):
        soma += int(pis_str[i]) * multiplicadores[i]
    resto = soma % 11
    digito_verificador = 11 - resto if resto != 0 else 0

    if len(pis_str) == 11 and int(pis_str[10]) != digito_verificador:
        return False

    return True

# Validar cada número da lista
for numero in numeros:
    if validar_cpf(numero):
        print(f"é um CPF válido {numero}")
    elif validar_pis(numero):
        print(f"é um PIS válido {numero}")
    else:
        print(f"não é um CPF nem um PIS válido {numero}")
