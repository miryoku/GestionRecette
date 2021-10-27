CREATE TABLE [dbo].[Favoris]
(
	[Id] INT NOT NULL PRIMARY KEY identity,
	id_user int not null,
	id_recette int not null,
	Constraint FK_Favoris_Users foreign key(id_user)
		references users(id),
	Constraint FK_Favoris_Recette foreign key(id_recette)
		references recette(id),
)
