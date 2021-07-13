USE [master]
GO
/****** Object:  StoredProcedure [dbo].[SwitchODBCIP]    Script Date: 2021/7/12 15:41:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:       <mlin-Q1953>
-- Create date:  <2021-07-12>
-- Description:  <系统的ODBC切换中的server（IP或者域名），不同的ip通过不同的路由连接同一个目标服务器，间接实现了网络切换
--                服务：MSSQLSERVER的启动用户需要有更改注册表的权限>
-- =============================================
ALTER PROCEDURE [dbo].[SwitchODBCServer] @server varchar(255)
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;

    set @server = ISNULL(@server, '')
    if(@server != '')
    begin
        declare @curr_server varchar(255)
        -- exec [master].[dbo].[xp_regread] 'HKEY_LOCAL_MACHINE', 'SOFTWARE\ODBC\ODBC.INI\ODBCNAME', 'SERVER', @curr_server output
        exec [master].[dbo].[xp_regread]   @rootkey    = 'HKEY_LOCAL_MACHINE'
                                         , @key        = 'SOFTWARE\ODBC\ODBC.INI\ODBCNAME'
                                         , @value_name = 'SERVER'
                                         , @value      = @curr_server output

        set @curr_server = ISNULL(@curr_server, '')
        if(@server != @curr_server)
        begin
            --注意值类型有2种：REG_SZ表示字符型，REG_DWORD表示整型
            -- exec [master].[dbo].[xp_regwrite] 'HKEY_LOCAL_MACHINE', 'SOFTWARE\ODBC\ODBC.INI\ODBCNAME', 'SERVER', 'REG_SZ', @server
            exec [master].[dbo].[xp_regwrite]   @rootkey    = 'HKEY_LOCAL_MACHINE'
                                              , @key        = 'SOFTWARE\ODBC\ODBC.INI\ODBCNAME'
                                              , @value_name = 'SERVER'
                                              , @type       = 'REG_SZ'
                                              , @value      = @server
        end
    end
END
