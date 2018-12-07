# VoteIt
Vote It !

[Trello Kanban](https://trello.com/b/0vR0ujR0/voit-it)

docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=[?]' -e 'MSSQL_PID=Express' -p 1433:1433 -v D:\Docker\VoteItDB:/var/opt/mssql -d mcr.microsoft.com/mssql/server:latest

Scaffold-DbContext "Server=localhost;Database=VoteItDB;User ID=sa;Password=[?];" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models
-Tables FeedLike
-force

## Rference
[reddit](https://zh.wikipedia.org/wiki/Reddit)

[folder structure](https://stackoverflow.com/questions/446017/popular-folder-structure-for-build)

[dotnet folder structure](https://github.com/dotnet/project-system)

[Connection Strings](https://docs.microsoft.com/en-us/ef/core/miscellaneous/connection-strings)

[Secret Manager](https://docs.microsoft.com/zh-tw/aspnet/core/security/app-secrets?view=aspnetcore-2.2&tabs=windows)  
%APPDATA%\Microsoft\UserSecrets\<user_secrets_id>\secrets.json

[[ASP.NET Core] Identity - Part 1 使用 Google 登入](https://blog.kevinyang.net/2018/05/31/aspnet-core-identity/)

[svg icon](https://www.flaticon.com/)