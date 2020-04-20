
SonarScanner.MSBuild.exe begin /k:"SkillsFundingAgency_das-apprentice-learning" /o:"educationandskillsfundingagency"
Nuget Restore c:\projects\das-apprentice-learning\src\DAS-Capture-The-Flag.sln 
MSBuild.exe c:\projects\das-apprentice-learning\src\DAS-Capture-The-Flag.sln /t:Rebuild
SonarScanner.MSBuild.exe end