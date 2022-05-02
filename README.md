
# Codigo Penal - Cidade Alta !

## O que é possivel fazer:
- Autenticação de usuario na base de dados.
- Cadastrar novo Codigo Penal
- Editar Codigo Penal
- Deletar Codigo Penal
- Visualizar e Filtrar Codigo Penal

## Primeiros passos:

- Baixe e rode o arquivo [cda.sql] (Mysql)
- Configurar o arquivo [appsettings.json]
- Rodar a solução.

## Observação:
- Usuario para login: cda / cda

## Tecnologias:
- Asp.Net.Core
- Entity Framework Core
- Swagger
- JWT
- Mysql
- Alguns Designer Partner

# Config [appsettings.json]
Variavel | Tipo | Descrição
------------- | ------------- | -------------
JWT:Key | `String` | Key responsavel para geração do Token do JWT
JWT:ValidateIssuer | `String` | Emissor do token
JWT:ValidateAudience  |  `String` | Emissor publico
ConnectionStrings: ConnectionMysql |  `String` | String de conexão MYSQL

# Eventos
## Login
### api/CriminalApp/Login
Parametro | Tipo | Descrição
------------- | ------------- | -------------
userName | `String` | Usuario ao se autenticar no banco de dados
password | `String` | Senha do Usuario ao se autenticar no banco de dados


## CriminalCode
### api/CriminalApp/Create
Parametro | Tipo | Descrição
------------- | ------------- | -------------
name | `String` | Nome do Codigo Penal
description | `String` | Descrição do Codigo Penal
penalty | `decimal` | Penalty do Codigo Penal
prisonTime | `int` | Tempo de prisão do Codigo penal
statusId | `int` | StatusID { 1 = Ativo 2 = Inativo}
createDate | `DateTime` | Data da Criação
updateDate | `DateTime` | Data do Update
createUserId | `int` | ID recebido ao efetuar Login
updateUserId | `int` | ID recebido ao efetuar Login

### api/CriminalApp/Delete
Parametro | Tipo | Descrição
------------- | ------------- | -------------
id | `String` | ID do Codigo Penal

### api/CriminalApp/Edit/{id}
Parametro | Tipo | Descrição
------------- | ------------- | -------------
id | `String` | ID do Codigo Penal
name | `String` | Nome do Codigo Penal
description | `String` | Descrição do Codigo Penal
penalty | `decimal` | Penalty do Codigo Penal
prisonTime | `int` | Tempo de prisão do Codigo penal
statusId | `int` | StatusID { 1 = Ativo 2 = Inativo}
createDate | `DateTime` | Data da Criação
updateDate | `DateTime` | Data do Update
createUserId | `int` | ID recebido ao efetuar Login
updateUserId | `int` | ID recebido ao efetuar Login

### api/CriminalApp/{id}
Parametro | Tipo | Descrição
------------- | ------------- | -------------
id | `String` | ID do Codigo Penal

### api/CriminalApp
Parametro | Tipo | Descrição
------------- | ------------- | -------------
filter | `String` | Campo para filtrar codigo penal
by | `String` | Coluna que será filtrado
orderBy | `String` | Coluna para ordenação
way | `String` | Caminho da ordenação: asc / desc
page | `int` | Pagina da ordenação







