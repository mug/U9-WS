
copy .\BpImplement\bin\Debug\UFIDA.U9.Cust.Pub.WSM.WSMRSV.Deploy.dll  D:\yonyou\U9V60\Portal\ApplicationLib
copy .\BpImplement\bin\Debug\UFIDA.U9.Cust.Pub.WSM.WSMRSV.Deploy.pdb  D:\yonyou\U9V60\Portal\ApplicationLib
copy .\BpAgent\bin\Debug\UFIDA.U9.Cust.Pub.WSM.WSMRSV.Agent.dll  D:\yonyou\U9V60\Portal\ApplicationLib
copy .\BpAgent\bin\Debug\UFIDA.U9.Cust.Pub.WSM.WSMRSV.Agent.pdb  D:\yonyou\U9V60\Portal\ApplicationLib

copy .\BpImplement\bin\Debug\UFIDA.U9.Cust.Pub.WSM.WSMRSV.Deploy.dll  D:\yonyou\U9V60\Portal\ApplicationServer\Libs
copy .\BpImplement\bin\Debug\UFIDA.U9.Cust.Pub.WSM.WSMRSV.Deploy.pdb  D:\yonyou\U9V60\Portal\ApplicationServer\Libs
copy .\BpAgent\bin\Debug\UFIDA.U9.Cust.Pub.WSM.WSMRSV.Agent.dll  D:\yonyou\U9V60\Portal\ApplicationServer\Libs
copy .\BpAgent\bin\Debug\UFIDA.U9.Cust.Pub.WSM.WSMRSV.Agent.pdb  D:\yonyou\U9V60\Portal\ApplicationServer\Libs
copy .\BpImplement\bin\Debug\UFIDA.U9.Cust.Pub.WSM.WSMRSV.dll  D:\yonyou\U9V60\Portal\ApplicationServer\Libs
copy .\BpImplement\bin\Debug\UFIDA.U9.Cust.Pub.WSM.WSMRSV.pdb  D:\yonyou\U9V60\Portal\ApplicationServer\Libs
copy .\BpImplement\bin\Debug\UFIDA.U9.Cust.Pub.WSM.WSMRSV.ubfsvc  D:\yonyou\U9V60\Portal\ApplicationServer\Libs


copy .\BpImplement\UFIDA.U9.Cust.Pub.WSM.WSTokenSV.ISaveWSTokenSV.svc  D:\yonyou\U9V60\Portal\RestServices

copy .\BpImplement\UFIDA.U9.Cust.Pub.WSM.WSTokenSV.IUpdateWSTokenExpireSV.svc  D:\yonyou\U9V60\Portal\RestServices

copy .\BpImplement\UFIDA.U9.Cust.Pub.WSM.WSTokenSV.ICleanWSTokenSV.svc  D:\yonyou\U9V60\Portal\RestServices

copy .\BpImplement\UFIDA.U9.Cust.Pub.WSM.WSTokenSV.IWSTokenIsExpiredSV.svc  D:\yonyou\U9V60\Portal\RestServices

echo please edit web.config add next segement
	<service name="{type.FullName}Stub"  behaviorConfiguration="U9SrvTypeBehaviors">
		<endpoint address="" behaviorConfiguration="U9RestSrvBehaviors" binding="webHttpBinding" contract="{type.Namespace.FullName}.ISaveWSTokenSV" /> 
	</service>
	<service name="{type.FullName}Stub"  behaviorConfiguration="U9SrvTypeBehaviors">
		<endpoint address="" behaviorConfiguration="U9RestSrvBehaviors" binding="webHttpBinding" contract="{type.Namespace.FullName}.IUpdateWSTokenExpireSV" /> 
	</service>
	<service name="{type.FullName}Stub"  behaviorConfiguration="U9SrvTypeBehaviors">
		<endpoint address="" behaviorConfiguration="U9RestSrvBehaviors" binding="webHttpBinding" contract="{type.Namespace.FullName}.ICleanWSTokenSV" /> 
	</service>
	<service name="{type.FullName}Stub"  behaviorConfiguration="U9SrvTypeBehaviors">
		<endpoint address="" behaviorConfiguration="U9RestSrvBehaviors" binding="webHttpBinding" contract="{type.Namespace.FullName}.IWSTokenIsExpiredSV" /> 
	</service>


pause