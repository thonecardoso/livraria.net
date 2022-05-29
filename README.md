# livraria.net
Web api REST desenvolvida com as tecnologias **Microsoft .Net 5** com a linguagem de programação **C# - Csharp** para o controle de cadastro de Autores, Editoras, Livros e Usuários de uma livraria, possuindo CRUD completo para as entidades citadas.

O projeto Livraria.net tem o objetivo de disponibilizar uma Web API para cadastro dos livros de uma livraria através de uma API REST.

O projeto foi desenvolvido para um desafio técnico em um processo seletivo de uma vaga em dotnet para demonstrar habilidades citadas em entrevista.

## 🛠 Tecnologias

<hr>
![Linkedin Badge](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![Linkedin Badge](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![Linkedin Badge](https://img.shields.io/badge/Visual_Studio-5C2D91?style=for-the-badge&logo=visual%20studio&logoColor=white)
![Linkedin Badge](https://img.shields.io/badge/Swagger-85EA2D?style=for-the-badge&logo=Swagger&logoColor=white)
![Linkedin Badge](https://img.shields.io/badge/Docker-2CA5E0?style=for-the-badge&logo=docker&logoColor=white)
![Linkedin Badge](https://img.shields.io/badge/MongoDB-4EA94B?style=for-the-badge&logo=mongodb&logoColor=white)
![Linkedin Badge](https://img.shields.io/badge/Microsoft_SQL_Server-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white)
![Linkedin Badge](https://img.shields.io/badge/xUnity-100000?style=for-the-badge&logo=unity&logoColor=white)
![Linkedin Badge](https://img.shields.io/badge/Git-F05032?style=for-the-badge&logo=git&logoColor=white)
![Linkedin Badge](https://img.shields.io/badge/GitHub-100000?style=for-the-badge&logo=github&logoColor=white)
<hr>

* JWT Token para autenticação das APIs;
* Automapper para mapeamento de Entidade para DTO e vice-versa;
* EntityFrameworkCore para mapeamento e persistência de dados no banco de dados;
* Swagger para documentação da Api
* Microsoft SQL Server para persistência dos dados
* MongoDb para persistência dos logs
* Docker e Docker-compose para criação e orquestração de contêineres

## Como Começar

Para começar com o projeto basta você possuir em sua máquina o Docker instalado e um navegador web ou ferramenta de chamadas Rest externa, como o Insomnia.

#### Pré-requisitos

Clonar o repositório:

```bash
git clone https://github.com/thonecardoso/livraria.net.git
```

Para executar todo o ecossistema do projeto é necessário utilizar o Docker-compose usando o seguindo comando na pasta raiz do projeto:

```bash
docker-compose up
```
No Docker Desktop podemos visualizar os contêineres que foram criados com o comando acima:
* mssql - Sql Server
* mongodb - Mongo Database
* livraria.net.api_1 - Nossa aplicação rodando em um contêiner Docker

![Tela Swagger](./IMG/docker.png)

## Como usar
Para utilizar e testar o projeto acesse os endereços abaixo: 
```bash
http://localhost:58150 
```
Agora você será redirecionado para a página de OpenApi do Swagger onde poderá testar os endpoint, também pode utilizar outras ferramentas para isso.

## Documentação com Swagger

A Api foi documentada com o Swagger que é uma ferramenta open-source que permite executar testes e ver detalhes dos endpoints implementados. 

Na imagem abaixo pode-se ver os endpoints de cadastro, leitura, atualização e exclusão de livros.


![Tela Swagger](./IMG/crud_books.png)

### Exemplo de resposta

Resposta da requisição ordenada pelo nome dos livros do endpoint abaixo

![Tela Swagger](./IMG/get_books.png)

```bash
curl -X GET "https://localhost:58150/api/v1/books?sortByName=true" -H  "accept: */*"
```
As respostas da Api foram normalizadas para seguir um padrão, com:
* Código de status
* Status
* Dados de resposta
* Erro
```json
{
  "statusCode": 200,
  "success": true,
  "data": [
    {
      "id": 7,
      "name": "A dança da morte",
      "isbn": "978-8581050546",
      "pages": 1248,
      "chapters": 12,
      "publisherId": 3,
      "authorId": 1
    },
    {
      "id": 6,
      "name": "A estrada da noite",
      "isbn": "978-8599296134",
      "pages": 256,
      "chapters": 12,
      "publisherId": 1,
      "authorId": 2
    },
    {
      "id": 10,
      "name": "Anjos e demônios",
      "isbn": "978-9722520508",
      "pages": 480,
      "chapters": 12,
      "publisherId": 1,
      "authorId": 3
    },
    {
      "id": 9,
      "name": "Doutor sono",
      "isbn": "978-8581052434",
      "pages": 480,
      "chapters": 12,
      "publisherId": 3,
      "authorId": 1
    },
    {
      "id": 4,
      "name": "Mestre das chamas",
      "isbn": "978-8580417135",
      "pages": 592,
      "chapters": 12,
      "publisherId": 1,
      "authorId": 2
    }
  ],
  "errors": null
}
```

## Autenticação com token JWT
Todos os endpoints criticos de criação, alteração e exclusão foram protegidos com autenticação através de Bearer token que pode ser obtino no endipoint abaixo.

![Tela Swagger](./IMG/autentication.png)

```bash
curl -X POST "https://localhost:58150/api/v1/users/authenticate" -H  "accept: */*" -H  "Content-Type: application/json-patch+json" -d "{\"Username\":\"IsabelaBatista\",\"Password\":\"42119ca2398640f1a0322652cd91876f\"}"
```

```json
{
  "statusCode": 200,
  "success": true,
  "data": {
    "jwt": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiIxIiwidW5pcXVlX25hbWUiOiJJc2FiZWxhIEJhdGlzdGEiLCJlbWFpbCI6ImlzYWJlbGFiYXRpc3RhQGxpdnJhcmlhLm5ldCIsIm5iZiI6MTY1Mzg0NzIyNiwiZXhwIjoxNjU2NDM5MjI2LCJpYXQiOjE2NTM4NDcyMjZ9.fTgOxsQfYlbKqF0AFy96bnUmlBODEtqTRTXGmGxdVT0"
  },
  "errors": null
}
```
O Swagger permite inserir o token para testar os endpoints que exigem autenticação bastando colocar o a palavra "Bearer" um espaço " " e o token obtido anteriormente.

![Tela Swagger](./IMG/bearer.png)

A janela de autenticação aparece ao clicar no botão circulado de vermelho que está no canto superior direito da tela do Swagger.

## Logs

Todos os eventos críticos geram logs que são persistidos no MongoDb, através da interface podemos ver as mensagens salvas.

![Tela Swagger](./IMG/mongo.png)

## Testes de Unidade

Foram realizados testes automatizados de unidade para validação das DTO's que utilizaram Data Anotations.

![Tela Swagger](./IMG/dto.png)

![Tela Swagger](./IMG/testes.png)

## TODO

Para a aplicação ficar legal ainda necessita realizar algumas implementações tais como:
* Aumentar a cobertura de testes de unidade em toda a aplicação
* Implementar testes de Integração
* Validar as entidades com Fluent Validation
* Criação de um Front-end
* Persistência de imagens das capas dos livros
* Melhorar o mecanismo de busca para filtrar por nome, autor, etc.


## Problemas encontrados durante a implementação

Foi tentado usar mensageiria para enviar os dados dos logs para uma aplicação separada que estaria escutando uma fila no RabbitMq, porém ocorreu alguns problemas que estavam consumindo muito tempo então desisti e realizei a implementação dos logs diretamente pela api.  
Ocorreu um problema com o retorno da api, a asencia de um "await" em um serviço assíncrono estava retornando uma task não concluída para o NewtonSoft que não conseguia realizar a serialização, a mensagem de erro apontava para uma self referência que dificultou encontrar a falha.  
A gestão do tempo também foi um fator importante, com as demandas da rotina dedicar se mostrou-se complicado nessas últimas semanas.