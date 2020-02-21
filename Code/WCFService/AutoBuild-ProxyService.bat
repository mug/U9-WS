
echo reset IIS
echo iisreset

echo beging copy componet dll to portal and appserver

copy .\ProxyService.svc  D:\yonyou\U9V60\Portal\ws
copy .\DebugService.svc  D:\yonyou\U9V60\Portal\ws
copy .\Web-ProxyService.config  D:\yonyou\U9V60\Portal\ws\Web.config

copy .\bin\UFIDA.U9.Cust.Pub.WS.Base.dll  D:\yonyou\U9V60\Portal\bin
copy .\bin\UFIDA.U9.Cust.Pub.WS.Base.pdb  D:\yonyou\U9V60\Portal\bin

copy .\bin\UFIDA.U9.Cust.Pub.WS.Json.dll  D:\yonyou\U9V60\Portal\bin
copy .\bin\UFIDA.U9.Cust.Pub.WS.Json.pdb  D:\yonyou\U9V60\Portal\bin

copy .\bin\UFIDA.U9.Cust.Pub.WS.U9Context.dll  D:\yonyou\U9V60\Portal\bin
copy .\bin\UFIDA.U9.Cust.Pub.WS.U9Context.pdb  D:\yonyou\U9V60\Portal\bin

copy .\bin\UFIDA.U9.Cust.Pub.WS.ProxyService.dll  D:\yonyou\U9V60\Portal\bin
copy .\bin\UFIDA.U9.Cust.Pub.WS.ProxyService.pdb  D:\yonyou\U9V60\Portal\bin

copy .\bin\UFIDA.U9.Cust.Pub.WS.DebugService.dll  D:\yonyou\U9V60\Portal\bin
copy .\bin\UFIDA.U9.Cust.Pub.WS.DebugService.pdb  D:\yonyou\U9V60\Portal\bin

copy .\bin\0Harmony.dll  D:\yonyou\U9V60\Portal\bin
copy .\bin\0Harmony.pdb  D:\yonyou\U9V60\Portal\bin

pause

