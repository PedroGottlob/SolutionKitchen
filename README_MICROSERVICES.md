# 🍳 SolutionKitchen - Arquitetura de Microserviços

## 📋 Visão Geral

Este projeto implementa uma arquitetura de microserviços para um sistema de gerenciamento de restaurante, segregando as responsabilidades em dois serviços independentes:

- **ChefService**: Gerencia o ciclo de vida dos pedidos na cozinha
- **GarcomService**: Gerencia a criação e edição de pedidos
- **ApiGateway**: Roteia as requisições para os microserviços apropriados

## 🏗️ Arquitetura

```
┌─────────────────────────────────────────┐
│         Client (Aplicação Web)          │
└────────────────┬────────────────────────┘
                 │
                 ▼
┌─────────────────────────────────────────┐
│          API Gateway (Porta 5000)       │
│         (Ocelot - Roteador)             │
└────────────┬────────────────┬───────────┘
             │                │
      ┌──────▼──────┐  ┌──────▼──────┐
      │  ChefService│  │GarcomService│
      │  (Porta 5001)  │  (Porta 5002)
      │              │  │              │
      │ ┌──────────┐ │  │ ┌──────────┐ │
      │ │Chef DB   │ │  │ │Garcom DB │ │
      │ └──────────┘ │  │ └──────────┘ │
      └──────────────┘  └──────────────┘
```

## 🚀 Como Executar

### Opção 1: Usando Docker Compose (Recomendado)

#### Pré-requisitos:
- Docker Desktop instalado
- Docker Compose

#### Passos:

1. **Navegue até o diretório raiz do projeto**:
```bash
cd c:\Users\Pedro\Solutionkitchen
```

2. **Inicie todos os serviços**:
```bash
docker-compose up -d
```

3. **Verifique se os serviços estão rodando**:
```bash
docker-compose ps
```

4. **Acesse os serviços**:
   - **API Gateway**: http://localhost:5000 (Swagger UI)
   - **ChefService**: http://localhost:5001 (Swagger UI)
   - **GarcomService**: http://localhost:5002 (Swagger UI)

5. **Parar os serviços**:
```bash
docker-compose down
```

---

### Opção 2: Executando Localmente (Desenvolvimento)

#### Pré-requisitos:
- Visual Studio 2022 ou posterior
- .NET 9.0 SDK
- SQL Server 2022 Express ou superior

#### Passos:

1. **Preparar bancos de dados**:
   - Abra SQL Server Management Studio
   - Execute o script `init-databases.sql` para criar os bancos de dados

2. **Abrir a solução**:
   ```bash
   Solutionkitchen.sln
   ```

3. **Configurar múltiplos projetos de inicialização**:
   - Clique com botão direito em `Solutionkitchen.sln`
   - Selecione **Propriedades**
   - Em **Projetos de Inicialização**, selecione **Múltiplos projetos de inicialização**
   - Configure os seguintes projetos para **Start**:
     - ApiGateway
     - ChefService
     - GarcomService

4. **Executar a solução**:
   - Pressione `F5` ou clique em **Start**

5. **Acessar os serviços**:
   - **API Gateway**: http://localhost:5000
   - **ChefService**: http://localhost:5001
   - **GarcomService**: http://localhost:5002

---

### Opção 3: Executando via Terminal (Desenvolvimento)

#### Terminal 1 - API Gateway:
```bash
cd MicroServices/ApiGateway
dotnet run
```

#### Terminal 2 - ChefService:
```bash
cd MicroServices/ChefService
dotnet run
```

#### Terminal 3 - GarcomService:
```bash
cd MicroServices/GarcomService
dotnet run
```

---

## 📡 Endpoints da API

### API Gateway (Porta 5000)

Roteia para os microserviços correspondentes:

```
GET  /api/chef/pendentes          → ChefService
GET  /api/chef/em-preparo        → ChefService
GET  /api/chef/prontos           → ChefService
PATCH /api/chef/preparar/{id}    → ChefService
PATCH /api/chef/pronto/{id}      → ChefService

POST /api/garcom/criar-pedido           → GarcomService
PUT  /api/garcom/editar-pedido/{id}     → GarcomService
DELETE /api/garcom/remover-pedido/{id}  → GarcomService
DELETE /api/garcom/remover-prato/{pedidoId}/{pratoId} → GarcomService
GET  /api/garcom/listar-pedidos         → GarcomService
GET  /api/garcom/{id}                   → GarcomService
```

