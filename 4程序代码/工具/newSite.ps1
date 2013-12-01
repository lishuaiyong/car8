$commId = read-host  "��������С����ID "
$server = read-host "���������ݿ�IP "

$filePath = -join("D:\Hyj\",$commId,"_Bbs")
$siteName = -join("Hyj_",$commId,"_Bbs")


if ( [System.Io.Directory]::Exists($filePath) )
{
	echo  "$filePath�ļ����Ѵ���,���飡" 
	return ;
}

if ( [System.Io.Directory]::Exists("D:\Hyj\Bbs_Ori") )
{
	echo "D:\Hyj\Bbs_Ori �ļ����Ѵ��ڣ����飡"
	return ;
}

#(New-Object System.IO.DirectoryInfo("D:\Hyj_Base\Bbs_Ori")).Delete($true)
Copy-Item D:\Hyj_Base\Bbs_Ori  -Recurse $filePath

cd iis:
$siteExists  = ( Get-ChildItem '.\Sites\Default Web Site' | Select-Object Name | Where-Object { $_.Name -eq  $siteName } ) -eq $null

if ( $siteExists -eq $false )
{
    echo  "Default Web Site �Ѵ��� Ӧ�ã� $siteName ! ������ָ�������������ԣ�"
    return ;
}



New-Item "IIS:\Sites\Default Web Site\$siteName" -physicalPath "$filePath" -type Application
Set-ItemProperty "IIS:\Sites\Default Web Site\$siteName" -name applicationPool -value bbs


echo "����վ��Ӧ��: $siteName ��ɣ�";
echo "";

$content = [System.IO.File]::ReadAllText((-join($filePath,"\bbsmax.config"))).Replace('$Server$',$server).Replace('$CommId$',$commId)
[System.IO.File]::WriteAllText((-join($filePath,"\bbsmax.config")) , $content ) ;