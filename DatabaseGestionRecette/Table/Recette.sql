CREATE TABLE [dbo].[Recette]
(
	[Id] INT NOT NULL PRIMARY KEY identity,
	nom varchar(250) not null,
	img varchar(50),
	nbPersonne int not null,
	id_categorie int not null,
	preparation int,
	repos int, 
	cuisson int,
	Constraint FK_Recette_Categorie foreign key(id_categorie)
		references categorie(id),
	

)
