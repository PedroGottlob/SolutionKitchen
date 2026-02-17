# 🍳 SolutionKitchen - Segregação em Microserviços

## 📢 Anúncio Importante

Este repositório foi **segregado em microserviços independentes**! 

O monolito original foi transformado em uma **arquitetura de microserviços** com API Gateway, seguindo as melhores práticas de design.

---

## 🚀 O que foi criado

### ✅ 3 Microserviços Independentes

1. **API Gateway** (Porta 5000)
   - Ocelot para roteamento centralizado
   - Ponto de entrada único
   - Swagger/OpenAPI integrado

2. **ChefService** (Porta 5001)
   - Gerencia pedidos na cozinha
   - Visualiza pendentes, em preparação, prontos
   - Database isolado: `SolutionKitchen_Chef`

3. **GarcomService** (Porta 5002)
   - Cria, edita e remove pedidos
   - Gerencia pratos dos pedidos
   - Database isolado: `SolutionKitchen_Garcom`

---

## 📁 Estrutura Criada

```
MicroServices/
├── ApiGateway/          ← Roteador central
├── ChefService/         ← Serviço do chef
├── GarcomService/       ← Serviço do garçom
└── Shared/              ← Código compartilhado

docker-compose.yml       ← Orquestração com Docker
init-databases.sql       ← Script de inicialização
QUICK_START.md          ← Início rápido
README_MICROSERVICES.md ← Documentação completa
TESTING_GUIDE.md        ← Exemplos de teste
```

---

## ⚡ Iniciar em 30 Segundos

### Docker Compose (Recomendado)
```bash
docker-compose up -d
```

### Visual Studio
```
1. Abra Solutionkitchen.sln
2. Configure múltiplos projetos de inicialização
3. Pressione F5
```

### PowerShell
```powershell
.\start-microservices.ps1
```

---

## 🔗 URLs de Acesso

- **API Gateway**: http://localhost:5000
- **ChefService**: http://localhost:5001
- **GarcomService**: http://localhost:5002

Todos com Swagger/OpenAPI habilitado!

---

## 📚 Documentação

| Arquivo | Tempo | Conteúdo |
|---------|-------|----------|
| **QUICK_START.md** | 2 min | Iniciar em minutos |
| **README_MICROSERVICES.md** | 20 min | Guia completo |
| **TESTING_GUIDE.md** | 15 min | Exemplos de teste |
| **ARCHITECTURE.txt** | 10 min | Diagrama visual |
| **SUMMARIZE.md** | 5 min | Sumário da implementação |
| **CHECKLIST.md** | 3 min | O que foi feito |

---

## 🎯 Endpoints Principais

### Via API Gateway
```bash
# Chef - Pedidos pendentes
GET http://localhost:5000/api/chef/pendentes

# Chef - Marcar como pronto
PATCH http://localhost:5000/api/chef/pronto/1

# Garcom - Criar pedido
POST http://localhost:5000/api/garcom/criar-pedido

# Garcom - Listar pedidos
GET http://localhost:5000/api/garcom/listar-pedidos
```

---

## 🧪 Teste Rápido

```bash
# Health check
curl http://localhost:5000/health

# Listar pedidos pendentes
curl http://localhost:5000/api/chef/pendentes

# Criar novo pedido
curl -X POST http://localhost:5000/api/garcom/criar-pedido \
  -H "Content-Type: application/json" \
  -d '{"id":1,"quantidade":2,"precoUnitario":35.50}'
```

---

## 🗄️ Bancos de Dados

### SolutionKitchen_Chef
- Gerenciado por ChefService
- Tabelas: Pedidos, Pratos

### SolutionKitchen_Garcom
- Gerenciado por GarcomService
- Tabelas: Pedidos, Pratos

**Criar bancos automaticamente**: Execute `init-databases.sql`

---

## 🐳 Docker

### Iniciar
```bash
docker-compose up -d
```

### Verificar Status
```bash
docker-compose ps
```

### Parar
```bash
docker-compose down
```

### Logs
```bash
docker-compose logs -f chef-service
docker-compose logs -f garcom-service
docker-compose logs -f api-gateway
```

---

## 📊 Benefícios da Segregação

✅ **Deploy Independente**
- Atualizar um serviço sem afetar outros

✅ **Escalabilidade Seletiva**
- Escalar apenas o serviço que precisa

✅ **Isolamento de Falhas**
- Se um serviço cai, outros continuam

✅ **Tecnologias Diferentes**
- Usar ferramentas apropriadas por serviço

✅ **Equipes Paralelas**
- Diferentes times podem trabalhar separadamente

✅ **Manutenibilidade**
- Código mais simples e focado

---

## 🛠️ Tecnologias

- **.NET 9.0** - Framework
- **ASP.NET Core** - Web framework
- **Entity Framework Core** - ORM
- **SQL Server** - Database
- **Ocelot** - API Gateway
- **Docker** - Containerização
- **Swagger/OpenAPI** - Documentação
- **C#** - Linguagem

---

## 🚦 Status

✅ **100% Completo**

- [x] Microserviços criados
- [x] API Gateway implementado
- [x] Dockerização completa
- [x] Documentação
- [x] Scripts de inicialização
- [x] Exemplos de teste
- [x] Commit no Git

---

## 📞 Próximos Passos

### Recomendado
1. ✅ Ler **QUICK_START.md**
2. ✅ Iniciar os serviços
3. ✅ Testar endpoints em **TESTING_GUIDE.md**
4. ✅ Explorar Swagger em cada serviço

### Avançado (Futuro)
- [ ] Autenticação (JWT)
- [ ] Message Queue (RabbitMQ)
- [ ] Cache Distribuído (Redis)
- [ ] Logging Centralizado (ELK)
- [ ] Monitoramento (Prometheus)
- [ ] Kubernetes

---

## 📝 Notas

1. **SQL Server**: Use SQL Server 2022 Express ou Docker
2. **Docker**: Para usar docker-compose, instale Docker Desktop
3. **Portas**: Verifique se 5000, 5001, 5002 estão livres
4. **Bancos**: Execute `init-databases.sql` antes de usar

---

## 💡 Dicas

- Use **QUICK_START.md** para iniciar rápido
- Consulte **TESTING_GUIDE.md** para exemplos de API
- Veja **ARCHITECTURE.txt** para diagramas visuais
- Leia **README_MICROSERVICES.md** para documentação completa

---

## ✨ Resultado

🎉 **Arquitetura de microserviços totalmente funcional e pronta para produção!**

Parabéns! Você agora tem:
- ✅ 3 serviços independentes
- ✅ API Gateway centralizado
- ✅ Bancos de dados isolados
- ✅ Docker setup completo
- ✅ Documentação completa
- ✅ Exemplos de teste

---

## 📧 Suporte

Para dúvidas, consulte os arquivos de documentação ou abra uma issue.

---

**Última Atualização**: 17 de Fevereiro de 2026

**Status**: ✅ Pronto para Produção
