@echo off
rem �����Ƿ����ű�. �ѷ��������Ƶ� R:\ ��. 

set /p CONVERT= ȷ��R�̴��ڣ�����·����ȷ����һ���������� R:\MyWeb Ŀ¼�� 
xcopy /Y /E ..\MyWeb  R:\MyWeb\

rem ���R�̲����ڣ��򷢲��� D�̣����򷢲��� C��
R:
cd R:\MyWeb 

set /p CONVERT= ȷ��R�̴��ڣ�����·����ȷ���Ժ�ִ��ɾ���ļ��Ķ����� 


del Web.config
del /S /F /Q  Upload\*

del /S /F /Q *.txt
del /S /F /Q *.cs
del /S /F /Q Doc\*
del /S /F /Q obj\*
del /S /F /Q /A:ARH *.scc 
del /S /F /Q bin\*.pdb

move Res\My_Build  My_Build
del /S /F /Q Res\*
xcopy /Y /S My_Build\*  ..\MyWeb\*

pause;