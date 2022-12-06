dotnet test --collect:"XPlat Code Coverage" --settings coverlet.runsettings
reportgenerator "-reports:*/TestResults/*/*cobertura.xml" "-targetdir:TestResults" "-reporttypes:Html;HtmlChart" "-historydir:TestResults"
open -a "Google Chrome" "TestResults/index.html"