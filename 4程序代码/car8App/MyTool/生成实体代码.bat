@echo off
setlocal
set curDisk=%~d0
set curPath=%~dp0

%curDisk%
cd %curPath%

call MyOqlCodeGen\�ϲ�MyOqlCodeGen.bat

bin\debug\MyTool -CodeGen "..\DbEnt\Entity" -Log "R:\CodeGen.log" -Namespace DbEnt -CodeHeader MyOqlCodeGen\CodeHeader.txt

notepad "R:\CodeGen.log"

endlocal

call �������.js
pause;