# 🧪 Guia de Testes - SolutionKitchen Microserviços

## Pré-requisitos
- Todos os serviços rodando (API Gateway, ChefService, GarcomService)
- Postman ou similar para testar endpoints
- SQL Server com bancos de dados inicializados

---

## 📍 URLs Base

- **API Gateway**: `http://localhost:5000`
- **ChefService**: `http://localhost:5001`
- **GarcomService**: `http://localhost:5002`

---

## 🔍 Testes de Saúde

### Health Check da API Gateway

**Endpoint**: `GET http://localhost:5000/health`

**Response**:
```json
{
  "status": "API Gateway is running"
}
```

---

## 🍽️ ChefService - Testes

### 1. Listar Pedidos Pendentes

**Endpoint**: `GET http://localhost:5000/api/chef/pendentes`

**cURL**:
```bash
curl -X GET http://localhost:5000/api/chef/pendentes
```

**Response** (200 OK):
```json
[
  {
    "id": 1,
    "prato": [
      {
        "id": 1,
        "nome": "Pasta Carbonara",
        "descricao": "Pasta clássica com ovos, queijo e bacon"
      }
    ],
    "quantidade": 2,
    "precoUnitario": 35.50,
    "status": "Pendente",
    "metodoPagamento": 0,
    "pessoa": null
  }
]
```

---

### 2. Listar Pedidos em Preparação

**Endpoint**: `GET http://localhost:5000/api/chef/em-preparo`

**cURL**:
```bash
curl -X GET http://localhost:5000/api/chef/em-preparo
```

---

### 3. Listar Pedidos Prontos

**Endpoint**: `GET http://localhost:5000/api/chef/prontos`

**cURL**:
```bash
curl -X GET http://localhost:5000/api/chef/prontos
```

---

### 4. Marcar Pedido como Em Preparação

**Endpoint**: `PATCH http://localhost:5000/api/chef/preparar/{id}`

**Exemplo**: `PATCH http://localhost:5000/api/chef/preparar/1`

**cURL**:
```bash
curl -X PATCH http://localhost:5000/api/chef/preparar/1
```

**Response** (204 No Content):
```
[Sem conteúdo - apenas status 204]
```

---

### 5. Marcar Pedido como Pronto

**Endpoint**: `PATCH http://localhost:5000/api/chef/pronto/{id}`

**Exemplo**: `PATCH http://localhost:5000/api/chef/pronto/1`

**cURL**:
```bash
curl -X PATCH http://localhost:5000/api/chef/pronto/1
```

**Response** (204 No Content):
```
[Sem conteúdo - apenas status 204]
```

---

## 👨‍💼 GarcomService - Testes

### 1. Criar Pedido

**Endpoint**: `POST http://localhost:5000/api/garcom/criar-pedido`

**Method**: POST

**Headers**:
```
Content-Type: application/json
```

**Body**:
```json
{
  "id": 1,
  "prato": [
    {
      "id": 1,
      "nome": "Pasta Carbonara",
      "descricao": "Pasta clássica com ovos, queijo e bacon"
    }
  ],
  "quantidade": 2,
  "precoUnitario": 35.50,
  "status": "Pendente",
  "metodoPagamento": 0,
  "pessoa": {
    "id": 1,
    "nome": "João Silva",
    "mesaId": 5
  }
}
```

**cURL**:
```bash
curl -X POST http://localhost:5000/api/garcom/criar-pedido \
  -H "Content-Type: application/json" \
  -d '{"id":1,"prato":[{"id":1,"nome":"Pasta Carbonara","descricao":"Pasta clássica"}],"quantidade":2,"precoUnitario":35.50,"status":"Pendente","metodoPagamento":0}'
```

**Response** (201 Created):
```json
{
  "id": 1,
  "prato": [
    {
      "id": 1,
      "nome": "Pasta Carbonara",
      "descricao": "Pasta clássica com ovos, queijo e bacon"
    }
  ],
  "quantidade": 2,
  "precoUnitario": 35.50,
  "status": "Pendente",
  "metodoPagamento": 0,
  "pessoa": {
    "id": 1,
    "nome": "João Silva",
    "mesaId": 5
  }
}
```

---

### 2. Listar Todos os Pedidos

**Endpoint**: `GET http://localhost:5000/api/garcom/listar-pedidos`

**cURL**:
```bash
curl -X GET http://localhost:5000/api/garcom/listar-pedidos
```

---

### 3. Obter Pedido por ID

