
# DAS Capture The Flag
Capture the Flag Game is a .NET Core 3.1 web application.  It is a multi-player browser game.
Once two user's have connected and selected start the game will begin.

The repository can be found here: https://github.com/SkillsFundingAgency/das-apprentice-learning

## Prerequisites
1.   Visual Studio 2019
2.   If not already on your machine you'll need to download .NET Core 3.1. You can find this here:  https://dotnet.microsoft.com/download
3.   The web application will need to be run on a browser (IE, Chrome, Firefox)

## Setup
1.   Clone the project and open the solution in Visual Studio 2019.
2.   The web app is set by dafult to run at https://localhost:44353/
3.   Authentication uses the Entity Framework of ASP.NET Core Identity. You will need to Register an account to access the game.
     Currently there is no email confirmation functionality so click the link to confirm your account.
4.   Database: to setup and update the database tables open the Package Manager Console and use PMC commands:
        
        Add-Migration <migration name>
        Update-Database
        
     For more PMC commands see https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/powershell

## Tests


## Deployment


## Built With
1.   Framework .NET Core 3.1 
2.   Architecture MVC 

## Code Owners
Please read the [CODEOWNER](https://github.com/SkillsFundingAgency/das-apprentice-learning/blob/master/CODEOWNERS) file for 
details on our code owners and the process for submitting pull requests to us.

## Versioning


## Authors
- [ben1stone](https://github.com/ben1stone)
- [MarieDale3](https://github.com/MarieDale3)
- [DannyGB](https://github.com/DannyGB)

## License
This project is licensed under the MIT License - see the [LICENSE](https://github.com/SkillsFundingAgency/das-apprentice-learning/blob/master/LICENSE) file for details

## Acknowledgments

## SonarCloud Analysis

SonarCloud analysis can be performed using a docker container which can be built from the included dockerfile.

    Docker must be running Windows containers in this instance

An example of the docker run command to analyse the code base can be found below. 

For this docker container to be successfully created you will need:
* docker running Windows containers
* a user on SonarCloud.io with permission to run analysis
* a SonarQube.Analysis.xml file in the root of the git repository.

This file takes the format:

```xml
<SonarQubeAnalysisProperties  xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns="http://www.sonarsource.com/msbuild/integration/2015/1">
<Property Name="sonar.host.url">https://sonarcloud.io</Property>
<Property Name="sonar.login">[Your SonarCloud user token]</Property>
</SonarQubeAnalysisProperties>
```     

### Example:

_docker run [OPTIONS] IMAGE COMMAND_

[Docker run documentation](https://docs.docker.com/engine/reference/commandline/run/)

```docker run --rm -v c:/projects/das-apprentice-learning:c:/projects/das-apprentice-learning -w c:/projects/das-apprentice-learning 3d9151a444b2 powershell -F c:/projects/das-apprentice-learning/sonarcloud/analyse.ps1```

#### Options:

|Option|Description|
|---|---|
|--rm| Remove any existing containers for this image
|-v| Bind the current directory of the host to the given directory in the container ($PWD may be different on your platform). This should be the folder where the code to be analysed is
|-w| Set the working directory

#### Command:

Execute the analyse.ps1 PowerShell script	

### SonarLinter Extension

The SonarLinter extension for VisualStudio should be installed and linked to the SonarCloud.io project to enable in IDE code analysis that uses the same ruleset as the manual analysis performed by the above Docker instance