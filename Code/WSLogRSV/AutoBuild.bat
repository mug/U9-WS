
copy .\BpImplement\bin\Debug\UFIDA.U9.Cust.Pub.WSLogRSV.Deploy.dll  D:\yonyou\U9V60\Portal\ApplicationLib
copy .\BpImplement\bin\Debug\UFIDA.U9.Cust.Pub.WSLogRSV.Deploy.pdb  D:\yonyou\U9V60\Portal\ApplicationLib
copy .\BpAgent\bin\Debug\UFIDA.U9.Cust.Pub.WSLogRSV.Agent.dll  D:\yonyou\U9V60\Portal\ApplicationLib
copy .\BpAgent\bin\Debug\UFIDA.U9.Cust.Pub.WSLogRSV.Agent.pdb  D:\yonyou\U9V60\Portal\ApplicationLib

copy .\BpImplement\bin\Debug\UFIDA.U9.Cust.Pub.WSLogRSV.Deploy.dll  D:\yonyou\U9V60\Portal\ApplicationServer\Libs
copy .\BpImplement\bin\Debug\UFIDA.U9.Cust.Pub.WSLogRSV.Deploy.pdb  D:\yonyou\U9V60\Portal\ApplicationServer\Libs
copy .\BpAgent\bin\Debug\UFIDA.U9.Cust.Pub.WSLogRSV.Agent.dll  D:\yonyou\U9V60\Portal\ApplicationServer\Libs
copy .\BpAgent\bin\Debug\UFIDA.U9.Cust.Pub.WSLogRSV.Agent.pdb  D:\yonyou\U9V60\Portal\ApplicationServer\Libs
copy .\BpImplement\bin\Debug\UFIDA.U9.Cust.Pub.WSLogRSV.dll  D:\yonyou\U9V60\Portal\ApplicationServer\Libs
copy .\BpImplement\bin\Debug\UFIDA.U9.Cust.Pub.WSLogRSV.pdb  D:\yonyou\U9V60\Portal\ApplicationServer\Libs
copy .\BpImplement\bin\Debug\UFIDA.U9.Cust.Pub.WSLogRSV.ubfsvc  D:\yonyou\U9V60\Portal\ApplicationServer\Libs


copy .\BpImplement\UFIDA.U9.Cust.Pub.WSLogRSV.ICreateBeforeCallWSLogSV.svc  D:\yonyou\U9V60\Portal\RestServices

copy .\BpImplement\UFIDA.U9.Cust.Pub.WSLogRSV.ICreateAfterCallWSLogSV.svc  D:\yonyou\U9V60\Portal\RestServices

copy .\BpImplement\UFIDA.U9.Cust.Pub.WSLogRSV.ICreateCallWSLogSV.svc  D:\yonyou\U9V60\Portal\RestServices

echo please edit web.config add next segement
	<service name="{type.FullName}Stub"  behaviorConfiguration="U9SrvTypeBehaviors">
		<endpoint address="" behaviorConfiguration="U9RestSrvBehaviors" binding="webHttpBinding" contract="{type.Namespace.FullName}.ICreateBeforeCallWSLogSV" /> 
	</service>
	<service name="{type.FullName}Stub"  behaviorConfiguration="U9SrvTypeBehaviors">
		<endpoint address="" behaviorConfiguration="U9RestSrvBehaviors" binding="webHttpBinding" contract="{type.Namespace.FullName}.ICreateAfterCallWSLogSV" /> 
	</service>
	<service name="{type.FullName}Stub"  behaviorConfiguration="U9SrvTypeBehaviors">
		<endpoint address="" behaviorConfiguration="U9RestSrvBehaviors" binding="webHttpBinding" contract="{type.Namespace.FullName}.ICreateCallWSLogSV" /> 
	</service>


pause