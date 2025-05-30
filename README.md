SafeZoneAPI

Sistema inteligente de gestão de zonas de risco e alertas para proteção civil, com recursos de machine learning, microserviços e arquitetura moderna.

📃 Descrição do Projeto

O SafeZoneAPI é uma API RESTful desenvolvida em .NET que oferece:

Cadastro e consulta de regiões de risco.

Geração de alertas com integração ao RabbitMQ.

Proteção via Rate Limiting.

Predições usando ML.NET.

Documentação interativa via Swagger.

🛠️ Tecnologias Utilizadas

ASP.NET Core 8.0

Entity Framework Core

SQL Server LocalDB

RabbitMQ

ML.NET

Swagger / Swashbuckle

AspNetCoreRateLimit

xUnit / Moq

🚀 Como Executar o Projeto

1. Requisitos:

.NET 8 SDK

RabbitMQ (instalado e rodando em localhost)

SQL Server LocalDB

2. Clonar o repositório:

git clone https://github.com/seuusuario/SafeZoneAPI.git
cd SafeZoneAPI

3. Aplicar as Migrations (caso não tenha o banco criado):

dotnet ef database update --project SafeZoneAPI

4. Executar a API:

dotnet run --project SafeZoneAPI

Acesse: https://localhost:5001/swagger

🔍 Documentação dos Endpoints

Regiões de Risco

GET /api/RegiaoRisco - Lista todas as regiões

GET /api/RegiaoRisco/{id} - Detalhes por ID

POST /api/RegiaoRisco - Cria uma nova região

PUT /api/RegiaoRisco/{id} - Atualiza região

DELETE /api/RegiaoRisco/{id} - Remove região

Alertas

GET /api/Alerta - Lista todos os alertas

GET /api/Alerta/{id} - Detalhes por ID

POST /api/Alerta - Gera alerta (publica no RabbitMQ)

PUT /api/Alerta/{id} - Atualiza alerta

DELETE /api/Alerta/{id} - Remove alerta

📄 Instruções de Testes

Executar os testes com xUnit:

cd SafeZoneAPI.Tests
dotnet test

Cobertura:

Testes de integração para Alerta e RegiaoRisco

Mocks com Moq para dependências externas

Testes validando status 200, 201, 404 e erros
