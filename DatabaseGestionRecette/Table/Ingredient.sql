CREATE TABLE [dbo].[Ingredient]
(
	[Id] INT NOT NULL PRIMARY KEY identity,
	nom varchar(50) not null,
	descriptions text,
	img varchar(50)
)
