
variavel = 'valor'
#
# def func():
#     print(variavel)
#
# def func2(args):
#     args = args.replace('v', 'c')
#     return args
#
# func()
# outra_variavel = func2(args=variavel)
#
# print(outra_variavel)


def func():
    outra_variavel = 'valor'
    return outra_variavel

def func2(arg):
    print(arg)

var = func()

func2(var)