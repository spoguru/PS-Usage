CREATE TABLE [dbo].[Client]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Client] NCHAR(255) NOT NULL, 
    [Tenant] NCHAR(255) NULL

	
)

BEGIN

INSERT INTO dbo.Client (   Id ,
                       Client ,
                       Tenant
                   )
VALUES (   0 ,   -- Id - int
           N'SD Tenant SPE307094' , -- Client - nchar(255)
           N'https://spe307094.sharepoint.com/sites/pwa/'   -- Tenant - nchar(255)
       )

	   END