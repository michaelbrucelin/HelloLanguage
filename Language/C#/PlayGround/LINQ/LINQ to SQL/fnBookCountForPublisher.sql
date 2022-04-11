USE [LIA]
GO

/****** Object:  UserDefinedFunction [dbo].[fnBookCountForPublisher]    Script Date: 2022/4/11 9:13:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[fnBookCountForPublisher](@PublisherId UniqueIdentifier)
RETURNS int
AS
BEGIN
    DECLARE @BookCount int

    SELECT @BookCount = count(*)
    FROM dbo.Book
    WHERE dbo.Book.Publisher=@PublisherId

    Return @BookCount
END

GO