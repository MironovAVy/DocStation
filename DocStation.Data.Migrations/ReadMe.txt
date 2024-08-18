1) Добавляем в Data & DbContext новые сущности
2) Nuget Package Manager -> cd ../Docstation.Data
3) dotnet ed migrations add [MigrationName]
4) DocStation.Data.Migrations -> Start New Instance 
5) Проверить что (4) завершился без ошибок, в базе появились новые таблицы/поля