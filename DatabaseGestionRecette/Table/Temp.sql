CREATE TABLE [dbo].[Temp]
(
	[Id] INT NOT NULL PRIMARY KEY identity,
	preparation int,
	repos int, 
	cuisson int,
	id_recette int not null
	Constraint FK_Temp_Recette foreign key(id_recette)
		references Recette(id)
)
