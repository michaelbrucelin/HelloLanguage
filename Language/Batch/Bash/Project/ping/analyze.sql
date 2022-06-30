-- t-sql分析脚本——单一结果查询
;with c0 as (
select [dbo].[fn_RegExReplace](txt,', pipe \d+$','') as txt
from openrowset(bulk 'C:\Users\Q0089\Desktop\桌面\170418\netTestResult_new_201704181400 - 副本.txt',formatfile='C:\fromtext.xml') as tb
),c1 as(
select case CHARINDEX('rtt',txt) when 0 then '0' else 1 end as flag,
       [dbo].[fn_RegExMatch](txt,'\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}') as dest_ip,
       [dbo].[fn_RegExMatchGroups](txt,'(\d+) packets transmitted',1) as transmit,
       [dbo].[fn_RegExMatchGroups](txt,'(\d+) received',1) as received,
       [dbo].[fn_RegExMatchGroups](txt,'(\d{1,3})%',1) as [loss(%)],
       [dbo].[fn_RegExMatchGroups](txt,'time (\d+)ms',1) as [times(ms)],
       [dbo].[fn_RegExMatchGroups](txt,'rtt min/avg/max/mdev = (\d+\.\d+)/(\d+\.\d+)/(\d+\.\d+)/(\d+\.\d+) ms$',1) as [min(ms)],
       [dbo].[fn_RegExMatchGroups](txt,'rtt min/avg/max/mdev = (\d+\.\d+)/(\d+\.\d+)/(\d+\.\d+)/(\d+\.\d+) ms$',2) as [avg(ms)],
       [dbo].[fn_RegExMatchGroups](txt,'rtt min/avg/max/mdev = (\d+\.\d+)/(\d+\.\d+)/(\d+\.\d+)/(\d+\.\d+) ms$',3) as [max(ms)],
       [dbo].[fn_RegExMatchGroups](txt,'rtt min/avg/max/mdev = (\d+\.\d+)/(\d+\.\d+)/(\d+\.\d+)/(\d+\.\d+) ms$',4) as [mdev(ms)]
from c0)
select dest_ip,
       CONVERT(int,[loss(%)]) as [loss_new(%)],CONVERT(int,[times(ms)]) as [times_new(ms)],
       case flag when 0 then 0.0 else CONVERT(decimal(18,3),[min(ms)]) end as [min_new(ms)],
       case flag when 0 then 0.0 else CONVERT(decimal(18,3),[avg(ms)]) end as [avg_new(ms)],
       case flag when 0 then 0.0 else CONVERT(decimal(18,3),[max(ms)]) end as [max_new(ms)],
       case flag when 0 then 0.0 else CONVERT(decimal(18,3),[mdev(ms)]) end as [mdev_new(ms)]
from c1

