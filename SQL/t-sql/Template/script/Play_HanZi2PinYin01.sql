-- sql server汉字转拼音首字母
-- 调用方法select dbo.GetPinYinFirstLetter('中國')  -- ZG

USE [test]
GO
/****** Object:  UserDefinedFunction [dbo].[GetPinYinFirstLetter]    Script Date: 2021/5/10 16:08:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER FUNCTION [dbo].[GetPYFirstLetter](@str NVARCHAR(4000))
RETURNS NVARCHAR(4000)
--WITH ENCRYPTION

AS
BEGIN
    DECLARE @WORD NCHAR(1),@PY NVARCHAR(4000)
    SET @PY=''

    WHILE LEN(@STR)>0
    BEGIN
        SET @WORD=LEFT(@STR,1)

        --如果非漢字字符﹐返回原字符
        SET @PY=@PY+(CASE WHEN UNICODE(@WORD) BETWEEN 19968 AND 19968+20901
                          THEN (SELECT TOP 1 PY
                                FROM(SELECT 'A' AS PY,N'驁' AS WORD
                                         UNION ALL SELECT 'B',N'簿'
                                         UNION ALL SELECT 'C',N'錯'
                                         UNION ALL SELECT 'D',N'鵽'
                                         UNION ALL SELECT 'E',N'樲'
                                         UNION ALL SELECT 'F',N'鰒'
                                         UNION ALL SELECT 'G',N'腂'
                                         UNION ALL SELECT 'H',N'夻'
                                         UNION ALL SELECT 'J',N'攈'
                                         UNION ALL SELECT 'K',N'穒'
                                         UNION ALL SELECT 'L',N'鱳'
                                         UNION ALL SELECT 'M',N'旀'
                                         UNION ALL SELECT 'N',N'桛'
                                         UNION ALL SELECT 'O',N'漚'
                                         UNION ALL SELECT 'P',N'曝'
                                         UNION ALL SELECT 'Q',N'囕'
                                         UNION ALL SELECT 'R',N'鶸'
                                         UNION ALL SELECT 'S',N'蜶'
                                         UNION ALL SELECT 'T',N'籜'
                                         UNION ALL SELECT 'W',N'鶩'
                                         UNION ALL SELECT 'X',N'鑂'
                                         UNION ALL SELECT 'Y',N'韻'
                                         UNION ALL SELECT 'Z',N'做'
                                    ) as T
                                WHERE WORD>=@WORD COLLATE CHINESE_PRC_CS_AS_KS_WS
                                ORDER BY PY ASC)
                            ELSE @WORD
                        END)
 
        SET @STR=RIGHT(@STR,LEN(@STR)-1)
    END

    RETURN @PY
END
