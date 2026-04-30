<h1 align="center">Roadmapp</h1>

<p align="center">
  Aplicação web para gerenciamento de estudos, tarefas e metas, com foco em produtividade, organização e escalabilidade.
</p>

<hr/>

<h2>Overview</h2>
<p>
O Roadmapp é uma aplicação em desenvolvimento com foco em organização de estudos e produtividade pessoal.
O projeto é estruturado com base em princípios de <strong>Domain-Driven Design (DDD)</strong>, priorizando separação de responsabilidades,
manutenibilidade e evolução contínua.
</p>

<h2>Current Features</h2>
<ul>
  <li>Gerenciamento de tarefas com agenda integrada</li>
  <li>Quadros estilo Kanban</li>
  <li>Sistema de flashcards para revisão</li>
  <li>Envio de e-mails com templates pré-definidos</li>
  <li>Registro de logs de operação</li>
  <li>Autenticação e autorização via JWT</li>
</ul>

<h2>Tech Stack</h2>
<ul>
  <li><strong>Backend:</strong> C# / .NET 8.0</li>
  <li><strong>Framework:</strong> ASP.NET</li>
  <li><strong>ORM:</strong> Entity Framework Core</li>
  <li><strong>Database:</strong> SQLite</li>
  <li><strong>Authentication:</strong> JWT Bearer</li>
</ul>

<h2>Architecture</h2>
<p>
A aplicação segue uma abordagem baseada em <strong>DDD (Domain-Driven Design)</strong>, organizada em camadas bem definidas:
</p>

<h3>Domain Layer</h3>
<ul>
  <li>Entidades de negócio</li>
  <li>Value Objects</li>
  <li>Interfaces de repositório</li>
  <li>Regras de negócio centrais</li>
</ul>

<h3>Application Layer</h3>
<ul>
  <li>Serviços de aplicação</li>
  <li>DTOs (Data Transfer Objects)</li>
  <li>Validações com FluentValidation</li>
  <li>Orquestração dos casos de uso</li>
</ul>

<h3>Infrastructure Layer</h3>
<ul>
  <li>Implementação de repositórios</li>
  <li>Configuração do Entity Framework Core</li>
  <li>Persistência com SQLite</li>
  <li>Serviços externos (ex: envio de e-mail)</li>
</ul>

<h3>Presentation Layer</h3>
<ul>
  <li>Controllers (API / MVC)</li>
  <li>Endpoints HTTP</li>
  <li>Autenticação e autorização</li>
</ul>

<h2>NuGet Packages</h2>
<ul>
  <li>BCrypt.Net-Next</li>
  <li>FluentValidation</li>
  <li>Microsoft.EntityFrameworkCore.Tools</li>
  <li>Microsoft.EntityFrameworkCore.Sqlite</li>
  <li>Microsoft.AspNetCore.Authentication.JwtBearer</li>
</ul>

<p>
<strong>Note:</strong> Utilizar <code>Swashbuckle.AspNetCore</code> na versão <strong>6.5.0</strong> para compatibilidade com Swagger/OpenAPI.
</p>

<h2>Security</h2>
<ul>
  <li>Autenticação baseada em JWT</li>
  <li>Hash de senhas com BCrypt</li>
  <li>Proteção de rotas via Authorization</li>
</ul>

<h2>Project Goals</h2>
<ul>
  <li>Evoluir para uma aplicação completa de produtividade</li>
  <li>Aplicar padrões avançados (Clean Architecture, DDD estratégico)</li>
  <li>Garantir escalabilidade e baixo acoplamento</li>
</ul>

<h2>Contributing</h2>
<p>
Este projeto é open-source. Contribuições são bem-vindas através de issues e pull requests.
</p>

<hr/>

<p align="center">
  Projeto desenvolvido com foco em boas práticas de arquitetura, código limpo e evolução contínua.
</p>