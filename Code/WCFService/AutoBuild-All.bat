
echo reset IIS
echo iisreset

echo beging copy componet dll to portal and appserver

copy .\AuthTokenService.svc  D:\yonyou\U9V60\Portal\ws
copy .\CommService.svc  D:\yonyou\U9V60\Portal\ws
copy .\TestService.svc  D:\yonyou\U9V60\Portal\ws
copy .\Web-All.config  D:\yonyou\U9V60\Portal\ws\Web.config

copy .\bin\UFIDA.U9.Cust.Pub.WS.Base.dll  D:\yonyou\U9V60\Portal\bin
copy .\bin\UFIDA.U9.Cust.Pub.WS.Base.pdb  D:\yonyou\U9V60\Portal\bin

copy .\bin\UFIDA.U9.Cust.Pub.WS.Json.dll  D:\yonyou\U9V60\Portal\bin
copy .\bin\UFIDA.U9.Cust.Pub.WS.Json.pdb  D:\yonyou\U9V60\Portal\bin

copy .\bin\UFIDA.U9.Cust.Pub.WS.U9Context.dll  D:\yonyou\U9V60\Portal\bin
copy .\bin\UFIDA.U9.Cust.Pub.WS.U9Context.pdb  D:\yonyou\U9V60\Portal\bin

copy .\bin\UFIDA.U9.Cust.Pub.WS.Token.dll  D:\yonyou\U9V60\Portal\bin
copy .\bin\UFIDA.U9.Cust.Pub.WS.Token.pdb  D:\yonyou\U9V60\Portal\bin

copy .\bin\UFIDA.U9.Cust.Pub.WS.Token.DBProvider.dll  D:\yonyou\U9V60\Portal\bin
copy .\bin\UFIDA.U9.Cust.Pub.WS.Token.DBProvider.pdb  D:\yonyou\U9V60\Portal\bin

copy .\bin\UFIDA.U9.Cust.Pub.WS.Token.MemoryProvider.dll  D:\yonyou\U9V60\Portal\bin
copy .\bin\UFIDA.U9.Cust.Pub.WS.Token.MemoryProvider.pdb  D:\yonyou\U9V60\Portal\bin

copy .\bin\UFIDA.U9.Cust.Pub.WS.U9Action.dll  D:\yonyou\U9V60\Portal\bin
copy .\bin\UFIDA.U9.Cust.Pub.WS.U9Action.pdb  D:\yonyou\U9V60\Portal\bin

copy .\bin\UFIDA.U9.Cust.Pub.WS.U9Action.DBLog.dll  D:\yonyou\U9V60\Portal\bin
copy .\bin\UFIDA.U9.Cust.Pub.WS.U9Action.DBLog.pdb  D:\yonyou\U9V60\Portal\bin

copy .\bin\UFIDA.U9.Cust.Pub.WS.U9Action.Token.dll  D:\yonyou\U9V60\Portal\bin
copy .\bin\UFIDA.U9.Cust.Pub.WS.U9Action.Token.pdb  D:\yonyou\U9V60\Portal\bin

copy .\bin\UFIDA.U9.Cust.Pub.WS.CommService.dll  D:\yonyou\U9V60\Portal\bin
copy .\bin\UFIDA.U9.Cust.Pub.WS.CommService.pdb  D:\yonyou\U9V60\Portal\bin

copy .\bin\UFIDA.U9.Cust.Pub.WS.TestService.dll  D:\yonyou\U9V60\Portal\bin
copy .\bin\UFIDA.U9.Cust.Pub.WS.TestService.pdb  D:\yonyou\U9V60\Portal\bin


pause

