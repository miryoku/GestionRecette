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
                Rating = (decimal)reader["rating"],
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
                Rating=(decimal)reader["rating"]
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
                Quantite=(int)reader["Quantite"]
            };
        }

    }
}
