# Banco.Atlantico

Está é uma aplicação prova de conceito, para o processo seletivo do instituto atlantico.


## Pré-requisitos

É preciso ter instalado o sdk do [.NET Core 3.1](https://dotnet.microsoft.com/download/dotnet/3.1).

Abrir o arquivo ..\Banco.Atlantico\Banco.Atlantico.API\Properties\launchSettings.json  e alterar o caminho da propriedade Development -> Connection_String -> AttachDbFileName
para o path de destino do arquivo BancoAtlantico.mdf.

## Build

Assumindo que você esteja no diretorio do projeto.

execute os comandos:

```bash
dotnet build
dotnet run --project ..\Banco.Atlantico\Banco.Atlantico.API
```

## Requirements 

[Node.js](https://nodejs.org/en/) is required.

