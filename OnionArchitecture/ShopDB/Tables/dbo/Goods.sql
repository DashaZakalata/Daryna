﻿CREATE TABLE [dbo].[Goods]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Name] VARCHAR(300) NOT NULL,
	[ImagePath] VARCHAR(300),
	[Manufacturer] VARCHAR(300) NOT NULL,
	[Price] DECIMAL(18,2) NOT NULL
)
