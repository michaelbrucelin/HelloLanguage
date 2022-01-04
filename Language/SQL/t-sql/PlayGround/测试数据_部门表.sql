USE [test]
GO
/****** Object:  Table [dbo].[HrmDepartment]    Script Date: 2019/11/3 15:28:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[HrmDepartment]
(
    [id] [int] IDENTITY(1,1) NOT NULL,
    [departmentmark] [varchar](64) NULL,
    [departmentname] [varchar](32) NULL,
    [subcompanyid1] [int] NULL,
    [supdepid] [int] NULL,
    [allsupdepid] [varchar](1024) NULL,
    [showorder] [int] NULL,
    [canceled] [char](1) NULL,
    [departmentcode] [varchar](128) NULL,
    [coadjutant] [int] NULL,
    [zzjgbmfzr] [varchar](2048) NULL,
    [zzjgbmfgld] [varchar](2048) NULL,
    [jzglbmfzr] [varchar](2048) NULL,
    [jzglbmfgld] [varchar](2048) NULL,
    PRIMARY KEY CLUSTERED (
    [id] ASC
) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[HrmDepartment] ON

INSERT [dbo].[HrmDepartment]([id], [departmentmark], [departmentname], [subcompanyid1], [supdepid], [allsupdepid], [showorder], [canceled]
                             , [departmentcode], [coadjutant], [zzjgbmfzr], [zzjgbmfgld], [jzglbmfzr], [jzglbmfgld])
VALUES   (2, N'CEO办公室', N'CEO办公室', 5, 0, N'', 1, NULL, N'210', 4, N'', N'', N'', N'')
       , (3, N'人事行政部', N'人事行政部', 5, 2, N'', 1, NULL, N'211', 52, N'', N'', N'', N'')
       , (4, N'财务部', N'财务部', 5, 2, N'', 2, NULL, N'212', 14, N'', N'', N'', N'')
       , (6, N'营销部', N'营销部', 5, 2, N'', 5, NULL, N'214', 21, N'', N'', N'', N'')
       , (7, N'市场部', N'市场部', 5, 2, N'', 4, NULL, N'215', 32, N'', N'', N'', N'')
       , (8, N'运营部', N'运营部', 5, 2, N'', 7, NULL, N'216', 6, N'', N'', N'', N'')
       , (10, N'客户管理部', N'客户管理部', 5, 2, N'', 6, NULL, N'218', 7, N'', N'', N'', N'')
       , (11, N'培训部', N'培训部', 5, 3, N'', 1, NULL, N'21101', 0, N'', N'', N'', N'')
       , (14, N'产品管理1部', N'产品管理1部', 5, 6, N'', 1, NULL, N'21403', 71, N'', N'', N'', N'')
       , (16, N'产品管理2部', N'产品管理2部', 5, 6, N'', 2, NULL, N'21405', 138, N'', N'', N'', N'')
       , (17, N'产品管理3部', N'产品管理3部', 5, 6, N'', 3, NULL, N'21406', 432, N'', N'', N'', N'')
       , (21, N'流量管理部', N'流量管理部', 5, 6, N'', 50, N'0', N'21450', 21, N'', N'', N'', N'')
       , (22, N'国际业务1部', N'国际业务1部', 5, 7, N'', 1, NULL, N'21501', 5, N'', N'', N'', N'')
       , (23, N'国际业务2部', N'国际业务2部', 5, 7, N'', 2, NULL, N'21502', 9, N'', N'', N'', N'')
       , (24, N'国际业务3部', N'国际业务3部', 5, 7, N'', 3, NULL, N'21503', 11, N'', N'', N'', N'')
       , (25, N'国际业务4部', N'国际业务4部', 5, 7, N'', 4, NULL, N'21504', 8, N'', N'', N'', N'')
       , (29, N'数据管理部', N'数据管理部', 5, 8, N'', 1, NULL, N'21602', 38, N'', N'', N'', N'')
       , (31, N'计费部', N'计费部', 5, 10, N'', 0, NULL, N'21802', 89, N'', N'', N'', N'')
       , (33, N'人事部', N'人事部', 5, 3, N'', 2, NULL, N'21102', 0, N'', N'', N'', N'')
       , (47, N'客户服务部', N'客户服务部', 5, 10, N'', 1, NULL, N'21801', 7, N'', N'', N'', N'')
       , (50, N'质量管理部', N'质量管理部', 5, 6, N'', 7, NULL, N'', 102, N'', N'', N'', N'')
       , (52, N'技术支持部', N'技术支持部', 5, 8, N'', 0, NULL, N'21601', 46, N'', N'', N'', N'')
       , (53, N'产品管理4部', N'产品管理4部', 5, 6, N'', 4, NULL, N'', 167, N'', N'', N'', N'')
SET IDENTITY_INSERT [dbo].[HrmDepartment] OFF
