USE [LIA]
GO

/****** Object:  StoredProcedure [dbo].[BookCountForPublisher]    Script Date: 2022/4/11 8:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[BookCountForPublisher]
    @PublisherId UniqueIdentifier
AS
DECLARE @BookCount int

SELECT @BookCount = count(*)
FROM dbo.Book
WHERE dbo.Book.Publisher=@PublisherId

Return @BookCount