SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:       <micha>
-- Create date:  <20210323>
-- Description:  <将e-cology 7流程的出口条件更漂亮的打印出来，否则看不懂>
-- Example:      <declare @input as nvarchar(max) = '(((((条件1 等于''否'' ) ) 或者 ((条件1 等于''是'' ) 并且 (条件2 不等于'''' ) ))) 并且 ((部门 不属于 ''人力资源部'' ) 并且 (RecordID 不等于'''' ) 并且 (修改类型 等于''彻底修改'' ) )) 并且 ((附件描述 等于'''' ) )'
--                exec Q_PrintWFCondition '()', 4, @input>
-- =============================================
CREATE PROCEDURE Q_PrintWFCondition
    @brackets as char(2) = '()',
    @indent as int = 2,
    @input as nvarchar(max)
AS
BEGIN
    SET NOCOUNT ON;

    declare @result as nvarchar(max) = LEFT(@input, 1)  --第一个字符，无论如何都原样输出
    declare @l as char(1) = LEFT(@brackets,1), @r as char(1) = RIGHT(@brackets,1)

    set @input = dbo.fn_RegExReplace(@input, ' {2,}',' ')  --去掉连续的空格
    while(CHARINDEX(') )', @input) > 0) set @input = REPLACE(@input, ') )', '))')
    while(CHARINDEX('( (', @input) > 0) set @input = REPLACE(@input, '( (', '((')

    declare @i as int = 2, @counter as int = 0, @tmp as nchar(1)
    while(@i <= LEN(@input))
    begin
        set @tmp = SUBSTRING(@input, @i, 1)
        if(@tmp = @l and SUBSTRING(@input, @i-1, 1) = @l) begin
            set @counter = @counter + 1
            set @result = @result + CHAR(13) + CHAR(10) + REPLICATE(' ', @indent*@counter) + @tmp
        end
        else if(@tmp = @l and SUBSTRING(@input, @i+1, 1) = @l) begin
            set @result = @result + CHAR(13) + CHAR(10) + REPLICATE(' ', @indent*@counter) + @tmp
        end
        else if(@tmp = @r and SUBSTRING(@input, @i-1, 1) = @r) begin
            set @counter = @counter - 1
            set @result = @result + CHAR(13) + CHAR(10) + REPLICATE(' ', @indent*@counter) + @tmp
        end
        else begin
            set @result = @result + @tmp
        end

        set @i = @i + 1
    end

    print @result
END
GO