**Endpoint**: `GET http://localhost:5000/api/garcom/{id}`

**Exemplo**: `GET http://localhost:5000/api/garcom/1`

**cURL**:
```bash
curl -X GET http://localhost:5000/api/garcom/1
```

---

### 4. Editar Pedido

**Endpoint**: `PUT http://localhost:5000/api/garcom/editar-pedido/{id}`

**Exemplo**: `PUT http://localhost:5000/api/garcom/editar-pedido/1`

**Headers**:
```
Content-Type: application/json
```

**Body**:
```json
{
  "id": 1,
  "prato": [
    {
      "id": 2,
      "nome": "Bife à Parmegiana",
      "descricao": "Bife empanado coberto com queijo e molho"
    }
  ],
  "quantidade": 1,
  "precoUnitario": 45.00,
  "status": "Pendente",
  "metodoPagamento": 1
}
```

**cURL**:
```bash
curl -X PUT http://localhost:5000/api/garcom/editar-pedido/1 \
  -H "Content-Type: application/json" \
  -d '{"prato":[{"id":2,"nome":"Bife à Parmegiana"}],"quantidade":1,"precoUnitario":45.00,"metodoPagamento":1}'
```

---

### 5. Remover Prato do Pedido

**Endpoint**: `DELETE http://localhost:5000/api/garcom/remover-prato/{pedidoId}/{pratoId}`

**Exemplo**: `DELETE http://localhost:5000/api/garcom/remover-prato/1/1`

**cURL**:
```bash
curl -X DELETE http://localhost:5000/api/garcom/remover-prato/1/1
```

---

### 6. Remover Pedido

**Endpoint**: `DELETE http://localhost:5000/api/garcom/remover-pedido/{id}`

**Exemplo**: `DELETE http://localhost:5000/api/garcom/remover-pedido/1`

**cURL**:
```bash
curl -X DELETE http://localhost:5000/api/garcom/remover-pedido/1
```

---

## 🚀 Fluxo Completo de Teste

### 1. Criar um novo pedido
```bash
curl -X POST http://localhost:5000/api/garcom/criar-pedido \
  -H "Content-Type: application/json" \
  -d '{
    "id": 1,
    "prato": [{"id": 1, "nome": "Pasta Carbonara", "descricao": "Deliciosa"}],
    "quantidade": 2,
    "precoUnitario": 35.50,
    "status": "Pendente",
    "metodoPagamento": 0
  }'
```

### 2. Verificar pedidos pendentes no Chef
```bash
curl -X GET http://localhost:5000/api/chef/pendentes
```

### 3. Chef marca como em preparação
```bash
curl -X PATCH http://localhost:5000/api/chef/preparar/1
```

### 4. Verificar pedidos em preparação
```bash
curl -X GET http://localhost:5000/api/chef/em-preparo
```

### 5. Chef marca como pronto
```bash
curl -X PATCH http://localhost:5000/api/chef/pronto/1
```

### 6. Verificar pedidos prontos
```bash
curl -X GET http://localhost:5000/api/chef/prontos
```

---

## ⚠️ Códigos de Resposta Esperados

| Código | Descrição |
|--------|-----------|
| 200 | OK - Requisição bem-sucedida |
| 201 | Created - Recurso criado com sucesso |
| 204 | No Content - Operação bem-sucedida, sem retorno |
| 400 | Bad Request - Erro na requisição |
| 404 | Not Found - Recurso não encontrado |
| 500 | Internal Server Error - Erro no servidor |

---

## 📊 Métricas e Monitoramento

### Verificar Logs
```bash
# Docker logs
docker-compose logs -f chef-service
docker-compose logs -f garcom-service
docker-compose logs -f api-gateway
```

### Health Check de Todos os Serviços
```bash
# API Gateway
curl http://localhost:5000/health

# ChefService (direto)
curl http://localhost:5001/swagger

# GarcomService (direto)
curl http://localhost:5002/swagger
```

---

## 🔗 Postman Collection

Você pode importar os endpoints no Postman usando o URL:
`http://localhost:5000/swagger/v1/swagger.json`

---

## 📝 Notas Importantes

1. **Bancos de Dados**: Certifique-se de que os bancos foram criados executando `init-databases.sql`
2. **Portas**: Se as portas padrão estão em uso, atualize `appsettings.json` e `docker-compose.yml`
3. **Conexão**: Os serviços se comunicam via HTTP dentro da network Docker
4. **Estateless**: Cada requisição é independente e não mantém estado entre chamadas
