USE [LIA]
GO

/****** Object:  UserDefinedFunction [dbo].[fnGetPublishersBooks]    Script Date: 2022/4/11 10:03:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[fnGetPublishersBooks](@Publisher UniqueIdentifier)
RETURNS TABLE

RETURN (
    SELECT ID, Title, Subject, Publisher, PubDate, Price, PageCount, Isbn, Summary, Notes
    FROM dbo.Book
    WHERE Publisher=@Publisher
);

GO