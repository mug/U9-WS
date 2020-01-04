DECLARE @Application BIGINT;
DECLARE @CreatedBy NVARCHAR(20);
DECLARE @ID BIGINT;

--设置应用的ID
SET @Application = 3000;
--设置创建名称
SET @CreatedBy = 'UFIDA';
--预置参数的初始ID(年月日时分秒+01纯数字)
SET @ID
    = CAST(CONVERT(VARCHAR(100), GETDATE(), 112) + REPLACE(CONVERT(VARCHAR(100), GETDATE(), 108), ':', '') + '01' AS BIGINT);
----为了可重复执行，创建前先删除
----删除参数(多语)表中关于本应用的数据
--DELETE FROM Base_Profile_Trl WHERE ID in (select ID from Base_Profile where [Application] = @Application )
----删除参数值表中关于本应用的数据(此参数值表区分多组织)
--DELETE FROM Base_ProfileValue WHERE profile in (SELECT ID FROM Base_Profile WHERE [Application] = @Application )
----删除参数表中关于本应用的数据(所有组织共用此参数表)
--DELETE FROM Base_Profile WHERE [Application] = @Application 
--进行参数预置
--ProfileValueType 参数值类型 (1int 2decimal 3bool 4date 6enum 7entity) 
--SubTypeName 子类型名称 当ProfileValueType=7时，此处填入实体名称，如UFIDA.U9.Base.Organization.Organization
--DefaultValue 缺省值，字串
--Code 编码，字串
--[Application]，所属应用
--ControlScope，作用范围(0站点1组织2角色3用户4实体角色)
--SensitiveType 敏感性类型(0厂商修改1设置后不可改2使用后不可改3可追朔修改4可前向修改)
--ReferenceID，参照ID，字串（未知）
--ProfileGroup,参数分组，字串

--1、Token超时时间(秒)
IF NOT EXISTS
(
    SELECT *
    FROM Base_Profile
    WHERE Code IN ( 'Cust_WS_TokenTimeout' )
)
BEGIN
    SET @ID = @ID + 1;
    INSERT INTO Base_Profile
    (
        ID,
        CreatedOn,
        CreatedBy,
        ModifiedOn,
        ModifiedBy,
        ProfileValueType,
        SubTypeName,
        DefaultValue,
        Code,
        [Application],
        ControlScope,
        SensitiveType,
        ReferenceID
    )
    VALUES
    (   @ID, GETDATE(), @CreatedBy, NULL, NULL, 1, --ProfileValueType 参数值类型 (1int 2decimal 3bool 4date 6enum 7entity) 
        NULL, '1200',                              --DefaultValue 缺省值，字串
        'Cust_WS_TokenTimeout', @Application, 0,   --ControlScope，作用范围(0站点1组织2角色3用户4实体角色)
        4,                                         --SensitiveType 敏感性类型(0厂商修改1设置后不可改2使用后不可改3可追朔修改4可前向修改)
        NULL);

    INSERT INTO Base_Profile_Trl
    (
        SysMLFlag,
        ID,
        [Description],
        [Name],
        ProfileGroup
    )
    VALUES
    ('zh-CN', @ID, 'Token超时时间(秒)', 'Token超时时间(秒)', '服务管理');
END;
