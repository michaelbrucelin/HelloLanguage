IF OBJECT_ID('[dbo].[usp_MBS_TruncateTable]') > 0
EXECUTE [dbo].[usp_MBS_TruncateTable] 'TMPJXCFX'
ELSE
TRUNCATE TABLE TMPJXCFX 
GO

IF OBJECT_ID('[dbo].[usp_MBS_TruncateTable]') > 0
EXECUTE [dbo].[usp_MBS_TruncateTable] 'TMP_CKZHTJ1'
ELSE
TRUNCATE TABLE TMP_CKZHTJ1 
GO

IF OBJECT_ID('[dbo].[usp_MBS_TruncateTable]') > 0
EXECUTE [dbo].[usp_MBS_TruncateTable] 'TMP_SPCBB'
ELSE
TRUNCATE TABLE TMP_SPCBB 
GO

IF OBJECT_ID('[dbo].[usp_MBS_TruncateTable]') > 0
EXECUTE [dbo].[usp_MBS_TruncateTable] 'TMP_SPCBB_SD'
ELSE
TRUNCATE TABLE TMP_SPCBB_SD 
GO

IF OBJECT_ID('[dbo].[usp_MBS_TruncateTable]') > 0
EXECUTE [dbo].[usp_MBS_TruncateTable] 'TMPDLXSKCFX_CK'
ELSE
TRUNCATE TABLE TMPDLXSKCFX_CK 
GO

IF OBJECT_ID('[dbo].[usp_MBS_TruncateTable]') > 0
EXECUTE [dbo].[usp_MBS_TruncateTable] 'TMPORDERFX'
ELSE
TRUNCATE TABLE TMPORDERFX
GO

IF OBJECT_ID('[dbo].[usp_MBS_TruncateTable]') > 0
EXECUTE [dbo].[usp_MBS_TruncateTable] 'QDXXJ_LS'
ELSE
TRUNCATE TABLE QDXXJ_LS
GO

IF OBJECT_ID('[dbo].[usp_MBS_TruncateTable]') > 0
EXECUTE [dbo].[usp_MBS_TruncateTable] 'tmp_sdxxj'
ELSE
TRUNCATE TABLE tmp_sdxxj
GO

IF OBJECT_ID('[dbo].[usp_MBS_TruncateTable]') > 0
EXECUTE [dbo].[usp_MBS_TruncateTable] 'SMARTMX'
ELSE
TRUNCATE TABLE SMARTMX
GO

IF OBJECT_ID('[dbo].[usp_MBS_TruncateTable]') > 0
EXECUTE [dbo].[usp_MBS_TruncateTable] 'PBILLMX'
ELSE
TRUNCATE TABLE PBILLMX
GO

IF OBJECT_ID('[dbo].[usp_MBS_TruncateTable]') > 0
EXECUTE [dbo].[usp_MBS_TruncateTable] 'DiffKc_Log'
ELSE
TRUNCATE TABLE DiffKc_Log
