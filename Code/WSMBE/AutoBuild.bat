
echo reset IIS
echo iisreset

echo beging copy componet dll to portal and appserver

copy .\Entity\bin\Debug\UFIDA.U9.Cust.Pub.WSMBE.Deploy.dll  D:\yonyou\U9V60\Portal\ApplicationLib
copy .\Entity\bin\Debug\UFIDA.U9.Cust.Pub.WSMBE.Deploy.pdb  D:\yonyou\U9V60\Portal\ApplicationLib

copy .\Entity\bin\Debug\UFIDA.U9.Cust.Pub.WSMBE.dll  D:\yonyou\U9V60\Portal\ApplicationServer\Libs

copy .\Entity\bin\Debug\UFIDA.U9.Cust.Pub.WSMBE.pdb  D:\yonyou\U9V60\Portal\ApplicationServer\Libs

copy .\Entity\bin\Debug\UFIDA.U9.Cust.Pub.WSMBE.Deploy.dll  D:\yonyou\U9V60\Portal\ApplicationServer\Libs

copy .\Entity\bin\Debug\UFIDA.U9.Cust.Pub.WSMBE.Deploy.pdb  D:\yonyou\U9V60\Portal\ApplicationServer\Libs



echo begin run build component Script
echo DIR1: .\..\..\..\..\..\yonyou\UBFV60\U9.VOB.Product.Other\\Unconfiged\MetadataScript\
echo DIR2: .\..\..\..\..\..\yonyou\UBFV60\U9.VOB.Product.Other\\Unconfiged\DBScript\
echo .\..\..\..\..\..\yonyou\UBFV60\U9.VOB.Product.UBF\UBFStudio\Runtime\\..\DBScriptExecutor.exe -connStr "User Id=sa;Password=123654;Data Source=localhost;Initial Catalog=JHF20180227;packet size=4096;Max Pool size=100;Connection Timeout=900;persist security info=True;MultipleActiveResultSets=true;" -NotDropDB -NotWriteLog -ExecuteDelete ..\..\U9.VOB.Product.Other\Unconfiged\MetadataScript\ ..\..\U9.VOB.Product.Other\Unconfiged\DBScript\

echo componet  buid end
pause

