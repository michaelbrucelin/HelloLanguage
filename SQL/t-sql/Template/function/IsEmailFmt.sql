-- 判断字符串是否为EMail格式

CREATE FUNCTION [dbo].[IsEmailFmt](@email varchar(100))

RETURNS bit
AS
BEGIN
    declare @result bit,@part1 varchar(100),@part2 varchar(100),@part3 varchar(100)
    if(CHARINDEX('@',@email) <= 1) or (LEN(@email) - LEN(REPLACE(@email,'@','')) > 1)
    begin
        set @result = 0
    end
    else if(CHARINDEX('.',STUFF(@email,1,CHARINDEX('@',@email),'')) <= 1 or CHARINDEX('.',@email) = LEN(@email))
    begin
        set @result = 0
    end
    else if(CHARINDEX('.',REVERSE(@email)) = 1)
    begin
        set @result = 0
    end
    else
    begin
        set @part1 = LEFT(@email,CHARINDEX('@',@email)-1)
        set @part2 = STUFF(@email,1,CHARINDEX('@',@email),'')
        set @part3 = STUFF(@part2,1,CHARINDEX('.',@part2),'')
        set @part2 = LEFT(@part2,CHARINDEX('.',@part2)-1)
        if(PATINDEX('%[^a-zA-Z0-9._-]%',@part1)>0)
        begin
            set @result = 0
        end
        else if(PATINDEX('%[^a-zA-Z0-9_-]%',@part2)>0)
        begin
            set @result = 0
        end
        else if(PATINDEX('%[^a-zA-Z0-9._-]%',@part3)>0)
        begin
            set @result = 0
        end
        else
        begin
            set @result = 1
        end
    end

    return @result
END
