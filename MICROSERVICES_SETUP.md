# Segregação em Microserviços - SolutionKitchen

## 📋 Resumo da Migração

O projeto monolítico foi segregado em **dois microserviços independentes**:

### 🍳 **1. ChefService** (Porta: 5001 / 7001 HTTPS)
- **Responsabilidade**: Gerenciar o ciclo de vida dos pedidos na cozinha
- **Database**: `SolutionKitchen_Chef`
- **Endpoints**:
  - `GET /api/chef/pendentes` - Listar pedidos pendentes
  - `GET /api/chef/em-preparo` - Listar pedidos em preparação
  - `GET /api/chef/prontos` - Listar pedidos prontos
  - `PATCH /api/chef/preparar/{id}` - Marcar pedido como em preparação
  - `PATCH /api/chef/pronto/{id}` - Marcar pedido como pronto

### 🚴 **2. GarcomService** (Porta: 5002 / 7002 HTTPS)
- **Responsabilidade**: Gerenciar criação, edição e remoção de pedidos
- **Database**: `SolutionKitchen_Garcom`
- **Endpoints**:
  - `POST /api/garcom/criar-pedido` - Criar novo pedido
  - `PUT /api/garcom/editar-pedido/{id}` - Editar pedido existente
  - `DELETE /api/garcom/remover-pedido/{id}` - Remover pedido
  - `DELETE /api/garcom/remover-prato/{pedidoId}/{pratoId}` - Remover prato do pedido
  - `GET /api/garcom/listar-pedidos` - Listar todos os pedidos
  - `GET /api/garcom/{id}` - Obter detalhes de um pedido

## 📁 Estrutura de Diretórios

```
SolutionKitchen/
├── Solutionkitchen.csproj (Monolito original)
├── Solutionkitchen.sln (Solução atualizada com 3 projetos)
├── Program.cs
├── appsettings.json
├── Controller/
├── Service/
├── Model/
├── Data/
│
└── MicroServices/
    ├── ChefService/
    │   ├── ChefService.csproj
    │   ├── Program.cs
    │   ├── appsettings.json
    │   ├── Controllers/
    │   │   └── ChefController.cs
    │   ├── Services/
    │   │   └── ChefServiceImpl.cs
    │   ├── Models/
    │   │   ├── Pedido.cs
    │   │   ├── Prato.cs
    │   │   ├── MetodoPagamento.cs
    │   │   └── PessoaNaMesa.cs
    │   ├── Data/
    │   │   └── ChefDbContext.cs
    │   └── Properties/
    │       └── launchSettings.json
    │
    └── GarcomService/
        ├── GarcomService.csproj
        ├── Program.cs
        ├── appsettings.json
        ├── Controllers/
        │   └── GarcomController.cs
        ├── Services/
        │   └── GarcomServiceImpl.cs
        ├── Models/
        │   ├── Pedido.cs
        │   ├── Prato.cs
        │   ├── MetodoPagamento.cs
        │   └── PessoaNaMesa.cs
        ├── Data/
        │   └── GarcomDbContext.cs
        └── Properties/
            └── launchSettings.json
```

## 🚀 Como Executar

### Opção 1: Rodando os microserviços no Visual Studio
1. Abra o arquivo `Solutionkitchen.sln`
2. Defina os múltiplos projetos de inicialização:
   - Clique com botão direito na solução
   - Selecione "Propriedades"
   - Em "Projetos de Inicialização", selecione "Múltiplos projetos de inicialização"
   - Configure `ChefService` e `GarcomService` para iniciar

### Opção 2: Rodando via terminal
```bash
# Terminal 1 - ChefService
cd MicroServices/ChefService
dotnet run

# Terminal 2 - GarcomService
cd MicroServices/GarcomService
dotnet run
```

## 🗄️ Configuração de Banco de Dados

### ChefService
- String de Conexão: `Server=localhost;Database=SolutionKitchen_Chef;Trusted_Connection=true;Encrypt=false;`
- Criar database:
```sql
CREATE DATABASE SolutionKitchen_Chef;
```

### GarcomService
- String de Conexão: `Server=localhost;Database=SolutionKitchen_Garcom;Trusted_Connection=true;Encrypt=false;`
- Criar database:
```sql
CREATE DATABASE SolutionKitchen_Garcom;
```

## 📝 Próximos Passos (Opcional)

1. **API Gateway**: Criar um gateway centralizado para rotear requisições
2. **Message Queue**: Implementar comunicação assíncrona via RabbitMQ ou Service Bus
3. **Docker**: Containerizar os microserviços
4. **Docker Compose**: Orquestração local dos microserviços
5. **Sincronização de Dados**: Implementar padrão Saga ou Event Sourcing para manter sincronismo entre os databases

## 📚 Documentação Swagger

Cada microserviço possui Swagger habilitado:
- **ChefService**: http://localhost:5001 (ou https://localhost:7001)
- **GarcomService**: http://localhost:5002 (ou https://localhost:7002)
