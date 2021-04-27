USE [MonitorElapsedHighSQL]
GO

--��ͳ�����ݶ�ʱ���ʼ�
CREATE  PROCEDURE [dbo].[usp_SendStatisticsMail]
AS
    BEGIN
       
        --�������
        DECLARE @SQL NVARCHAR(MAX)
        DECLARE @SQLConcat NVARCHAR(MAX)
        DECLARE @infoConcat NVARCHAR(MAX)
        DECLARE @finalSQL NVARCHAR(MAX)


        DECLARE @DBID NVARCHAR(MAX)
        DECLARE @servername NVARCHAR(200)
        DECLARE @date DATETIME

        DECLARE @sqlversion NVARCHAR(200)
        DECLARE @uptime NVARCHAR(200)


        --1.���ݿ�汾��Ϣ
        SELECT  @sqlversion = @@version


        --2.���ݿ������������ʱ����Ϣ
        SELECT  @uptime = CONVERT(NVARCHAR(200), DATEDIFF(DAY, sqlserver_start_time, GETDATE()))
        FROM    sys.dm_os_sys_info WITH ( NOLOCK )
        OPTION  ( RECOMPILE )



        --3.�鿴���ݿ��������
        SELECT  @servername = LTRIM(@@servername)


        SET @date = GETDATE()
        SET @SQL = ' '
        SET @SQLConcat = ' '
        SET @infoConcat = ' '



        IF ( @servername IS NOT NULL AND @servername <> '' )
            BEGIN
                SET @infoConcat = '<h3><font color="#FF0000">��������' + @ServerName + '</font></h3></br>'
            END

        IF ( @uptime IS NOT NULL  AND @uptime <> '' )
            BEGIN
                SET @infoConcat = @infoConcat + '<h4>���ݿ������������������' + @uptime  + '��</h4></br>' 
            END

        IF ( @sqlversion IS NOT NULL AND @sqlversion <> '' )
            BEGIN
                SET @infoConcat = @infoConcat + '<h4>���ݿ�汾��Ϣ��' + @sqlversion + '</h4></br>'
            END


      -----------------------------------------------------------


        SET @SQL = N'<H3>[' + @servername + ']_ǰ5����ͬ�����ʱSQL ������[MostElapsedStatisticsByDay] ------   �ʼ�����ʱ�䣺' + CONVERT(NVARCHAR(200), @date, 120) + '</H3>'
            + '<table border="1">' + N'<tr>
<th>[id]</th>
<th>[��ʱ]</th>
<th>[IO������]</th>
<th>[IOд����]</th>
<th>[���ݿ�����]</th>
<th>[ִ�мƻ�SQL]</th>
<th>[����]</th>
</tr>' + CAST(( SELECT TOP 5
                        [id] AS 'td' ,
                        '' ,
                        [ElapsedMS] AS 'td' ,
                        '' ,
                        [IOReads] AS 'td' ,
                        '' ,
                        [IOWrites] AS 'td' ,
                        '' ,
                        [DBName] AS 'td' ,
                        '' ,
                        LEFT([planstmttext], 100) AS 'td' ,
                        '' ,
                        CONVERT(DATE, [gettime]) AS 'td' ,
                        ''
                FROM    [dbo].[MostElapsedStatisticsByDay]
                WHERE   DATEPART(DAY, [gettime]) = DATEPART(DAY, GETDATE()) AND DATEPART(MONTH , [gettime]) = DATEPART(MONTH, GETDATE()) AND DATEPART(YEAR, [gettime]) = DATEPART(YEAR, GETDATE())
                ORDER BY [ElapsedMS] DESC
              FOR
                XML PATH('tr') ,
                    ELEMENTS-- TYPE 
              ) AS NVARCHAR(MAX)) + N'</table>';
        PRINT @SQL

        IF ( @SQL IS NOT NULL
             AND @SQL <> ''
           )
            BEGIN
                SET @SQLConcat = @SQL + @SQLConcat

            END




      --------------------------------------------------------



        SET @SQL = N'<H3>[' + @servername + ']_ǰ5��I/O read����SQL ������[MostIOReadStatisticsByDay]------   �ʼ�����ʱ�䣺' + CONVERT(NVARCHAR(200), @date, 120) + '</H3>'
            + '<table border="1">' + N'<tr>
<th>[id]</th>
<th>[IO������]</th>
<th>[���ݿ�����]</th>
<th>[ִ�мƻ�SQL]</th>
<th>[����]</th>
</tr>' + CAST(( SELECT TOP 5
                        [id] AS 'td' ,
                        '' ,
                        [IOReads] AS 'td' ,
                        '' ,
                        [DBName] AS 'td' ,
                        '' ,
                        LEFT([planstmttext], 100) AS 'td' ,
                        '' ,
                        CONVERT(DATE, [gettime]) AS 'td' ,
                        ''
                FROM    [dbo].[MostIOReadStatisticsByDay]
                WHERE   DATEPART(DAY, [gettime]) = DATEPART(DAY, GETDATE()) AND DATEPART(MONTH , [gettime]) = DATEPART(MONTH, GETDATE()) AND DATEPART(YEAR, [gettime]) = DATEPART(YEAR, GETDATE())
                ORDER BY [IOReads] DESC
              FOR
                XML PATH('tr') ,
                    ELEMENTS-- TYPE 
              ) AS NVARCHAR(MAX)) + N'</table>';


     
        IF ( @SQL IS NOT NULL
             AND @SQL <> ''
           )
            BEGIN
                SET @SQLConcat = @SQL + @SQLConcat

            END

