setlocal
set curDisk=%~d0
set curPath=%~dp0

%curDisk%
cd %curPath%

rem call ������ʾ.js
choice /C IN  /M "�Ƿ�ִ�г�ʼ��(���ص�һ�Σ����ߣ����ݿ�ṹ�����仯)[Yes] �� Y, �����г�ʼ��[No] �� N." 
if errorlevel 2 goto endTail



..\bin\debug\MyTool -MyOqlTableOfView  "MyOqlCodeGen_View_Table.xml"  -ViewXml "MyOqlCodeGen_My_View.config" -db dbo


..\bin\debug\MyTool -MyOqlTableOfProc  "MyOqlCodeGen_Proc_Table.xml" -db dbo -ProcXml "MyOqlCodeGen_Auto_Proc.init"
..\bin\debug\MyTool -MyOqlProcOfProc  "MyOqlCodeGen_Proc_Proc.xml" -ProcXml "MyOqlCodeGen_Auto_Proc.init" -db dbo
 
..\bin\debug\MyTool -ExtendXml "Join_Config_Auto.xml" -ListFiles "MyOqlCodeGen_Auto_Table.init" "MyOqlCodeGen_Auto_Table_Log.init" "MyOqlCodeGen_Auto_View.init" "MyOqlCodeGen_Auto_Proc.init" "MyOqlCodeGen_Auto_Func.init" "MyOqlCodeGen_Proc_Table.xml" "MyOqlCodeGen_Proc_Proc.xml" "MyOqlCodeGen_View_Table.xml"
..\bin\debug\MyTool -ExtendXml "Join_Config_My.xml" -ListFiles  "MyOqlCodeGen_My_Table.config" "MyOqlCodeGen_My_View.config" "MyOqlCodeGen_My_Proc.config" "MyOqlCodeGen_My_Func.config"
 
..\bin\debug\MyTool -ExtendMyOql "MyOqlCodeGen_Ext.xml" -AutoFile "Join_Config_Auto.xml" -MyFile "Join_Config_My.xml"
..\bin\debug\MyTool -MyOqlProc "..\MyOqlCodeGen.config" -ExtFile "MyOqlCodeGen_Ext.xml"


:endTail
copy /y ..\MyOqlCodeGen.config  ..\bin\debug\MyOqlCodeGen.config

endlocal
