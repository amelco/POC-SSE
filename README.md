# POC-SSE
Exemplo simples de *Server-Sent Event* com dotnet e javascript puro.

---
## Descrição
Uma prova de conceito (POC) para demostrar e testar o uso de (*Server-Sent Event*) SSE 
de uma API dotnet para uma página html com script em javascript puro (sem utilizar framework).

## Uso:
Clone o repositório e execute o arquivo **`run.bat`** que está dentro da pasta `Static`.
O script irá compilar a API em dotnet, executar um servidor Node.js que proverá a página `index.html`.

## Detalhes:
- A API está sendo executada em https://localhost:5001.
- O frontend (página `index.htm`") está sendo servido através do endereço http://localhost:6001.
- O backend só aceita conexões com seu serviço de SSE de origens conhecidas. 
O CORS foi setado para aceitar somente chamadas de `localhost`.
Isso demonstra a utilização de um tipo de *white list* no backend por segurança.
