
echo reset IIS
echo iisreset

echo beging copy UI dll to portal

copy .\bin\Debug\UFIDA.U9.Cust.Pub.WSLogUI.WebPart.dll  D:\yonyou\U9V60\Portal\UILib
copy .\bin\Debug\UFIDA.U9.Cust.Pub.WSLogUI.WebPart.pdb  D:\yonyou\U9V60\Portal\UILib

echo begin run build UI Script
echo 目录：.\..\..\..\..\..\yonyou\UBFV60\U9.VOB.Product.Other\\u_ui\UIScript\

echo .\..\..\..\..\..\yonyou\UBFV60\U9.VOB.Product.UBF\UBFStudio\Runtime\\..\DBScriptExecutor.exe -connStr "User Id=sa;Password=123654;Data Source=localhost;Initial Catalog=JHF20180227;packet size=4096;Max Pool size=100;Connection Timeout=900;persist security info=True;MultipleActiveResultSets=true;" -NotDropDB -NotWriteLog -ExecuteDelete ..\..\U9.VOB.Product.Other\u_ui\UIScript\

echo ui buid end
pause

