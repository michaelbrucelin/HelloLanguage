-----------------可以配合max degree of parallelism 选项.这样能最大限制的控制并行导致cpu不可用而造成的短查询的等待。---------

-------单个查询最高可使用的CPU数 默认为0使用所有CPU----------
sp_configure 'show advanced options', 1;
GO
RECONFIGURE WITH OVERRIDE;
GO
sp_configure 'max degree of parallelism', 12;--假如8个(核)cpu 一般考虑为CPU　4核×6路*2堆叠/4 不堆叠则除2
GO
RECONFIGURE WITH OVERRIDE;
GO
--------配置查询并行度，默认为5--------------
sp_configure 'show advanced options', 1;
GO
RECONFIGURE WITH OVERRIDE;
GO
sp_configure 'cost threshold for parallelism', 10;--将此时间增加为10
GO
RECONFIGURE WITH OVERRIDE;
GO