--      -----------------------------------------------------



        SET @SQL = N'<H3>[' + @servername + ']_ǰ5��I/O write����SQL ������[MostIOWriteStatisticsByDay]------   �ʼ�����ʱ�䣺'+ CONVERT(NVARCHAR(200), @date, 120) + '</H3>'
            + '<table border="1">' + N'<tr>
<th>[id]</th>
<th>[IOд����]</th>
<th>[���ݿ�����]</th>
<th>[ִ�мƻ�SQL]</th>
<th>[����]</th>
</tr>' + CAST(( SELECT TOP 5
                        [id] AS 'td' ,
                        '' ,
                        [IOWrites] AS 'td' ,
                        '' ,
                        [DBName] AS 'td' ,
                        '' ,
                        LEFT([planstmttext], 100) AS 'td' ,
                        '' ,
                        CONVERT(DATE, [gettime]) AS 'td' ,
                        ''
                FROM    [dbo].[MostIOWriteStatisticsByDay]
                WHERE   DATEPART(DAY, [gettime]) = DATEPART(DAY, GETDATE()) AND DATEPART(MONTH , [gettime]) = DATEPART(MONTH, GETDATE()) AND DATEPART(YEAR, [gettime]) = DATEPART(YEAR, GETDATE())
                ORDER BY [IOWrites] DESC
              FOR
                XML PATH('tr') ,
                    ELEMENTS-- TYPE 
              ) AS NVARCHAR(MAX)) + N'</table>';


      
        IF ( @SQL IS NOT NULL
             AND @SQL <> ''
           )
            BEGIN
                SET @SQLConcat = @SQL + @SQLConcat

            END

--      -------------------------------------------------------




        SET @SQL = N'<H3>[' + @servername + ']_ǰ5��ʹ��sp_executesqlִ�е�SQL ������[sp_executesqlCountStatisticsByDay]------   �ʼ�����ʱ�䣺'+ CONVERT(NVARCHAR(200), @date, 120) + '</H3>'
            + '<table border="1">' + N'<tr>
<th>[id]</th>
<th>[sp_executesql���ô���]</th>
<th>[���ݿ�����]</th>
<th>[ִ�мƻ�SQL]</th>
<th>[����]</th>
</tr>' + CAST(( SELECT TOP 5
                        [id] AS 'td' ,
                        '' ,
                        [sp_executesqlCount] AS 'td' ,
                        '' ,
                        [DBName] AS 'td' ,
                        '' ,
                        LEFT([planstmttext], 100) AS 'td' ,
                        '' ,
                        CONVERT(DATE, [gettime]) AS 'td' ,
                        ''
                FROM    [dbo].[sp_executesqlCountStatisticsByDay]
                WHERE   DATEPART(DAY, [gettime]) = DATEPART(DAY, GETDATE()) AND DATEPART(MONTH , [gettime]) = DATEPART(MONTH, GETDATE()) AND DATEPART(YEAR, [gettime]) = DATEPART(YEAR, GETDATE())
                ORDER BY [sp_executesqlCount] DESC
              FOR
                XML PATH('tr') ,
                    ELEMENTS-- TYPE 
              ) AS NVARCHAR(MAX)) + N'</table>';

     
        IF ( @SQL IS NOT NULL
             AND @SQL <> ''
           )
            BEGIN
                SET @SQLConcat = @SQL + @SQLConcat

            END

--      --------------------------------------------------------
        
        SET @SQL = N'<H3>[' + @servername+ ']_SQL������� ������[SQLCountStatisticsByDay]------   �ʼ�����ʱ�䣺' + CONVERT(NVARCHAR(200), @date, 120) + '</H3>'
            + '<table border="1">' + N'<tr>
<th>[id]</th>
<th>[SQL����]</th>
<th>[����]</th>
</tr>' + CAST(( SELECT  [id] AS 'td' ,
                        '' ,
                        [SQLCount] AS 'td' ,
                        '' ,
                        CONVERT(DATE, [gettime]) AS 'td' ,
                        ''
                FROM    [dbo].[SQLCountStatisticsByDay]
                WHERE   DATEPART(DAY, [gettime]) = DATEPART(DAY, GETDATE()) AND DATEPART(MONTH , [gettime]) = DATEPART(MONTH, GETDATE()) AND DATEPART(YEAR, [gettime]) = DATEPART(YEAR, GETDATE())
              FOR
                XML PATH('tr') ,
                    ELEMENTS-- TYPE 
              ) AS NVARCHAR(MAX)) + N'</table>';

      
        IF ( @SQL IS NOT NULL
             AND @SQL <> ''
           )
            BEGIN
                SET @SQLConcat = @SQL + @SQLConcat

            END

      -----------------------------------------------

        IF ( @infoConcat IS NOT NULL AND @infoConcat <> '' AND @SQLConcat IS NOT NULL  AND @SQLConcat <> '')
            BEGIN
                SET @finalSQL = @infoConcat + '</br></br>' + @SQLConcat
                EXEC [msdb].[dbo].[sp_send_dbmail] @profile_name = 'SQLServer',
                    @recipients = 'dba@xx.com', -- varchar(max) --�ռ���
                    @subject = N'SQL Server ʵ��SQL���ץȡͳ����Ϣ', -- nvarchar(255) ����
                    @body_format = 'HTML', -- varchar(20) ���ĸ�ʽ��ѡֵ��text html
                    @body = @finalSQL
            END


     


    END