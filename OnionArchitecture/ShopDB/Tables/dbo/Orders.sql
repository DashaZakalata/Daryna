CREATE TABLE [dbo].[Orders]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[CustomerId] INT NOT NULL,
	[OrderDate] DATETIME NOT NULL,

	FOREIGN KEY([CustomerId]) REFERENCES [dbo].[Customers]([Id])
)
