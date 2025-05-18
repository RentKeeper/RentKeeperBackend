# RentKeeper WebAPI

**RentKeeper** é uma API RESTful desenvolvida em .NET 6 (ou superior) para gerenciar o aluguel de jogadores de futebol em partidas. Toda a lógica está separada em camadas **Controllers**, **Services**, **Repositories**, **Data** (EF Core) e **Models** (Domínio), seguindo boas práticas de arquitetura.

---

## 🧩 Funcionalidades Principais

* **Usuário** (Jogador): cadastro, consulta, atualização e exclusão.
* **Anúncio**: criação de anúncios de jogadores com local, data e hora da partida.
* **Aluguel**: contrato de aluguel de um jogador baseado em um anúncio.
* **Pagamento**: registro de pagamento para cada aluguel, calculando retenção de 20% pela plataforma.
* **Time**: gerenciamento de times, adicionando jogadores.
* **Filtros e Paginação** em listagens.
* **Docker** (opcional): suporte a containerização.

---

## 🛠️ Tecnologias Utilizadas

* .NET 6+ (Web API)
* C#
* Entity Framework Core
* PostgreSQL (via Npgsql)
* AutoMapper
* Swagger / OpenAPI

---

## 🚀 Pré-requisitos

* [.NET SDK 6 ou superior](https://dotnet.microsoft.com/download)
* [PostgreSQL](https://www.postgresql.org/download/)
* [Git](https://git-scm.com/)
* (Opcional) [Docker e Docker Compose](https://www.docker.com/)

---

## 📥 Instalação e Configuração

1. **Clonar o repositório**

   ```bash
   git clone https://github.com/RentKeeper/RentKeeperBackend.git
   cd RentKeeperBackend
   ```

2. **Configurar `appsettings.json`**
   No arquivo `appsettings.json`, ajuste a *connection string*:

   ```jsonc
   {
     "ConnectionStrings": {
       "DefaultConnection": "Host=localhost;Port=5432;Database=rentkeeper;Username=SEU_USUARIO;Password=SUA_SENHA"
     },
     "AllowedHosts": "*"
   }
   ```

3. **Criar o banco (migrations)**

   ```bash
   dotnet ef migrations add InitialCreate
   dotnet ef database update
   ```

4. **Executar a API**

   ```bash
   dotnet run
   ```

   A API estará disponível em `https://localhost:5001` (ou porta configurada).

5. **Testar com Swagger UI**
   Abra no navegador: `https://localhost:5001/swagger` para explorar todos os endpoints.

---

## 🗂️ Estrutura do Projeto

```
RentKeeperBackend/
├── Controllers/           # Endpoints HTTP
├── Data/
│   ├── Context/           # DbContext EF Core
│   ├── Builders/          # Fluent API configurations
│   ├── Interfaces/        # Interfaces de Repositório
│   └── Repositories/      # Implementações de acesso a dados
├── Objects/
│   ├── Enums/             # Posicao, FormaPagamento
│   ├── Models/            # Entidades de domínio
│   ├── Dtos/              # DTOs de entrada/saída
│   └── Mappings/          # Perfis AutoMapper
├── Services/
│   ├── Interfaces/        # Interfaces de Serviço
│   └── Entities/          # Implementações de Serviço
├── Program.cs             # Configuração de DI e pipeline
├── appsettings.json       # Configurações de ambiente
├── RentKeeperBackend.csproj
└── README.md
```

---

## 🔧 Fluxo de Desenvolvimento

1. Criar/ajustar **Models** em `Objects/Models`.
2. Configurar **Builders** em `Data/Builders`.
3. Implementar **Repositories** e **Interfaces**.
4. Implementar **Services** e **Interfaces**.
5. Criar **DTOs** e **Perfis AutoMapper**.
6. Construir **Controllers**.
7. Registrar tudo em `Program.cs`.
8. **Migrations** e **Testes** com Swagger/Postman.

---

## ☸️ Docker (Opcional)

Crie um `docker-compose.yml` na raiz:

```yaml
version: '3.8'
services:
  db:
    image: postgres:14
    environment:
      POSTGRES_DB: rentkeeper
      POSTGRES_USER: seu_usuario
      POSTGRES_PASSWORD: sua_senha
    ports:
      - '5432:5432'
  api:
    build: .
    depends_on:
      - db
    environment:
      - ConnectionStrings__DefaultConnection=Host=db;Port=5432;Database=rentkeeper;Username=seu_usuario;Password=sua_senha
    ports:
      - '5001:80'
```

Suba com:

```bash
docker-compose up --build
```

---

