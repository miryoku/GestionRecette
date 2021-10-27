CREATE TABLE [dbo].[TIngredient]
(
	[Id] INT NOT NULL PRIMARY KEY identity,
	id_recette int not null,
	quantite int not null,
	id_ingredient int not null,
	id_unite int not null,
	Constraint FK_TIngredient_Unite foreign key(id_unite)
		references unite(id),
	Constraint FK_TIngredient_Recette foreign key(id_recette)
		references recette(id),
		Constraint FK_TIngredient_Ingredient foreign key(id_ingredient)
		references ingredient(id),
)
