# 🚀 Quick Start - SolutionKitchen Microserviços

## ⚡ Iniciar em 3 Minutos

### Opção 1: Docker Compose (Recomendado)

```bash
# 1. Navegue até o diretório
cd c:\Users\Pedro\Solutionkitchen

# 2. Inicie os serviços
docker-compose up -d

# 3. Acesse os serviços
# API Gateway:   http://localhost:5000
# ChefService:   http://localhost:5001
# GarcomService: http://localhost:5002
```

### Opção 2: PowerShell (Windows)

```powershell
# Execute o script
.\start-microservices.ps1

# Escolha opção 1 para Docker Compose
```

### Opção 3: Visual Studio

```
1. Abra Solutionkitchen.sln
2. Clique direito na solução > Propriedades
3. Selecione "Múltiplos projetos de inicialização"
4. Configure: ApiGateway, ChefService, GarcomService para "Start"
5. Pressione F5
```

---

## 🧪 Testar Rapidamente

### 1. Health Check (5 segundos)
```bash
curl http://localhost:5000/health
```

### 2. Criar Pedido (15 segundos)
```bash
curl -X POST http://localhost:5000/api/garcom/criar-pedido \
  -H "Content-Type: application/json" \
  -d '{
    "id": 1,
    "prato": [{"id": 1, "nome": "Pasta", "descricao": "Deliciosa"}],
    "quantidade": 2,
    "precoUnitario": 35.50,
    "status": "Pendente",
    "metodoPagamento": 0
  }'
```

### 3. Ver Pedidos Pendentes (5 segundos)
```bash
curl http://localhost:5000/api/chef/pendentes
```

### 4. Chef Marca como Pronto (5 segundos)
```bash
curl -X PATCH http://localhost:5000/api/chef/pronto/1
```

---

## 📊 Urls de Acesso

| Serviço | HTTP | HTTPS | Swagger |
|---------|------|-------|---------|
| API Gateway | http://localhost:5000 | https://localhost:7000 | ✅ |
| ChefService | http://localhost:5001 | https://localhost:7001 | ✅ |
| GarcomService | http://localhost:5002 | https://localhost:7002 | ✅ |

---

## 🛑 Parar os Serviços

```bash
# Docker
docker-compose down

# PowerShell
.\start-microservices.ps1
# Escolha opção 4

# Visual Studio
Pressione Shift+F5 ou Stop
```

---

## 📁 Arquivos Importantes

```
Solutionkitchen/
├── docker-compose.yml          ← Orquestração
├── init-databases.sql          ← Criar bancos
├── TESTING_GUIDE.md            ← Guia de testes
├── README_MICROSERVICES.md     ← Documentação completa
└── MicroServices/
    ├── ApiGateway/
    ├── ChefService/
    └── GarcomService/
```

---

## ❓ Problemas Comuns

### Porta já em uso
```bash
# Windows
netstat -ano | findstr :5000
taskkill /PID <PID> /F
```

### Erro de conexão ao banco
```bash
# Execute o script SQL
sql server> init-databases.sql

# Ou verifique os dados de conexão em appsettings.json
```

### Docker não funciona
```bash
# Verifique se Docker está rodando
docker --version

# Reconstrua as imagens
docker-compose up -d --build
```

---

## 📝 Endpoints Principais

```
# Chef - Ver pendentes
GET http://localhost:5000/api/chef/pendentes

# Chef - Marcar pronto
PATCH http://localhost:5000/api/chef/pronto/1

# Garcom - Criar pedido
POST http://localhost:5000/api/garcom/criar-pedido

# Garcom - Listar pedidos
GET http://localhost:5000/api/garcom/listar-pedidos
```

---

## 🎯 Próximo Passo

1. ✅ Iniciar os serviços
2. ✅ Acessar http://localhost:5000
3. ✅ Explorar Swagger
4. 👉 Ler TESTING_GUIDE.md para mais exemplos

---

## 📚 Documentação Completa

- **README_MICROSERVICES.md** - Guia completo (20 min)
- **TESTING_GUIDE.md** - Exemplos de testes (15 min)
- **MICROSERVICES_SETUP.md** - Setup inicial (10 min)
- **SUMMARIZE.md** - Sumário visual (5 min)
- **CHECKLIST.md** - O que foi implementado (3 min)
- **QUICK_START.md** - Este arquivo (2 min)

---

Pronto! 🎉 Seus microserviços estão rodando!
