# Event+

## Descrição

O projeto "Mundo Comum" é um sistema web desenvolvido para a escola DevSchool, especializada em desenvolvimento de sistemas. , o sistema, tem como objetivo facilitar a gestão de eventos na escola, proporcionando uma plataforma para administradores e usuários comuns interagirem de forma eficiente.

## Funcionalidades do Sistema

### Perfis de Usuário

1. **Administrador:** Acesso à área administrativa da escola.
2. **Usuário Comum:** Pode ser espectador ou palestrante.

### Funcionalidades Principais

- O administrador pode cadastrar qualquer tipo de usuário.
- O administrador pode cadastrar diferentes tipos de eventos.
- Usuários autenticados podem visualizar todos os eventos cadastrados.
- Usuários comuns podem visualizar os eventos dos quais participarão.
- Usuários comuns podem se inscrever para assistir a um evento ou cancelar sua inscrição.

## Estrutura do Projeto

### Sprints do Desenvolvimento

#### SPRINT 1 – Banco de Dados

- Modelagem do banco de dados com base nas planilhas fornecidas pela DevSchool.
- Criação das tabelas necessárias para armazenar informações de eventos e usuários.

#### SPRINT 2 – Back-End (API)

- Desenvolvimento de uma API utilizando padrões modernos.
- Implementação de autenticação com JWT (JSON Web Token).
- Autorização de endpoints baseada nas funcionalidades do sistema.

#### SPRINT 3 – Front-End (Framework)

- Desenvolvimento da interface do usuário utilizando ReactJS.
- Integração com a API para interação dinâmica.

#### SPRINT 4 – Deploy

- Publicação do sistema em um servidor em nuvem, permitindo acesso remoto.

#### SPRINT 5 – Inteligência Artificial

- Implementação de uma funcionalidade de feedback dos usuários sobre os eventos.
- Utilização do **Content Moderator** da Microsoft Azure para moderação de comentários, garantindo que apenas feedbacks apropriados sejam disponibilizados.

## Tecnologias Utilizadas

- **Front-End:** ReactJS
- **Back-End:** API com C# (.NET)
- **Banco de Dados:** SQL Server
- **Autenticação:** JWT (JSON Web Token)
- **Inteligência Artificial:** Microsoft Azure Content Moderator

## Como Executar o Projeto

### Pré-requisitos

- .NET Core SDK
- Node.js
- SQL Server
