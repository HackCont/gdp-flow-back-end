<h3 align="center">
   <a href="#"><img alt="Banner GDP Flow" title="GDP Flow" src="https://firebasestorage.googleapis.com/v0/b/uploads-58ebc.appspot.com/o/profile.png?alt=media&token=98e579a4-068c-484a-9852-b5282dd26c8e"/></a>
</h3>

<h1 align="center">👨‍💻 GDP Flow</h1>

<h3 align="center">
  Gestão de carreira simplificada, conquistas visíveis.
</h3>

<h4 align="center">
   Status: Concluído 🚀
</h4>

---

## 📋 Índice
- [Sobre](#-sobre)
- [Tecnologias utilizadas](#%EF%B8%8F-tecnologias-utilizadas)
- [Funcionalidades](#%EF%B8%8F-funcionalidades)
- [Estrutura do Banco de Dados](#%EF%B8%8F-estrutura-do-banco-de-dados)
- [Diagrama da aplicação](#-diagrama-da-aplicação)
- [Colaboradores](#-colaboradores)

---

## 💻 Sobre
GDP Flow é um projeto desenvolvido ao longo de 1 final de semana durante o hackathon da [ContCode Community](https://www.linkedin.com/company/contcode-community/posts/?feedView=all)
a aplicação é uma plataforma para gestão de carreira, projetada para integrar o Ciclo de Gestão por Desempenho (GDP), o Plano de Desenvolvimento Individual (PDI) e o plano de carreira dos colaboradores em uma única solução, ajudando empresas a centralizar e organizar o desenvolvimento de seus talentos, enquanto capacita os profissionais a acompanharem sua evolução e alcançarem seus objetivos de carreira.

Foi desenvolvido com o objetivo de:
- **Dar visibilidade às conquistas:** Garanta que projetos importantes e ações de impacto sejam reconhecidos pelos gestores.
- **Facilitar a gestão de performance:** Acompanhe ciclos de desempenho de forma estruturada.
- **Personalizar o desenvolvimento individual:** Planeje o PDI com ações claras e específicas.
- **Promover transparência e acessibilidade:** Colaboradores e gestores têm acesso a informações essenciais sobre o crescimento e as conquistas.

---

## 🛠️ Tecnologias utilizadas
  - **.NET 8**
  - **Entity Framework Core**
  - **Keycloak**
  - **PostgreSQL**
  - **FluentResults**
  - **Swagger**

---

### ⚙️ Funcionalidades
**Cadastro e Login**
  - Integração com **Keycloak** para autenticação segura.

**Painel de Usuário**
  - Visualize informações do perfil, histórico de ciclos GDP.
  - Crie e gerencie o Plano de Desenvolvimento Individual (PDI) interativo.
  - Crie e gerencie a sua linha do tempo com os momentos mais importantes do seu ano.

---

# 🗃️ Estrutura do Banco de Dados
O banco de dados foi projetado utilizando PostgreSQL, com tabelas e relacionamentos otimizados para suportar as funcionalidades da plataforma, incluindo:
  - **Usuários:** Informações pessoais e perfis de acesso.
  - **Habilidades:** Relacionamento entre usuários e suas habilidades técnicas.
  - **Momentos:** Registro de marcos importantes do ciclo GDP.
  - **PDI:** Dados dinâmicos para o plano de desenvolvimento individual.

<h1 align="#-diagrama-da-aplicação">
   <a href="#"><img alt="Diagrama banco de dados" title="Diagrama banco de dados" src="https://firebasestorage.googleapis.com/v0/b/uploads-58ebc.appspot.com/o/db-diagram.png?alt=media&token=90fd5496-5b50-45ca-965a-d9b1dfd51c5f"/></a>
</h1>

---

# 🧩 Diagrama da aplicação:

## Cadastro e login:
```mermaid
sequenceDiagram
    autonumber
    participant Client
    participant API
    participant Database
    participant Keycloak


    Note over Client: Registro
    Client->>API: POST /api/auth/register<br>{ email, firstName, lastName, password }
    API ->>Keycloak: Criar usuário keycloak
    Keycloak ->>API: Sucesso
    API->>Database: Criar usuário db
    Database-->>API: Sucesso
    API-->>Client: HTTP 201 Created

    Note over Client: Login
    Client->>API: POST /api/auth/login<br>{ email, password }
    API->>Keycloak: Verifica credenciais
    Keycloak-->>API: Autenticado
    API-->>Client: HTTP 200 OK + Token JWT
```

## Gerenciamento de Usuários:
```mermaid
sequenceDiagram
    autonumber
    participant Client
    participant API
    participant Database

    Note over Client: Atualizar dados do usuário
    Client->>API: PUT /api/users/{userId}<br>{ firstName, lastName, email, ... }
    API->>Database: Atualizar usuário
    Database-->>API: Sucesso
    API-->>Client: HTTP 200 OK

    autonumber
    Note over Client: Obter dados do usuário
    Client->>API: GET /api/users/{userId}
    API->>Database: Buscar dados do usuário
    Database-->>API: Retorna dados
    API-->>Client: HTTP 200 OK + usuário
```

## Criar linha do tempo com momentos:
```mermaid
sequenceDiagram
    autonumber
    participant Client
    participant API
    participant Database

    Note over Client: Criar momento
    Client->>API: POST /api/moment<br>{ title, description... }
    API->>Database: Criar momento
    Database-->>API: Sucesso
    API-->>Client: HTTP 201 Created

    Note over Client: Obter momentos por usuário
    Client->>API: GET /api/moment/{userId}
    API->>Database: Buscar momentos do usuário
    Database-->>API: Retorna lista de momentos
    API-->>Client: HTTP 200 OK + momentos
```

## Criar e gerenciar PDI:
```mermaid
sequenceDiagram
    autonumber
    participant Client
    participant API
    participant Database

    Note over Client: Criar PDI
    Client->>API: POST /api/pdi<br>{ startDoing, stopDoing, doMore, ... }
    API->>Database: Criar pdi
    Database-->>API: Sucesso
    API-->>Client: HTTP 201 Created

    Note over Client: Atualizar PDI
    Client->>API: PUT /api/pdi<br>{ startDoing, stopDoing, doMore, ... }
    API->>Database: Atualizar pdi
    Database-->>API: Sucesso
    API-->>Client: HTTP 200 OK

    Note over Client: Obter PDI por usuário
    Client->>API: GET /api/pdi/{userId}
    API->>Database: Buscar PDI do usuário
    Database-->>API: Retorna PDI
    API-->>Client: HTTP 200 OK + PDI
```

---

## 🔗 Links Úteis
- [Figma](https://www.figma.com/design/t85gM3lPYiil6qGyg3VE3Y/GDP-Flow?node-id=0-1&t=wRVPSYK6sbv3Dvp7-1)
- [Repositório Frontend](https://github.com/HackCont/gdp-flow-front-end)

---

## 🤝 Colaboradores

Este projeto foi desenvolvido com a colaboração de:

<table>
  <tr>
    <td align="center"><a href="https://www.linkedin.com/in/thau%C3%A3-engelmann-6aaa04219/"><img src="https://firebasestorage.googleapis.com/v0/b/uploads-58ebc.appspot.com/o/thaua.jpeg?alt=media&token=e44f6155-1d22-468c-83e0-ec59d88051a7" width="80px;" alt="Foto Thauã Engelmann"/><br /><sub><b>Thauã Engelmann</b></sub></a><br /></td>
   <td align="center"><a href="https://www.linkedin.com/in/rafaelmjardim/"><img src="https://firebasestorage.googleapis.com/v0/b/uploads-58ebc.appspot.com/o/rafael.jpeg?alt=media&token=45ec6c25-cae9-4443-a547-7d1b1c5de93c" width="80px;" alt="Foto Rafael Jardim"/><br /><sub><b>Rafael Jardim</b></sub></a><br /></td>
 <td align="center"><a href="https://www.linkedin.com/in/paulo-ricardo-magalhaes/"><img src="https://firebasestorage.googleapis.com/v0/b/uploads-58ebc.appspot.com/o/paulo.jpeg?alt=media&token=8658818a-1377-478a-884e-03efc40f2980" width="80px;" alt="Foto Paulo Ricardo"/><br /><sub><b>Paulo Ricardo</b></sub></a><br /></td>
     <td align="center"><a href="https://www.linkedin.com/in/jorge--lima/"><img src="https://firebasestorage.googleapis.com/v0/b/uploads-58ebc.appspot.com/o/castion.jpeg?alt=media&token=73e7ba04-0ded-4a54-b59f-60a23fc472f4" width="80px;" alt="Foto Jorge Lima"/><br /><sub><b>Jorge Lima</b></sub></a><br /></td>
  </tr>
</table>

</br>
<p align="right"><a href="#top"><img src="https://img.shields.io/static/v1?label&message=voltar+ao+topo&color=444444&style=flat&logo" alt="voltar ao topo" /></a></p>
