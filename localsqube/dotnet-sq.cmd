dotnet sonarscanner begin /k:"GildedRoses" /d:sonar.scanner.scanAll=false /d:sonar.host.url="http://localhost:9000"  /d:sonar.token="sqp_8cc256ed897e13b33f0d7cfe8bf86b899a85e75f"
dotnet build
dotnet test
dotnet sonarscanner end /d:sonar.token="sqp_8cc256ed897e13b33f0d7cfe8bf86b899a85e75f"


dotnet sonarscanner begin /k:"GildedRoses" /d:sonar.scanner.scanAll=false /d:sonar.host.url="http://localhost:9000" 
dotnet build --no-incremental
dotnet-coverage collect "dotnet test" -f xml -o "coverage.xml"
dotnet sonarscanner end /d:sonar.token="sqp_8cc256ed897e13b33f0d7cfe8bf86b899a85e75f"