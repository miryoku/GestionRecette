CREATE TABLE [dbo].[Users]
(
	[Id] INT NOT NULL PRIMARY KEY identity,
	speudo varchar(50) not null unique,
	mdp varBinary(64) not null,
	id_role int not null,
	 Constraint FK_Users_Role foreign key(id_role)
		references Roles(id)
)
