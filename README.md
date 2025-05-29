# SafeZoneAPI

API RESTful para mapeamento e monitoramento de regiões de risco com alertas e abrigos, construída como parte da disciplina **Advanced Business Development with .NET** (FIAP, Global Solution 2025).

---

## 📌 Descrição do Projeto

A aplicação permite:

- Cadastrar e consultar **regiões de risco** (enchente, deslizamento, etc)
- Cadastrar e consultar **alertas** emitidos para essas regiões
- Gerenciar **abrigos** de suporte à população afetada
- Enviar mensagens para uma fila RabbitMQ (simulado)
- Aplicar limitação de requisições por IP
- Utilizar `ML.NET` (pronto para expansão com modelos preditivos)

---

## ⚙ Tecnologias Utilizadas

- **ASP.NET Core 8.0**
- **Entity Framework Core**
- **Swagger (Swashbuckle)**
- **xUnit + Moq**
- **AspNetCoreRateLimit**
- **RabbitMQ (Publisher simulado)**
- **ML.NET**
- **SQL Server LocalDB**

---

## 🚀 Como Executar o Projeto

1. **Clone o repositório** e abra a solução no Visual Studio ou VS Code.
2. **Restaure os pacotes**:
   ```bash
   dotnet restore
Compile a solução:

bash
Copiar
Editar
dotnet build
Execute a API com ponto de entrada explícito:

bash
Copiar
Editar
dotnet run --project SafeZoneAPI/SafeZoneAPI.csproj --launch-profile "SafeZoneAPI"
📘 Documentação dos Endpoints
Acesse https://localhost:<porta>/swagger ao executar a API.

Principais endpoints:

GET /api/RegiaoRisco

POST /api/RegiaoRisco

GET /api/Alerta

POST /api/Alerta

GET /api/Abrigo

POST /api/Abrigo

🧪 Instruções de Testes
Acesse a pasta SafeZoneAPI.Tests

Execute:

bash
Copiar
Editar
dotnet test
Os testes cobrem:

Consulta de regiões de risco

Inserção e validação de alertas

Mock do serviço RabbitMQ

Inicialização da API com WebApplicationFactory