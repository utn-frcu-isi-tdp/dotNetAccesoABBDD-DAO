﻿CREATE TABLE [dbo].[Libro]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Autor] VARCHAR(50) NOT NULL, 
    [Titulo] VARCHAR(50) NOT NULL, 
    [ISBN] VARCHAR(50) NOT NULL
)