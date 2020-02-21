
echo reset IIS
echo iisreset

echo beging copy componet dll to portal and appserver

copy .\ProxyService.svc  D:\Works\Pub_U9\Tools\ProxyTool\ProxyTool\Portal\ws
copy .\DebugService.svc  D:\Works\Pub_U9\Tools\ProxyTool\ProxyTool\Portal\ws
copy .\Web-ProxyService.config  D:\Works\Pub_U9\Tools\ProxyTool\ProxyTool\Portal\ws\Web.config

copy .\bin\UFIDA.U9.Cust.Pub.WS.Base.dll  D:\Works\Pub_U9\Tools\ProxyTool\ProxyTool\Portal\bin
copy .\bin\UFIDA.U9.Cust.Pub.WS.Base.pdb  D:\Works\Pub_U9\Tools\ProxyTool\ProxyTool\Portal\bin

copy .\bin\UFIDA.U9.Cust.Pub.WS.Json.dll  D:\Works\Pub_U9\Tools\ProxyTool\ProxyTool\Portal\bin
copy .\bin\UFIDA.U9.Cust.Pub.WS.Json.pdb  D:\Works\Pub_U9\Tools\ProxyTool\ProxyTool\Portal\bin

copy .\bin\UFIDA.U9.Cust.Pub.WS.U9Context.dll  D:\Works\Pub_U9\Tools\ProxyTool\ProxyTool\Portal\bin
copy .\bin\UFIDA.U9.Cust.Pub.WS.U9Context.pdb  D:\Works\Pub_U9\Tools\ProxyTool\ProxyTool\Portal\bin

copy .\bin\UFIDA.U9.Cust.Pub.WS.ProxyService.dll  D:\Works\Pub_U9\Tools\ProxyTool\ProxyTool\Portal\bin
copy .\bin\UFIDA.U9.Cust.Pub.WS.ProxyService.pdb  D:\Works\Pub_U9\Tools\ProxyTool\ProxyTool\Portal\bin

copy .\bin\UFIDA.U9.Cust.Pub.WS.DebugService.dll  D:\Works\Pub_U9\Tools\ProxyTool\ProxyTool\Portal\bin
copy .\bin\UFIDA.U9.Cust.Pub.WS.DebugService.pdb  D:\Works\Pub_U9\Tools\ProxyTool\ProxyTool\Portal\bin

copy .\bin\0Harmony.dll  D:\Works\Pub_U9\Tools\ProxyTool\ProxyTool\Portal\bin
copy .\bin\0Harmony.pdb  D:\Works\Pub_U9\Tools\ProxyTool\ProxyTool\Portal\bin

pause

