/*
Modèle de script de post-déploiement							
--------------------------------------------------------------------------------------
 Ce fichier contient des instructions SQL qui seront ajoutées au script de compilation.		
 Utilisez la syntaxe SQLCMD pour inclure un fichier dans le script de post-déploiement.			
 Exemple :      :r .\monfichier.sql								
 Utilisez la syntaxe SQLCMD pour référencer une variable dans le script de post-déploiement.		
 Exemple :      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/



insert into Roles(nom) 
	values('admin'),('users');
insert into users(speudo,mdp,id_role) 
	values('admin',HASHBYTES('SHA2_512','admin'),1),('test',HASHBYTES('SHA2_512','test'),2);
insert into unite(unite)
	values('unite'),('rondelle'),('feuille'),('tranche');
insert into Ingredient(nom)
	values('gallette de riz'),('tomate'),('salade'),('jambon de parme'),('fromage de chèvre frais');
insert into Ustensiles(nom) 
	values('couteau'),('couvercle'),('plancher à découper');
insert into Categorie(nom) values('Sandwich');
insert into etape(etape,instruction) values(1,'Découper la tomate en tranches fines.'),(2,'Tartiner la galette de maïs de chèvre frais et y disposer la salade, les tranches de tomate et le jambon.'),
	(3,'Les ingrédients doivent bien recouvrir toute la surface de la galette.'),
	(4,'Enrouler la galette (de préférence assez serré pour que les ingrédients ne tombent pas) puis la couper en deux morceaux de taille égale afin d obtenir deux petits sandwiches enroulés beaucoup plus faciles à manger!')
insert into Recette(nom,nbPersonne,id_categorie,preparation,repos,cuisson)
	values('Sandwich de tortillas',1,1,5,0,0);
insert into TEtape(id_etape,id_recette) 
	values(1,1),(2,1),(3,1),(4,1);
insert into TIngredient(id_recette,id_ingredient,id_unite,quantite)
	values(1,1,1,1),(1,2,1,1),(1,3,3,1),(1,4,3,1),(1,5,2,2);
insert into Rating(id_user,id_recette,note)
	values(1,1,4),(2,1,5);
insert into Favoris(id_user,id_recette)
	values(2,1);
insert into Commentaire(id_user,id_recette,commentaire,dates)
	values(1,1,'une merveuille ce sandwich',GETDATE());
insert into TUstensiles(id_recette,id_ustensiles,quantite)
	values(1,1,1),(1,2,1),(1,3,1);