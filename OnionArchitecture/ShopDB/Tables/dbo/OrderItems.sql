CREATE TABLE [dbo].[OrderItems]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[CustomerId] INT NOT NULL,
	[GoodId] INT NOT NULL,
	[Price] DECIMAL(18,2) NOT NULL,
	[Quantity] INT NOT NULL,

	FOREIGN KEY([CustomerId])  REFERENCES [dbo].[Customers]([Id]),
	FOREIGN KEY([GoodId])  REFERENCES [dbo].[Goods]([Id])
)
