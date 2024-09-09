1) Добавляем в Data & DbContext новые сущности
2) Nuget Package Manager -> cd ../Docstation.Data
3) dotnet ef migrations add [MigrationName] через PM -  Add-Migration
4) DocStation.Data.Migrations -> Start New Instance 
5) Проверить что (4) завершился без ошибок, в базе появились новые таблицы/поля

Подключение к Докеру
docker pull mcr.microsoft.com/mssql/server:latest
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=STRONGPASSWORD" -p 1433:1433 --name sql_server_container mcr.microsoft.com/mssql/server:latest
Строка подключения:
"Server=127.0.0.1,1433;User=sa;Password=STRONGPASSWORD;Database=DocStation;Trusted_Connection=False;Encrypt=False;"