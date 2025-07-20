Если собираетесь запускать через докер - то нужно будет применить миграцию

1) Укажите в appsettings.json вместо database -> localhost,1432
2)Сбилдите и запустите контейнер (docker-compose build, docker-compose up) 
3)в терминале, в папке с АПИ напишите dotnet ef database update
4)остановите контейнер, верните в connectionString database, 1433
5)повторите 2 шаг
   после запуска перейдите на http://localhost:3000  
