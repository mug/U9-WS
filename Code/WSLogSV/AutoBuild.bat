
copy .\BpImplement\bin\Debug\UFIDA.U9.Cust.Pub.WSLogSV.Deploy.dll  D:\yonyou\U9V60\Portal\ApplicationLib
copy .\BpImplement\bin\Debug\UFIDA.U9.Cust.Pub.WSLogSV.Deploy.pdb  D:\yonyou\U9V60\Portal\ApplicationLib
copy .\BpAgent\bin\Debug\UFIDA.U9.Cust.Pub.WSLogSV.Agent.dll  D:\yonyou\U9V60\Portal\ApplicationLib
copy .\BpAgent\bin\Debug\UFIDA.U9.Cust.Pub.WSLogSV.Agent.pdb  D:\yonyou\U9V60\Portal\ApplicationLib

copy .\BpImplement\bin\Debug\UFIDA.U9.Cust.Pub.WSLogSV.Deploy.dll  D:\yonyou\U9V60\Portal\ApplicationServer\Libs
copy .\BpImplement\bin\Debug\UFIDA.U9.Cust.Pub.WSLogSV.Deploy.pdb  D:\yonyou\U9V60\Portal\ApplicationServer\Libs
copy .\BpAgent\bin\Debug\UFIDA.U9.Cust.Pub.WSLogSV.Agent.dll  D:\yonyou\U9V60\Portal\ApplicationServer\Libs
copy .\BpAgent\bin\Debug\UFIDA.U9.Cust.Pub.WSLogSV.Agent.pdb  D:\yonyou\U9V60\Portal\ApplicationServer\Libs
copy .\BpImplement\bin\Debug\UFIDA.U9.Cust.Pub.WSLogSV.dll  D:\yonyou\U9V60\Portal\ApplicationServer\Libs
copy .\BpImplement\bin\Debug\UFIDA.U9.Cust.Pub.WSLogSV.pdb  D:\yonyou\U9V60\Portal\ApplicationServer\Libs
copy .\BpImplement\bin\Debug\UFIDA.U9.Cust.Pub.WSLogSV.ubfsvc  D:\yonyou\U9V60\Portal\ApplicationServer\Libs


copy .\BpImplement\UFIDA.U9.Cust.Pub.WSLogSV.ICreateWSLogSV.svc  D:\yonyou\U9V60\Portal\Services

echo 请手工将该bat文件打开，将下面这段内容与D:\yonyou\U9V60\Portal\RestServices\web.config进行合并。
	<service name="{type.FullName}Stub"  behaviorConfiguration="U9SrvTypeBehaviors">
		<endpoint address="" behaviorConfiguration="U9RestSrvBehaviors" binding="basicHttpBinding" contract="{type.Namespace.FullName}.ICreateWSLogSV" /> 
	</service>


pause