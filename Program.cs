using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// URL do Firebase
string firebaseUrl = "https://controle-enchentes-default-rtdb.firebaseio.com/";
var firebaseClient = new FirebaseClient(firebaseUrl);

// Lista de sensores com dados a serem atualizados
var sensores = new List<Sensor>
{
    new Sensor
    {
        sensorId = "sensor_001",
        localizacao = new Localizacao { latitude = -30.0150, longitude = -51.2200 },
        dados = new Dados
        {
            nivelAgua = new NivelAgua { valor = 2, unidade = "m" },
            precipitacao = new Precipitacao { valor = 150, unidade = "mm" },
            dataHora = "2024-09-21T14:30:00Z" // Data e hora no formato ISO 8601
        },
        alerta = new Alerta
        {
            nivelCritico = 1,
            status = "normal",
            mensagem = "Nível de água está dentro do limite seguro."
        }
    },
    new Sensor
    {
        sensorId = "sensor_002",
        localizacao = new Localizacao { latitude = -30.0400, longitude = -51.2150 },
        dados = new Dados
        {
            nivelAgua = new NivelAgua { valor = 3.2, unidade = "m" },
            precipitacao = new Precipitacao { valor = 180, unidade = "mm" },
            dataHora = "2024-09-21T14:30:00Z" // Data e hora no formato ISO 8601
        },
        alerta = new Alerta
        {
            nivelCritico = 2,
            status = "alerta",
            mensagem = "Atenção: Nível de água elevado!"
        }
    },
    new Sensor
    {
        sensorId = "sensor_003",
        localizacao = new Localizacao { latitude = -30.0450, longitude = -51.2200 },
        dados = new Dados
        {
            nivelAgua = new NivelAgua { valor = 4.1, unidade = "m" },
            precipitacao = new Precipitacao { valor = 200, unidade = "mm" },
            dataHora = "2024-09-21T14:30:00Z" // Data e hora no formato ISO 8601
        },
        alerta = new Alerta
        {
            nivelCritico = 3,
            status = "perigo",
            mensagem = "Perigo: Inundação iminente!"
        }
    },
    new Sensor
    {
        sensorId = "sensor_004",
        localizacao = new Localizacao { latitude = -30.0500, longitude = -51.2050 },
        dados = new Dados
        {
            nivelAgua = new NivelAgua { valor = 4.1, unidade = "m" },
            precipitacao = new Precipitacao { valor = 220, unidade = "mm" },
            dataHora = "2024-09-21T14:30:00Z" // Data e hora no formato ISO 8601
        },
        alerta = new Alerta
        {
            nivelCritico = 3,
            status = "perigo",
            mensagem = "Perigo: Inundação iminente!"
        }
    },
    new Sensor
    {
        sensorId = "sensor_005",
        localizacao = new Localizacao { latitude = -30.0300, longitude = -51.2000 },
       dados = new Dados
        {
            nivelAgua = new NivelAgua { valor = 3.2, unidade = "m" },
            precipitacao = new Precipitacao { valor = 180, unidade = "mm" },
            dataHora = "2024-09-21T14:30:00Z" // Data e hora no formato ISO 8601
        },
        alerta = new Alerta
        {
            nivelCritico = 2,
            status = "alerta",
            mensagem = "Atenção: Nível de água elevado!"
        }
    }
};

// Atualizar a lista de sensores no Firebase
await AtualizarDadosSensores(firebaseClient, sensores);

Console.WriteLine("Dados atualizados com sucesso!");

// Função para atualizar os dados de todos os sensores
static async Task AtualizarDadosSensores(FirebaseClient firebaseClient, List<Sensor> sensores)
{
    // Para atualizar o nó completo 'sensores'
    await firebaseClient
        .Child("sensores") // Nó "sensores"
        .PutAsync(sensores); // Método PUT para enviar a lista completa de sensores

    Console.WriteLine("Todos os sensores foram atualizados.");
}

// Classes para a estrutura do JSON
public class Sensor
{
    public string sensorId { get; set; }
    public Localizacao localizacao { get; set; }
    public Dados dados { get; set; }
    public Alerta alerta { get; set; }
}

public class Localizacao
{
    public double latitude { get; set; }
    public double longitude { get; set; }
}

public class Dados
{
    public NivelAgua nivelAgua { get; set; }
    public Precipitacao precipitacao { get; set; }
    public string dataHora { get; set; }
}

public class NivelAgua
{
    public double valor { get; set; }
    public string unidade { get; set; }
}

public class Precipitacao
{
    public double valor { get; set; }
    public string unidade { get; set; }
}

public class Alerta
{
    public double nivelCritico { get; set; }
    public string status { get; set; }
    public string mensagem { get; set; }
}
