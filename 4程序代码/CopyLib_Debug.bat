@echo off
echo  ����MyCmnMyOql(Debug) 
setlocal
set curDisk=%~d0
set curPath=%~dp0
set log=R:\log.txt

set /p = "1. ��ʼ���±��� MyCmn (Debug) ...      "�� <nul
c:
cd c:\Windows\Microsoft.NET\Framework\v4.0*
Msbuild %curPath%\Cne_MyOql4\Cne_MyCmn4.sln /t:Rebuild /p:Configuration=Debug /consoleloggerparameters:ErrorsOnly >>log.txt
echo ���!

set /p = "2. ��ʼ���±��� MyOql (Debug) ...      "�� <nul
cd c:\Windows\Microsoft.NET\Framework\v4.0*
Msbuild %curPath%\Cne_MyOql4\Cne_MyOql4.sln /t:Rebuild /p:Configuration=Debug /consoleloggerparameters:ErrorsOnly >>log.txt
echo ���!

%curDisk%
cd %curPath%

CopyLib.bat

endlocal
echo  ����MyCmnMyOql(Debug) ���!
pause;
