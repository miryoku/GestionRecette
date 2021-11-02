using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Tools
{
    public static class Mappers
    {
        public static Users UsersConverter(IDataReader reader)
        {
            return new Users
            {
                Id = (int)reader["Id"],
                Speudo = reader["Speudo"].ToString(),
                Mdp = reader["mdp"].ToString(),
                Roles = reader["Roles"].ToString(),
                Id_role = (int)reader["Id_role"],
            };
        }

        public static Recette RecetteConverter(IDataReader reader)
        {
            return new Recette
            {
                Id = (int)reader["Id"],
                Nom = reader["Nom"].ToString(),
                Img = reader["Img"].ToString(),
                NbPersonne = (int)reader["NbPersonne"],
                NomCategorie = reader["NomCategorie"].ToString(),
                Rating = reader["rating"].ToString(),
            };
        }

        public static Recette RecetteAllConverter(IDataReader reader)
        {
            return new Recette
            {

                Id = (int)reader["Id"],
                Nom = reader["Nom"].ToString(),
                Img = reader["Img"].ToString(),
                NbPersonne = (int)reader["NbPersonne"],
                NomCategorie = reader["NomCategorie"].ToString(),
                Prepration = (int)reader["Preparation"],
                Repos = (int)reader["Repos"],
                Cuisson = (int)reader["Cuisson"],
                Rating=reader["rating"].ToString()
            };
        }

        public static Etapes EtapeConverter(IDataReader reader)
        {
            return new Etapes
            {
                Id = (int)reader["Id"],
                Etape = (int)reader["Etape"],
                Instruction = reader["Instruction"].ToString()
            };
        }

        public static Ustensile UstensileConverter(IDataReader reader)
        {
            return new Ustensile
            {
                Id = (int)reader["Id"],
                Nom = reader["Nom"].ToString(),
                Img = reader["Img"].ToString(),
            };
        }

        public static Ingredient IngredientConverter(IDataReader reader)
        {
            return new Ingredient
            {
                Id = (int)reader["Id"],
                Nom = reader["Nom"].ToString(),
                Img = reader["Img"].ToString(),
                Descrptions = reader["Descriptions"].ToString()
            };
        }

        public static Unites UniteConverter(IDataReader reader)
        {
            return new Unites
            {
                Id = (int)reader["Id"],
                Unite = reader["Unite"].ToString(),
                
            };
        }

        public static Intermediaire IntermediaireConverter(IDataReader reader)
        {
            return new Intermediaire
            {
                Id= (int)reader["Id"],
                IdBis=(int)reader["IdBis"],
                IdRecette=(int)reader["IdRecette"],
                Quantite=(int)reader["Quantite"],
            };
        }

        public static Intermediaire Intermediaire2Converter(IDataReader reader)
        {
            return new Intermediaire
            {
                Id = (int)reader["Id"],
                IdBis = (int)reader["IdBis"],
                IdRecette = (int)reader["IdRecette"],
                Quantite = (int)reader["Quantite"],
                IdTries = (int)reader["idTries"]
            };
        }

        public static Intermediaire Intermediaire3Converter(IDataReader reader)
        {
            return new Intermediaire
            {
                Id = (int)reader["Id"],
                IdBis = (int)reader["IdBis"],
                IdRecette = (int)reader["IdRecette"],
               
            };
        }

        public static Commentaires CommentaireConverter(IDataReader reader)
        {
            return new Commentaires
            {
                Id = (int)reader["Id"],
                Id_recette = (int)reader["Id_recette"],
                Id_user = (int)reader["Id_user"],
                Commentaire=reader["Commentaire"].ToString(),
                Dates=(DateTime)reader["dates"]
            };
        }

        
    }
}
