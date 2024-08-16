import requests

ip = "http://192.168.0.129"
usuario = "admin"
senha = "admin"

# fazendo login no rhid
login = requests.post(f"{ip}/login.fcgi", json={
    "login": usuario,
    "password": senha
})
login_data = login.json()
print(login.status_code)
sessao = login_data['session']

cadastra_usuario = requests.post(f"{ip}/create_objects.fcgi?session={sessao}", json={
    'object': 'users',
    'values': [{
        'id': 4,
        'registration': '3',
        'name': 'CADASTRO TESTE DOIS',
        'user_type_id': 1,
        'begin_time': 0,
        'end_time': 0,
        'image_timestamp': 0,
        'last_access': 0
    }]
})

cadastra_usuario_data = cadastra_usuario.json()

print(cadastra_usuario_data)