dotnet test --collect:"XPlat Code Coverage" --settings coverlet.runsettings
reportgenerator -reports:*\TestResults\*\*cobertura.xml -targetdir:TestResults -reporttypes:Html;HtmlChart -historydir:TestResults
start chrome TestResults\index.html