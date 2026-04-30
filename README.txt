<h1 align="center">RoadmApp</h1>

<p align="center">
  Aplicação web para gerenciamento de estudos, tarefas e metas, com foco em produtividade e organização pessoal.
</p>

<hr/>

<h2>Overview</h2>
<p>
O Study Organizer App é uma aplicação desenvolvida com foco em boas práticas de arquitetura e organização de código,
permitindo ao usuário gerenciar sua rotina de estudos de forma estruturada. O projeto encontra-se em fase inicial,
com evolução contínua baseada em extensibilidade e manutenção.
</p>

<h2>Current Features</h2>
<ul>
  <li>Gerenciamento de tarefas com agenda integrada</li>
  <li>Quadros estilo Kanban para organização de atividades</li>
  <li>Sistema de flashcards para revisão de conteúdo</li>
  <li>Envio de e-mails com templates pré-definidos</li>
  <li>Registro de logs de operação</li>
  <li>Autenticação e autorização via JWT</li>
</ul>

<h2>Tech Stack</h2>
<ul>
  <li><strong>Backend:</strong> C# / .NET 8.0</li>
  <li><strong>Framework:</strong> ASP.NET MVC</li>
  <li><strong>ORM:</strong> Entity Framework Core</li>
  <li><strong>Database:</strong> SQLite</li>
  <li><strong>Authentication:</strong> JWT Bearer</li>
</ul>

<h2>NuGet Packages</h2>
<ul>
  <li>BCrypt.Net-Next (password hashing)</li>
  <li>FluentValidation (input validation)</li>
  <li>Microsoft.EntityFrameworkCore.Tools</li>
  <li>Microsoft.EntityFrameworkCore.Sqlite</li>
  <li>Microsoft.AspNetCore.Authentication.JwtBearer</li>
</ul>

<p>
<strong>Note:</strong> Utilize <code>Swashbuckle.AspNetCore</code> na versão <strong>6.5.0</strong> para compatibilidade com a documentação da API.
</p>

<h2>Architecture</h2>
<p>
A aplicação segue o padrão <strong>MVC (Model-View-Controller)</strong>, com separação clara de responsabilidades.
A camada de dados é gerenciada pelo <strong>Entity Framework Core</strong>, utilizando abordagem code-first.
</p>

<ul>
  <li>Controllers responsáveis pela orquestração das requisições</li>
  <li>Models representando entidades e regras de negócio</li>
  <li>Validações desacopladas com FluentValidation</li>
  <li>Persistência com EF Core e SQLite</li>
</ul>

<h2>Security</h2>
<ul>
  <li>Autenticação baseada em JWT</li>
  <li>Hash de senhas com BCrypt</li>
  <li>Proteção de rotas via Authorization</li>
</ul>

<h2>Project Goals</h2>
<ul>
  <li>Evoluir para uma aplicação completa de produtividade</li>
  <li>Aplicar boas práticas de arquitetura (Clean Architecture / DDD futuramente)</li>
  <li>Escalabilidade e fácil manutenção</li>
</ul>

<h2>Contributing</h2>
<p>
Este projeto é open-source e aberto a contribuições. Sugestões, issues e pull requests são bem-vindos.
</p>

<hr/>

<p align="center">
  Desenvolvido com foco em qualidade de código, boas práticas e evolução contínua.
</p>