import firebase_admin
from firebase_admin import credentials
from firebase_admin import db
import json

# URL do Firebase
firebase_url = "https://controle-enchentes-default-rtdb.firebaseio.com/"
cred = credentials.Certificate("path/to/your/serviceAccountKey.json")
firebase_admin.initialize_app(cred, {
    'databaseURL': firebase_url
})

# Classe para a estrutura do JSON
class Sensor:
    def __init__(self, sensor_id, localizacao, dados, alerta):
        self.sensorId = sensor_id
        self.localizacao = localizacao
        self.dados = dados
        self.alerta = alerta

class Localizacao:
    def __init__(self, latitude, longitude):
        self.latitude = latitude
        self.longitude = longitude

class Dados:
    def __init__(self, nivel_agua, precipitacao, data_hora):
        self.nivelAgua = nivel_agua
        self.precipitacao = precipitacao
        self.dataHora = data_hora

class NivelAgua:
    def __init__(self, valor, unidade):
        self.valor = valor
        self.unidade = unidade

class Precipitacao:
    def __init__(self, valor, unidade):
        self.valor = valor
        self.unidade = unidade

class Alerta:
    def __init__(self, nivel_critico, status, mensagem):
        self.nivelCritico = nivel_critico
        self.status = status
        self.mensagem = mensagem

# Lista de sensores com dados a serem atualizados
sensores = [
    Sensor(
        sensor_id="sensor_001",
        localizacao=Localizacao(latitude=-30.0150, longitude=-51.2200),
        dados=Dados(
            nivel_agua=NivelAgua(valor=2, unidade="m"),
            precipitacao=Precipitacao(valor=150, unidade="mm"),
            data_hora="2024-09-21T14:30:00Z"
        ),
        alerta=Alerta(
            nivel_critico=1,
            status="normal",
            mensagem="Nível de água está dentro do limite seguro."
        )
    ),
    Sensor(
        sensor_id="sensor_002",
        localizacao=Localizacao(latitude=-30.0400, longitude=-51.2150),
        dados=Dados(
            nivel_agua=NivelAgua(valor=3.2, unidade="m"),
            precipitacao=Precipitacao(valor=180, unidade="mm"),
            data_hora="2024-09-21T14:30:00Z"
        ),
        alerta=Alerta(
            nivel_critico=2,
            status="alerta",
            mensagem="Atenção: Nível de água elevado!"
        )
    ),
    Sensor(
        sensor_id="sensor_003",
        localizacao=Localizacao(latitude=-30.0450, longitude=-51.2200),
        dados=Dados(
            nivel_agua=NivelAgua(valor=4.1, unidade="m"),
            precipitacao=Precipitacao(valor=200, unidade="mm"),
            data_hora="2024-09-21T14:30:00Z"
        ),
        alerta=Alerta(
            nivel_critico=3,
            status="perigo",
            mensagem="Perigo: Inundação iminente!"
        )
    ),
    Sensor(
        sensor_id="sensor_004",
        localizacao=Localizacao(latitude=-30.0500, longitude=-51.2050),
        dados=Dados(
            nivel_agua=NivelAgua(valor=4.1, unidade="m"),
            precipitacao=Precipitacao(valor=220, unidade="mm"),
            data_hora="2024-09-21T14:30:00Z"
        ),
        alerta=Alerta(
            nivel_critico=3,
            status="perigo",
            mensagem="Perigo: Inundação iminente!"
        )
    ),
    Sensor(
        sensor_id="sensor_005",
        localizacao=Localizacao(latitude=-30.0300, longitude=-51.2000),
        dados=Dados(
            nivel_agua=NivelAgua(valor=3.2, unidade="m"),
            precipitacao=Precipitacao(valor=180, unidade="mm"),
            data_hora="2024-09-21T14:30:00Z"
        ),
        alerta=Alerta(
            nivel_critico=2,
            status="alerta",
            mensagem="Atenção: Nível de água elevado!"
        )
    )
]

# Função para atualizar os dados de todos os sensores
def atualizar_dados_sensores(sensores):
    # Converte a lista de sensores em um dicionário
    sensores_dict = {sensor.sensorId: sensor.__dict__ for sensor in sensores}
    
    # Atualiza o nó 'sensores' no Firebase
    db.reference("sensores").set(sensores_dict)

    print("Todos os sensores foram atualizados.")

# Atualizar a lista de sensores no Firebase
atualizar_dados_sensores(sensores)
print("Dados atualizados com sucesso!")
