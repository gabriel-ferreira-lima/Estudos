logged_user = True
msg = 'Usuario logado.' if logged_user else 'usuario precisa logar. '

print(msg)

idade = input('digite sua idade. ')

if not idade.isnumeric():
    print('digite um numero valido')
else:
    idade = int(idade)
    eh_maior = (idade >= 18)
    mensagem = 'pode acessar' if eh_maior else 'não pode acessar'
    
    print(mensagem)