num1 = input('Digite um número: ')
num2 = input('Digite um número: ')

# isnumeric isdigit isdecimal
# essas funções validam se o usuario esta digitando apenas numeros inteiros

if num1.isnumeric() and num2.isnumeric():
    num1 = int(num1)
    num2 = int(num2)
    print(num1 + num2)
else:
    print('Por favor, digite apenas numeros')