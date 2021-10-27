CREATE TABLE [dbo].[TUstensiles]
(
	[Id] INT NOT NULL PRIMARY KEY identity,
	id_recette int not null,
	id_ustensiles int not null,
	quantite int,
	Constraint FK_TUstensile_Ustensiles foreign key(id_ustensiles)
		references ustensiles(id) on delete cascade,
	Constraint FK_TUstensile_Recette foreign key(id_recette)
		references recette(id),
)
