@echo off
setlocal
set curDisk=%~d0
set curPath=%~dp0

%curDisk%
cd %curPath%

echo.
echo ---------------------------------------------------
echo �ڱ���Ĭ��վ���°�װ BBS Ӧ�ó���,��Ҫ���»�����
echo 1. ��Ϊ bbs ��Ӧ�ó����
echo 2. D:\Hyj_Base\Bbs_Ori �ļ���
echo 3. D:\Hyj\ �ļ���
echo ������վ��Ӧ�����ƹ淶��http://����ͷ/hyj_С��Id_bbs

echo ���ڼ��� powershell ����

echo.

powershell.exe  -ImportSystemModules -file newSite.ps1
endlocal
pause;
