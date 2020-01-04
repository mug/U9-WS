DECLARE @Application BIGINT;
DECLARE @CreatedBy NVARCHAR(20);
DECLARE @ID BIGINT;

--����Ӧ�õ�ID
SET @Application = 3000;
--���ô�������
SET @CreatedBy = 'UFIDA';
--Ԥ�ò����ĳ�ʼID(������ʱ����+01������)
SET @ID
    = CAST(CONVERT(VARCHAR(100), GETDATE(), 112) + REPLACE(CONVERT(VARCHAR(100), GETDATE(), 108), ':', '') + '01' AS BIGINT);
----Ϊ�˿��ظ�ִ�У�����ǰ��ɾ��
----ɾ������(����)���й��ڱ�Ӧ�õ�����
--DELETE FROM Base_Profile_Trl WHERE ID in (select ID from Base_Profile where [Application] = @Application )
----ɾ������ֵ���й��ڱ�Ӧ�õ�����(�˲���ֵ�����ֶ���֯)
--DELETE FROM Base_ProfileValue WHERE profile in (SELECT ID FROM Base_Profile WHERE [Application] = @Application )
----ɾ���������й��ڱ�Ӧ�õ�����(������֯���ô˲�����)
--DELETE FROM Base_Profile WHERE [Application] = @Application 
--���в���Ԥ��
--ProfileValueType ����ֵ���� (1int 2decimal 3bool 4date 6enum 7entity) 
--SubTypeName ���������� ��ProfileValueType=7ʱ���˴�����ʵ�����ƣ���UFIDA.U9.Base.Organization.Organization
--DefaultValue ȱʡֵ���ִ�
--Code ���룬�ִ�
--[Application]������Ӧ��
--ControlScope�����÷�Χ(0վ��1��֯2��ɫ3�û�4ʵ���ɫ)
--SensitiveType ����������(0�����޸�1���ú󲻿ɸ�2ʹ�ú󲻿ɸ�3��׷˷�޸�4��ǰ���޸�)
--ReferenceID������ID���ִ���δ֪��
--ProfileGroup,�������飬�ִ�

--1��Token��ʱʱ��(��)
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
    (   @ID, GETDATE(), @CreatedBy, NULL, NULL, 1, --ProfileValueType ����ֵ���� (1int 2decimal 3bool 4date 6enum 7entity) 
        NULL, '1200',                              --DefaultValue ȱʡֵ���ִ�
        'Cust_WS_TokenTimeout', @Application, 0,   --ControlScope�����÷�Χ(0վ��1��֯2��ɫ3�û�4ʵ���ɫ)
        4,                                         --SensitiveType ����������(0�����޸�1���ú󲻿ɸ�2ʹ�ú󲻿ɸ�3��׷˷�޸�4��ǰ���޸�)
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
    ('zh-CN', @ID, 'Token��ʱʱ��(��)', 'Token��ʱʱ��(��)', '�������');
END;
