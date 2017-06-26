CREATE TABLE [dbo].[Addin]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [AddInName] NCHAR(99) NULL, 
    [AddInUrl] NCHAR(10) NULL, 
    [ClientId] NCHAR(10) NOT NULL
)