-- t-sql分析脚本——两份结果对比
;with cnew0 as (
select [dbo].[fn_RegExReplace](txt,', pipe \d+$','') as txt
from openrowset(bulk 'C:\Users\Q0089\Desktop\桌面\170418\netTestResult_new_201704181400 - 副本.txt',formatfile='C:\fromtext.xml') as tb
), cold0 as(
select [dbo].[fn_RegExReplace](txt,', pipe \d+$','') as txt
from openrowset(bulk 'C:\Users\Q0089\Desktop\桌面\170418\netTestResult_124_201704181400 - 副本.txt',formatfile='C:\fromtext.xml') as tb
),cnew as(
select case CHARINDEX('rtt',txt) when 0 then '0' else 1 end as flag,
       [dbo].[fn_RegExMatch](txt,'\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}') as dest_ip,
       [dbo].[fn_RegExMatchGroups](txt,'(\d+) packets transmitted',1) as transmit,
       [dbo].[fn_RegExMatchGroups](txt,'(\d+) received',1) as received,
       [dbo].[fn_RegExMatchGroups](txt,'(\d{1,3})%',1) as [loss(%)],
       [dbo].[fn_RegExMatchGroups](txt,'time (\d+)ms',1) as [times(ms)],
       [dbo].[fn_RegExMatchGroups](txt,'rtt min/avg/max/mdev = (\d+\.\d+)/(\d+\.\d+)/(\d+\.\d+)/(\d+\.\d+) ms$',1) as [min(ms)],
       [dbo].[fn_RegExMatchGroups](txt,'rtt min/avg/max/mdev = (\d+\.\d+)/(\d+\.\d+)/(\d+\.\d+)/(\d+\.\d+) ms$',2) as [avg(ms)],
       [dbo].[fn_RegExMatchGroups](txt,'rtt min/avg/max/mdev = (\d+\.\d+)/(\d+\.\d+)/(\d+\.\d+)/(\d+\.\d+) ms$',3) as [max(ms)],
       [dbo].[fn_RegExMatchGroups](txt,'rtt min/avg/max/mdev = (\d+\.\d+)/(\d+\.\d+)/(\d+\.\d+)/(\d+\.\d+) ms$',4) as [mdev(ms)]
from cnew0
),cold as(
select case CHARINDEX('rtt',txt) when 0 then 0 else 1 end as flag,
       [dbo].[fn_RegExMatch](txt,'\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}') as dest_ip,
       [dbo].[fn_RegExMatchGroups](txt,'(\d+) packets transmitted',1) as transmit,
       [dbo].[fn_RegExMatchGroups](txt,'(\d+) received',1) as received,
       [dbo].[fn_RegExMatchGroups](txt,'(\d{1,3})%',1) as [loss(%)],
       [dbo].[fn_RegExMatchGroups](txt,'time (\d+)ms',1) as [times(ms)],
       [dbo].[fn_RegExMatchGroups](txt,'rtt min/avg/max/mdev = (\d+\.\d+)/(\d+\.\d+)/(\d+\.\d+)/(\d+\.\d+) ms$',1) as [min(ms)],
       [dbo].[fn_RegExMatchGroups](txt,'rtt min/avg/max/mdev = (\d+\.\d+)/(\d+\.\d+)/(\d+\.\d+)/(\d+\.\d+) ms$',2) as [avg(ms)],
       [dbo].[fn_RegExMatchGroups](txt,'rtt min/avg/max/mdev = (\d+\.\d+)/(\d+\.\d+)/(\d+\.\d+)/(\d+\.\d+) ms$',3) as [max(ms)],
       [dbo].[fn_RegExMatchGroups](txt,'rtt min/avg/max/mdev = (\d+\.\d+)/(\d+\.\d+)/(\d+\.\d+)/(\d+\.\d+) ms$',4) as [mdev(ms)]
from cold0
),cresult as(
select cnew.dest_ip,
       CONVERT(int,cnew.[loss(%)]) as [loss_new(%)],CONVERT(int,cold.[loss(%)]) as [loss_old(%)],
       CONVERT(int,cnew.[times(ms)]) as [times_new(ms)],CONVERT(int,cold.[times(ms)]) as [times_old(ms)],
       case cnew.flag when 0 then 0.0 else CONVERT(decimal(18,3),cnew.[min(ms)]) end as [min_new(ms)],
       case cold.flag when 0 then 0.0 else CONVERT(decimal(18,3),cold.[min(ms)]) end as [min_old(ms)],
       case cnew.flag when 0 then 0.0 else CONVERT(decimal(18,3),cnew.[avg(ms)]) end as [avg_new(ms)],
       case cold.flag when 0 then 0.0 else CONVERT(decimal(18,3),cold.[avg(ms)]) end as [avg_old(ms)],
       case cnew.flag when 0 then 0.0 else CONVERT(decimal(18,3),cnew.[max(ms)]) end as [max_new(ms)],
       case cold.flag when 0 then 0.0 else CONVERT(decimal(18,3),cold.[max(ms)]) end as [max_old(ms)],
       case cnew.flag when 0 then 0.0 else CONVERT(decimal(18,3),cnew.[mdev(ms)]) end as [mdev_new(ms)],
       case cold.flag when 0 then 0.0 else CONVERT(decimal(18,3),cold.[mdev(ms)]) end as [mdev_old(ms)]
from cnew inner join cold on cnew.dest_ip = cold.dest_ip)

select * from cresult
