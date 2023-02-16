USE TodoList
GO
-- Create a new stored procedure called 'proc_CompleteTodo' in schema 'dbo'
-- Drop the stored procedure if it already exists
IF EXISTS (
SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
    AND SPECIFIC_NAME = N'proc_CompleteTodo'
)
DROP PROCEDURE dbo.proc_CompleteTodo
GO
-- Create the stored procedure in the specified schema
CREATE PROCEDURE dbo.proc_CompleteTodo
    @ID int
AS
BEGIN
	update todoList
	set IsCompleted = 'true', CompletedDateTime = CURRENT_TIMESTAMP
	where ID = @ID
END
GO