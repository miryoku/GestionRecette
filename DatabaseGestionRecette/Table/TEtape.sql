CREATE TABLE [dbo].[TEtape]
(
	[Id] INT NOT NULL PRIMARY KEY identity,
	id_recette int not null,
	id_etape int not null,
	Constraint FK_TEtape_Etape foreign key(id_etape)
		references etape(id) on delete cascade,
	Constraint FK_TEtape_Recette foreign key(id_recette)
		references recette(id),
)
