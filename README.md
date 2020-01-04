# U9-WS
yonyou u9 restful webservice

开发目的
    1.	简化外部系统对U9服务的调用。
    2.	增强U9服务的管理及维护功能。
功能介绍
    1.	融合于U9系统中，不需要独立站点部署,可根据需求配置所需的功能。    
    2.	采用Newtonsoft.Json替换默认的DataContractJsonSerializer的Json转换器，解决Json日期格式、循环引用等问题 
    3.	统一对调用中出现的异常的进行处理   
    4.	包含两种初始化U9上下文环境的方式:固定上下文、Token上下文 
    5.	包含两种记录服务的调用过程的日志方式：Log4Net日志、数据库日志    
    6.	包含获取Token认证及Token校验功能，包含两种存储Token的方式:内存存储、数据库存储
    7.	提供通用CommService服务调用方式，支持调用BP,SV,RestSV
