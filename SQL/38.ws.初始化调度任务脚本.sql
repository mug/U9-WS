IF NOT EXISTS
(
    SELECT *
    FROM UBF_JOB_NoParaRunableBPSVList
    WHERE FullName IN ( 'UFIDA.U9.Cust.Pub.WSM.WSTokenSV.CleanWSTokenSV' )
)
BEGIN
    INSERT INTO UBF_JOB_NoParaRunableBPSVList
    (
        ID,
        FullName,
        Memo
    )
    SELECT a.ID,
           a.FullName,
           at.DisplayName
    FROM UBF_MD_Class a
        LEFT JOIN UBF_MD_Class_Trl at
            ON at.Local_ID = a.Local_ID
               AND SysMLFlag = 'zh-CN'
    WHERE a.FullName IN ( 'UFIDA.U9.Cust.Pub.WSM.WSTokenSV.CleanWSTokenSV' );
END;