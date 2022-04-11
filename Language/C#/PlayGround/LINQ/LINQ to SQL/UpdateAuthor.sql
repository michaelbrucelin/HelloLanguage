USE [LIA]
GO

/****** Object:  StoredProcedure [dbo].[UpdateAuthor]    Script Date: 2022/4/11 8:53:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateAuthor]
    @ID UniqueIdentifier output,
    @LastName varchar(50),
    @FirstName varchar(50),
    @WebSite varchar(200),
    @UserName varchar(50),
    @TimeStamp timestamp
AS

DECLARE @RecordsUpdated int

-- Save values
UPDATE dbo.Author SET LastName=@LastName, FirstName=@FirstName, WebSite=@WebSite
WHERE ID=@ID AND [TimeStamp]=@TimeStamp

SELECT @RecordsUpdated=@@RowCount

IF @RecordsUpdated = 1 BEGIN

    -- Add auditing record
    INSERT INTO dbo.AuditTracking(TableName, UserName, AccessDate) VALUES('Author', @UserName, GetDate())

END

RETURN @RecordsUpdated
