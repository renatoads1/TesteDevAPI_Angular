# TesteDev

Este repositório contém uma aplicação backend em ASP.NET 8 (C#) e um frontend em Angular.

## Pré-requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [Node.js (recomendado LTS)](https://nodejs.org/)
- [Angular CLI](https://angular.io/cli) (`npm install -g @angular/cli`)

---

## Como executar o projeto C# (Backend)

1. Navegue até a pasta do projeto backend:
TesteDev.sln
2. Restaure os pacotes e execute a aplicação:
Abra um terminal na pasta do projeto e execute:
   ```bash
   dotnet restore
   dotnet run
   ```
3. A API estará disponível em `https://localhost:5001` ou `http://localhost:5000` (verifique o console).
Para testar a API, você pode usar ferramentas como Postman ou Insomnia, ou até mesmo o Swagger UI integrado (geralmente disponível em `https://localhost:5001/swagger`).

## Como executar o projeto Angular (Frontend)
1. Navegue até a pasta do projeto Angular:
cd \TesteDev\AngularProj
2. Instale as dependências:
Abra um terminal na pasta do projeto Angular e execute:
   ```bash
   npm install
   ```
3. Execute o servidor de desenvolvimento:
```bash
   ng serve
  ```
4. Acesse o frontend em [http://localhost:4200](http://localhost:4200).
Para compilar o projeto Angular para produção, execute:
   ```bash
   ng build --prod
   ```
## Observações
- Durante o desenvolvimento, o frontend Angular faz requisições para o backend ASP.NET usando CORS.
- Para produção, recomenda-se gerar o build do Angular (`ng build --prod`) e servir os arquivos estáticos pelo backend (copiando para a pasta `wwwroot`).

---

## Scripts úteis

- **Build do backend:**  
  `dotnet build`

- **Build do frontend:**  
  `ng build --prod`

---
