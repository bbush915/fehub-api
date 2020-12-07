rmdir /s /q TestResults
dotnet test --collect:"XPlat Code Coverage"
reportgenerator -reports:TestResults\*\*.xml -targetdir:TestResults -reporttypes:Html
start chrome TestResults\index.html