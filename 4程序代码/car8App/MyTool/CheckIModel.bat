@echo off
setlocal
set curDisk=%~d0
set curPath=%~dp0

%curDisk%
cd %curPath%
@echo �����̳�IModel�ӿڵ����Ƿ���ȷ��

bin\debug\MyTool -CheckIModel  -dlls "..\MyWeb\bin\PmEnt.dll" "..\MyWeb\bin\PmBiz.dll" "..\MyWeb\bin\MyWeb.dll"

endlocal
pause;