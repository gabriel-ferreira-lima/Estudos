"""
diferença da tupla da lista : você não pode editar/adicionar/remover tuplas
"""

t1 = (1, 2, 3, 4)  # a tupla pode ser criada sem os parenteses
t2 = 5,6,7,8
t3 = t1 + t2
print(t3) # juntei 2 tuplas t1 e t2

n1, n2, n3, *_ = t3  # transformei os primeiros indices da tupla em variavel e apresentei no print abaixo
print(n3)

print(t1[0:4:2])


t4 = (6,7,8,9)
t4 = list(t1)  # transformei a tupla em lista
t4[0] = 600  # alterei o valor da tupla
print(t4)
t4 = tuple(t4)  # transformei a lista em tupla
print(t4)
