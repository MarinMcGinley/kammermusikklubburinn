Commands for running and shutting down docker container:
`docker compose up -d`
`docker compose down`

Please download this package: https://www.nuget.org/packages/dotnet-ef

Create a migration with dotnet ef:
`dotnet ef migrations add [NAME OF MIGRATION] -s API -p Infrastructure`

Update DB after creating new migration:
`dotnet ef database update -s API -p Infrastructure`

Start application:
`cd API`
`dotnet watch`
