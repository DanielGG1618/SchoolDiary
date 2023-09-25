CREATE TABLE [dbo].[DoneStatuses]
(
	[Done] TINYINT NOT NULL  DEFAULT 0, 
    [Date] DATETIME NOT NULL, 
    [Num] INT NOT NULL, 
    [User] VARCHAR(50) NOT NULL 
)