---

## 🔧 Configuração

### Variáveis de Ambiente

#### Para Docker:
Definidas automaticamente no `docker-compose.yml`

#### Para Desenvolvimento Local:
Modificar em `appsettings.json` de cada serviço:

**ChefService** (`MicroServices/ChefService/appsettings.json`):
```json
{
  "ConnectionStrings": {
    "ChefConnection": "Server=localhost;Database=SolutionKitchen_Chef;Trusted_Connection=true;Encrypt=false;"
  }
}
```

**GarcomService** (`MicroServices/GarcomService/appsettings.json`):
```json
{
  "ConnectionStrings": {
    "GarcomConnection": "Server=localhost;Database=SolutionKitchen_Garcom;Trusted_Connection=true;Encrypt=false;"
  }
}
```

---

## 📊 Estrutura de Diretórios

```
SolutionKitchen/
├── MicroServices/
│   ├── ApiGateway/
│   │   ├── Program.cs
│   │   ├── ocelot.json
│   │   ├── appsettings.json
│   │   ├── Dockerfile
│   │   └── Properties/
│   │
│   ├── ChefService/
│   │   ├── Controllers/ChefController.cs
│   │   ├── Services/ChefServiceImpl.cs
│   │   ├── Models/
│   │   ├── Data/ChefDbContext.cs
│   │   ├── Program.cs
│   │   ├── appsettings.json
│   │   ├── Dockerfile
│   │   └── Properties/
│   │
│   ├── GarcomService/
│   │   ├── Controllers/GarcomController.cs
│   │   ├── Services/GarcomServiceImpl.cs
│   │   ├── Models/
│   │   ├── Data/GarcomDbContext.cs
│   │   ├── Program.cs
│   │   ├── appsettings.json
│   │   ├── Dockerfile
│   │   └── Properties/
│   │
│   └── Shared/
│       ├── Clients/
│       ├── Dtos/
│       └── Models/
│
├── docker-compose.yml
├── init-databases.sql
├── Solutionkitchen.sln
└── MICROSERVICES_SETUP.md
```

---

## 🔄 Fluxo de Comunicação

### 1. Criar Pedido
```
Cliente → API Gateway → GarcomService (POST /api/garcom/criar-pedido)
         → Armazena no banco de dados SolutionKitchen_Garcom
```

### 2. Chef Visualiza Pedidos Pendentes
```
Chef → API Gateway → ChefService (GET /api/chef/pendentes)
     → Consulta SolutionKitchen_Chef
     → Retorna lista de pedidos
```

### 3. Chef Marca Pedido como Pronto
```
Chef → API Gateway → ChefService (PATCH /api/chef/pronto/{id})
     → Atualiza status em SolutionKitchen_Chef
```

---

## 🗄️ Bancos de Dados

### SolutionKitchen_Chef
- Gerenciado pelo ChefService
- Armazena pedidos e seus estados na cozinha
- Sincroniza automaticamente com GarcomService via API

### SolutionKitchen_Garcom
- Gerenciado pelo GarcomService
- Armazena criação/edição de pedidos
- Fonte de verdade para informações de pedidos

---

## 🐛 Troubleshooting

### 1. Erro de conexão com banco de dados
- Verifique se SQL Server está rodando
- Confirme as strings de conexão em `appsettings.json`
- Execute `init-databases.sql` para criar os bancos

### 2. Porta já em uso
```bash
# Encontrar processo usando a porta (Windows)
netstat -ano | findstr :5000
# Matar processo
taskkill /PID <PID> /F
```

### 3. Problemas com Docker
```bash
# Limpar containers antigos
docker-compose down -v

# Reconstruir imagens
docker-compose up -d --build
```

---

## 📈 Próximos Passos

1. **Implementar Logging Centralizado** (Serilog + ELK Stack)
2. **Adicionar Autenticação** (JWT)
3. **Implementar Message Queue** (RabbitMQ/Azure Service Bus)
4. **Cache Distribuído** (Redis)
5. **Circuit Breaker** (Polly)
6. **Monitoramento** (Prometheus + Grafana)
7. **Kubernetes** (K8s deployment)

---

## 📝 Licença

Este projeto está sob a licença MIT.

---

## 👨‍💻 Autor

Pedro Gottlob

---

## 📞 Suporte

Para dúvidas ou problemas, abra uma issue no repositório.
