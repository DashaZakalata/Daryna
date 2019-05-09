﻿CREATE TABLE [dbo].[Customers]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Name] NVARCHAR(300) NOT NULL,
	[DeliveryAddress] NVARCHAR(500) NOT NULL, 
    [IsActive] BIT NULL
)
