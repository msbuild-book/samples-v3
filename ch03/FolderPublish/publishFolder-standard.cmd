"%programfiles%\IIS\Microsoft Web Deploy v3\msdeploy.exe" ^
-verb:sync -source:contentPath="C:\InsideMSBuild\ch03\FolderPublish\ToPublish" ^
-dest:contentPath='FolderPub/Media',ComputerName="https://waws-prod-bay-001.publish.azurewebsites.windows.net/msdeploy.axd?site=FolderPub",^
UserName='$FolderPub',Password='%password%',AuthType='Basic' ^
-enableRule:DoNotDeleteRule  ^
-whatif