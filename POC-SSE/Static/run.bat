@echo off

echo. 
echo Necessario ter Node.js e dotnet 6 runtime instalados.
echo.

cd ..
dotnet build
start dotnet run

cd Static
start node server.js

echo Entre no endereço http://localhost:6001/index.html
