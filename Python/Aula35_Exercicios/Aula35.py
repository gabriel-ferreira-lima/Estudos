"""
1 - Crie uma função que exibe uma saudação com os parâmetros saudação e nome.
"""
def func1(saudacao='ola', nome='gabriel'):
    print(saudacao, nome)

func1()

"""
2 - Crie uma função que recebe 3 números com parãmetros e exiba a soma entre eles.
"""
def func2(num1, num2, num3):
    return num1 + num2 + num3

var2 = func2(1, 2 , 3)

print(var2)

"""
3 - Crie uma função que receba 2 números. O primeiro é um valor e o segundo um percentual (ex. 10%).
Retorne (return) o valor do primeiro número somado do aumento do percentual do mesmo.
"""
def func3(n1, n2):
    return n1+(n1*(n2 / 100))

var3 = func3(100, 10)

print(var3)

"""
4 - Fizz Buzz - Se o parâmetro da função for divisível por 2, retorne fizz, se o parâmetro da função for divisível
por 5, retorne buzz. se o parâmetro da função for divisível por 5 e por 3, retorne FizzBuzz, caso contrário, retorne
o número enviado.
"""

def func4(numero1):
    if numero1 % 3 == 0 and numero1 % 5 == 0:
        return "fizzBuzz"
    if numero1 % 5 == 0:
        return "buzz"
    if numero1 % 3 == 0:
        return "fizz"
    return numero1

var4 = func4(1)

print(var4)