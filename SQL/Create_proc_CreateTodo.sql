-- Create a new stored procedure called 'proc_CreateTodo' in schema 'dbo'
-- Drop the stored procedure if it already exists
IF EXISTS (
SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
    AND SPECIFIC_NAME = N'proc_CreateTodo'
)
DROP PROCEDURE dbo.proc_CreateTodo
GO
-- Create the stored procedure in the specified schema
CREATE PROCEDURE dbo.proc_CreateTodo
	@title nvarchar(200), 
	@description nvarchar(1000), 
	@completeDate date
AS
begin
	insert into TodoList (Title, Description, CreatedDateTime, CompleteByDate)
	values (@title, @description, CURRENT_TIMESTAMP, @completeDate)
end
GO
-- example to execute the stored procedure we just created
EXECUTE dbo.proc_CreateTodo 1 /*value_for_param1*/, 2 /*value_for_param2*/
GO