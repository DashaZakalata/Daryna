CREATE TABLE [dbo].[Customers]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Name] VARCHAR(300) NOT NULL,
	[DeliveryAddress] VARCHAR(500) NOT NULL, 
    [IsActive] BIT NULL
)
