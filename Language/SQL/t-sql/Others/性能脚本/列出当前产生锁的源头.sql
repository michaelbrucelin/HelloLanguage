--列出最初锁住资源，导致一连串其他进程被锁住的源头
IF EXISTS(SELECT *
FROM master.dbo.sysprocesses
WHERE spid IN (SELECT blocked
FROM master.dbo.sysprocesses))

--确定有进程被其他的进程销住
SELECT spid 进程, status 状态, 登录账号=SUBSTRING(SUSER_SNAME(sid),1,30),
    用户机器名称=SUBSTRING(hostname,1,12),
    是否被锁住=CONVERT(char(3),blocked),
    数据库名称=SUBSTRING(DB_NAME(dbid),1,10),
    cmd 命令, waittype 等待类型
FROM master.dbo.sysprocesses
--列出锁住别人（在别的进程中 blocked 字段出现的值）,但自己未被锁住（blocked=0）
WHERE spid IN (SELECT blocked
    FROM master.dbo.sysprocesses)
    AND blocked=0
ELSE
    SELECT '没有进程被锁住'