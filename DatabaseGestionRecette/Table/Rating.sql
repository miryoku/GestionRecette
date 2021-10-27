CREATE TABLE [dbo].[Rating]
(
	[Id] INT NOT NULL PRIMARY KEY identity,
	id_user int not null,
	id_recette int not null,
	note DECIMAL(3,2) not null,
	Constraint FK_Rating_Users foreign key(id_user)
		references users(id),
	Constraint FK_Rating_Recette foreign key(id_recette)
		references recette(id),
)
