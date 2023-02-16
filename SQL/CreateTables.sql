USE TodoList
GO
-- Create a new table called 'TodoList' in schema 'dbo'
-- Drop the table if it already exists
IF OBJECT_ID('dbo.TodoList', 'U') IS NOT NULL
DROP TABLE dbo.TodoList
GO
-- Create the table in the specified schema
CREATE TABLE dbo.TodoList
(
    ID INT NOT NULL PRIMARY KEY, -- primary key column
	[Title] [nvarchar](200) NOT NULL,
	[Description] [nvarchar](1000) NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[CompleteByDate] [date] NULL,
	[CompletedDateTime] [datetime] NULL,
	[IsCompleted] [bit] NULL,
);
GO
