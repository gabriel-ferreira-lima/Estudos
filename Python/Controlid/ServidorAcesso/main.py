from Controlid.ServidorAcesso.Servidor import app
import CadastroServidor

if __name__ == '__main__':
    #CadastroServidor.InsereDadosDoDispositivo()
    app.run(host='0.0.0.0', port=8002)