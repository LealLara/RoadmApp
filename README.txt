<h1 align="center">RoadmApp</h1>

<p align="center">
Aplicação web para gerenciamento de estudos, tarefas e metas, com foco em produtividade, organização e escalabilidade.
</p>

---

## Overview

O **RoadmApp** é uma aplicação desenvolvida com foco em boas práticas de arquitetura e organização de código, permitindo ao usuário gerenciar sua rotina de estudos de forma estruturada.

O projeto segue princípios de **Domain-Driven Design (DDD)**, priorizando separação de responsabilidades, baixo acoplamento e alta manutenibilidade, com evolução contínua para uma arquitetura mais robusta.

---

## Current Features

- Gerenciamento de tarefas com agenda integrada  
- Quadros estilo Kanban para organização de atividades  
- Sistema de flashcards para revisão de conteúdo  
- Envio de e-mails com templates pré-definidos  
- Registro de logs de operação  
- Autenticação e autorização via JWT  

---

## Tech Stack

- **Backend:** C# / .NET 8.0  
- **Framework:** ASP.NET MVC  
- **ORM:** Entity Framework Core  
- **Database:** SQLite  
- **Authentication:** JWT Bearer  

---

## Project Structure
Roadmapp.sln

src/
├── RoadmApp.Api/
│ ├── Controllers/
│ ├── DTOs/
│ ├── Models/
│ └── Configurations/
│
├── RoadmApp.Domain/
│ ├── Entities/
│ ├── Interfaces/
│ │ ├── IRepositories/
│ │ └── IServices/
│ ├── Services/
│ ├── Enums/
│ ├── Constants/
│ └── Validations/
│
├── RoadmApp.Infrastructure/
│ ├── Data/
│ │ └── AppDbContext.cs
│ └── Repositories/
│
├── RoadmApp.CrossCutting/
│ └── Security/
│ └── TokenRepository.cs


---

## Architecture

A aplicação segue uma abordagem baseada em **DDD (Domain-Driven Design)**, organizada da seguinte forma:

### Domain
- Entidades de negócio  
- Interfaces de repositório e serviços  
- Regras de negócio  
- Validações e enums  

### Infrastructure
- Implementação de repositórios  
- Configuração do Entity Framework Core  
- Persistência com SQLite  

### Presentation (API)
- Controllers  
- DTOs  
- Entrada e saída de requisições HTTP  

### CrossCutting
- Autenticação JWT  
- Configurações de segurança  

---

## Application Layer (Current State)

A camada de aplicação ainda não está isolada como um projeto separado.

Atualmente, suas responsabilidades estão distribuídas entre:

- Controllers (orquestração inicial)
- DTOs (transferência de dados)
- Services no Domain (regras + fluxo simplificado)

---

## Request Flow


HTTP Request
↓
Controller (API)
↓
Domain Service
↓
Repository Interface (Domain)
↓
Repository Implementation (Infrastructure)
↓
Database (SQLite via EF Core)


---

## NuGet Packages

- BCrypt.Net-Next (password hashing)  
- FluentValidation (input validation)  
- Microsoft.EntityFrameworkCore.Tools  
- Microsoft.EntityFrameworkCore.Sqlite  
- Microsoft.AspNetCore.Authentication.JwtBearer  

**Nota:** Utilizar `Swashbuckle.AspNetCore` na versão **6.5.0** para compatibilidade com Swagger/OpenAPI.

---

## Security

- Autenticação baseada em JWT  
- Hash de senhas com BCrypt  
- Proteção de rotas via Authorization  

---

## Production Readiness

| Item                    | Status        |
|-------------------------|--------------|
| Autenticação JWT        | Implementado |
| Validação de dados      | Implementado |
| Logging                 | Implementado |
| Arquitetura em camadas  | Em evolução  |

---

## Architecture Evolution

A estrutura atual segue um modelo DDD simplificado.

Evoluções planejadas:

- Isolar a camada **Application** em projeto próprio  
- Implementar padrão **UseCase (Command/Query)**  
- Reduzir responsabilidades dos Controllers  
- Melhorar separação entre regras de negócio e orquestração  

---

## Technical Roadmap

### Curto prazo
- Implementar testes unitários (Domain)  
- Melhorar tratamento global de exceções  
- Padronizar respostas da API  
- Finalizar documentação Swagger  

### Médio prazo
- Criar camada Application separada  
- Implementar testes de integração  
- Introduzir CQRS  
- Melhorar logging  

### Longo prazo
- Migrar para PostgreSQL  
- Implementar mensageria (RabbitMQ)  
- Adicionar autenticação externa (OAuth)  
- Deploy em ambiente cloud  

---

## Project Goals

- Evoluir para uma aplicação completa de produtividade  
- Aplicar Clean Architecture + DDD completo  
- Garantir escalabilidade e fácil manutenção  

---

## Contributing

Este projeto é open-source e aberto a contribuições.  
Sugestões, issues e pull requests são bem-vindos.

---

<p align="center">
Desenvolvido com foco em qualidade de código, boas práticas e evolução contínua.
</p>