CREATE TABLE [dbo].[Commentaire]
(
	[Id] INT NOT NULL PRIMARY KEY identity,
	id_user int not null,
	id_recette int not null,
	commentaire text not null,
	dates datetime2 not null
	Constraint FK_Commentaire_Users foreign key(id_user)
		references users(id),
	Constraint FK_Commentaire_Recette foreign key(id_recette)
		references recette(id),
)
