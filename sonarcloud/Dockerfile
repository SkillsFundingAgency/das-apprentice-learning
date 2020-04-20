
FROM mcr.microsoft.com/dotnet/framework/sdk

#FROM mcr.microsoft.com/dotnet/core/sdk:3.1

ENV DOTNET3_1_URL https://download.visualstudio.microsoft.com/download/pr/adeab8b1-1c44-41b2-b12a-156442f307e9/65ebf805366410c63edeb06e53959383/dotnet-sdk-3.1.201-win-x64.zip
RUN $client = New-Object System.Net.WebClient; \
    $client.DownloadFile("$env:DOTNET3_1_URL", \"\dotnet-sdk-3.1.201-win-x64.zip\"); \
    Expand-Archive dotnet-sdk-3.1.201-win-x64.zip; \
    powershell cp -Path "c:/dotnet-sdk-3.1.201-win-x64/sdk/3.1.201" -Destination "c:/Program`` Files/dotnet/sdk/3.1.201" -Recurse; \
    powershell cp -Path "c:/dotnet-sdk-3.1.201-win-x64/shared/Microsoft.AspNetCore.App/3.1.3" -Destination "c:/Program`` Files/dotnet/shared/Microsoft.AspNetCore.App/3.1.3" -Recurse; \
    powershell cp -Path "c:/dotnet-sdk-3.1.201-win-x64/shared/Microsoft.NETCore.App/3.1.3" -Destination "c:/Program`` Files/dotnet/shared/Microsoft.NETCore.App/3.1.3" -Recurse;   

# Download OpenJDK
ENV JAVA_URL https://download.java.net/java/GA/jdk13.0.2/d4173c853231432d94f001e99d882ca7/8/GPL/openjdk-13.0.2_windows-x64_bin.zip   
RUN $client = New-Object System.Net.WebClient; \
    $client.DownloadFile("$env:JAVA_URL", \"\openjdk-13.0.2_windows-x64_bin.zip\")

# Install Java
RUN Expand-Archive openjdk-13.0.2_windows-x64_bin.zip
RUN SetX /M PATH "\"\openjdk-13.0.2_windows-x64_bin\jdk-13.0.2\bin;$env:PATH\""
RUN SetX /M JAVA_HOME "\"\openjdk-13.0.2_windows-x64_bin\jdk-13.0.2\""

ENV SONARSCANNER_URL https://github.com/SonarSource/sonar-scanner-msbuild/releases/download/4.7.1.2311/sonar-scanner-msbuild-4.7.1.2311-net46.zip
RUN $client = New-Object System.Net.WebClient; \
    $client.DownloadFile("$env:SONARSCANNER_URL", \"\sonar-scanner-msbuild-4.7.1.2311-net46.zip\")

RUN Expand-Archive sonar-scanner-msbuild-4.7.1.2311-net46.zip
RUN SetX /M PATH "\"\sonar-scanner-msbuild-4.7.1.2311-net46;$env:PATH\""

# Copy SonarScanner settings to container
COPY SonarQube.Analysis.xml /sonar-scanner-msbuild-4.7.1.2311-net46/SonarQube.Analysis.xml