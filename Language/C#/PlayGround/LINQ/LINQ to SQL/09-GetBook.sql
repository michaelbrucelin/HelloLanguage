USE [LIA]
GO

/****** Object:  StoredProcedure [dbo].[GetBook]    Script Date: 2022/4/9 17:40:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetBook]
    @BookId UniqueIdentifier,
    @UserName nvarchar(50)
AS
SET NOCOUNT ON

SELECT ID, Title, Subject, Publisher, PubDate, Price, PageCount, Isbn, Summary, Notes
FROM dbo.Book
WHERE ID = @BookId

INSERT INTO dbo.AuditTracking(TableName, UserName, AccessDate)
Values('Book', @UserName, GetDate())

RETURN
GO