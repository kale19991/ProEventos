### ProEventos - Curso da Udemy

# Seja Full-Stack com .NET Web API e Angular + EF Core

This is all of the files for our Course about Angular, WebAPI and More

The Summary is:

01. Introdução ao Curso
02. NET Core 5
03. EF Core 5 - Introdução
04. Angular - Introdução
05. Angular - Interpolação, Diretivas e Binding
06. .NET 5 - Múltiplas Camadas
07. Angular - Organizar, Rota, Alertas e Mais
08. Angular - Reactive Forms e Novo Layout
09. DTOs & Data Annotations
10. Angular - Registrando Evento
11. Angular e .NET - Eventos e Lotes
12. Upload de Imagens
13. Asp .NET Core Identity - Autenticar e Autorizar - (TOKEN - JWT)
14. Angular + .NET Core Identity + JWT
15. Paginação e Filtros
16. Palestrantes e Redes Sociais - Backend
17. Palestrantes e Redes Sociais - Frontend
18. Palestrantes e Eventos (2022)
19. Docker + MySQL (2022)  

If you want to see this link course, really in action [original site](https://www.programadamente.com).

## Basic Setup

1. [Install Node.js](https://nodejs.org/)
1. [Install .NET Core 5](https://dotnet.microsoft.com/download/)
2. Fork the [ProEventos](https://github.com/vsandrade/ProEventos/fork)
3. Clone the repo you just forked.

## User Settings

```
Comandos uteis

dotnet tool install --global dotnet-ef --version 5.0.0

dotnet ef migrations add init -p Back/src/ProEventos.Persistence/ -s Back/src/ProEventos.API/

dotnet ef database update -p Back/src/ProEventos.Persistence/ -s Back/src/ProEventos.API/

cd Front && npm install -- para usar json-server
cd Front/ProEventos-App && npm install && npm start
```