# TesteDev

Este reposit�rio cont�m uma aplica��o backend em ASP.NET 8 (C#) e um frontend em Angular.

## Pr�-requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [Node.js (recomendado LTS)](https://nodejs.org/)
- [Angular CLI](https://angular.io/cli) (`npm install -g @angular/cli`)

---

## Como executar o projeto C# (Backend)

1. Navegue at� a pasta do projeto backend:
TesteDev.sln
2. Restaure os pacotes e execute a aplica��o:
Abra um terminal na pasta do projeto e execute:
   ```bash
   dotnet restore
   dotnet run
   ```
3. A API estar� dispon�vel em `https://localhost:5001` ou `http://localhost:5000` (verifique o console).
Para testar a API, voc� pode usar ferramentas como Postman ou Insomnia, ou at� mesmo o Swagger UI integrado (geralmente dispon�vel em `https://localhost:5001/swagger`).

## Como executar o projeto Angular (Frontend)
1. Navegue at� a pasta do projeto Angular:
cd \TesteDev\AngularProj
2. Instale as depend�ncias:
Abra um terminal na pasta do projeto Angular e execute:
   ```bash
   npm install
   ```
3. Execute o servidor de desenvolvimento:
```bash
   ng serve
  ```
4. Acesse o frontend em [http://localhost:4200](http://localhost:4200).
Para compilar o projeto Angular para produ��o, execute:
   ```bash
   ng build --prod
   ```
## Observa��es
- Durante o desenvolvimento, o frontend Angular faz requisi��es para o backend ASP.NET usando CORS.
- Para produ��o, recomenda-se gerar o build do Angular (`ng build --prod`) e servir os arquivos est�ticos pelo backend (copiando para a pasta `wwwroot`).

---

## Scripts �teis

- **Build do backend:**  
  `dotnet build`

- **Build do frontend:**  
  `ng build --prod`

---
