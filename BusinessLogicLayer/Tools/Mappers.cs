using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL = DataAccessLayer.Models;
using BLL = BusinessLogicLayer.Models;


namespace BusinessLogicLayer.Tools
{
    public static class Mappers
    {
        public static BLL.Users ToBLL(this DAL.Users u)
        {
            if (u == null) { return null; }
            return new BLL.Users
            {
                Id = u.Id,
                Speudo = u.Speudo,
                Mdp = u.Mdp,
                Roles = u.Roles,
                Id_role = u.Id_role,
                Token = u.Token,
            };
        }

        public static DAL.Users ToDAL(this BLL.Users u)
        {
            if (u == null)
            {
                return null;
            }
            return new DAL.Users
            {
                Id = u.Id,
                Speudo = u.Speudo,
                Mdp = u.Mdp,
                Roles = u.Roles,
                Id_role = u.Id_role,
                Token = u.Token,

            };
        }

        public static BLL.Recette ToBLL(this DAL.Recette r)
        {

            if (r == null)
            {
                return null;
            }
            return new BLL.Recette
            {
                Id = r.Id,
                Nom = r.Nom,
                Img = r.Img,
                NbPersonne = r.NbPersonne,
                NomCategorie = r.NomCategorie,
                Prepration = r.Prepration,
                Repos = r.Repos,
                Cuisson = r.Cuisson,
                Rating = r.Rating
            };
        }

        public static DAL.Recette ToDAL(this BLL.Recette r)
        {
            if (r == null)
            {
                return null; ;
            }
            return new DAL.Recette
            {
                Id = r.Id,
                Nom = r.Nom,
                Img = r.Img,
                NbPersonne = r.NbPersonne,
                NomCategorie = r.NomCategorie,
                Prepration = r.Prepration,
                Repos = r.Repos,
                Cuisson = r.Cuisson,
                Id_categorie = r.Id_categorie,
                Rating = r.Rating
            };
        }

        public static BLL.Etapes ToBLL(this DAL.Etapes u)
        {
            if (u == null) { return null; }
            return new BLL.Etapes
            {
                Id = u.Id,
                Etape = u.Etape,
                Instruction = u.Instruction,
            };
        }

        public static DAL.Etapes ToDAL(this BLL.Etapes u)
        {
            if (u == null)
            {
                return null;
            }
            return new DAL.Etapes
            {
                Id = u.Id,
                Etape = u.Etape,
                Instruction = u.Instruction,

            };
        }

        public static BLL.Ustensiles ToBLL(this DAL.Ustensile u)
        {
            if (u == null) { return null; }
            return new BLL.Ustensiles
            {
                Id = u.Id,
                Nom = u.Nom,
                Img = u.Img,
            };
        }

        public static DAL.Ustensile ToDAL(this BLL.Ustensiles u)
        {
            if (u == null)
            {
                return null;
            }
            return new DAL.Ustensile
            {
                Id = u.Id,
                Nom = u.Nom,
                Img = u.Img,

            };
        }

        public static BLL.Ingredient ToBLL(this DAL.Ingredient u)
        {
            if (u == null) { return null; }
            return new BLL.Ingredient
            {
                Id = u.Id,
                Nom = u.Nom,
                Img = u.Img,
                Descrptions = u.Descrptions,
            };
        }

        public static DAL.Ingredient ToDAL(this BLL.Ingredient u)
        {
            if (u == null)
            {
                return null;
            }
            return new DAL.Ingredient
            {
                Id = u.Id,
                Nom = u.Nom,
                Img = u.Img,
                Descrptions = u.Descrptions,

            };
        }

        public static BLL.Unites ToBLL(this DAL.Unites u)
        {
            if (u == null) { return null; }
            return new BLL.Unites
            {
                Id = u.Id,
                Unite = u.Unite,
            };
        }

        public static DAL.Unites ToDAL(this BLL.Unites u)
        {
            if (u == null)
            {
                return null;
            }
            return new DAL.Unites
            {
                Id = u.Id,
                Unite = u.Unite,


            };
        }

        public static DAL.Intermediaire ToDAL(this BLL.Intermediaire u)
        {
            if (u == null)
            {
                return null;
            }
            return new DAL.Intermediaire
            {
                Id = u.Id,
                IdRecette = u.IdRecette,
                IdBis = u.IdBis,
                Quantite = u.Quantite,
                IdTries = u.IdTries

            };
        }

        public static BLL.Intermediaire ToBLL(this DAL.Intermediaire u)
        {
            if (u == null) { return null; }
            return new BLL.Intermediaire
            {
                Id = u.Id,
                IdRecette = u.IdRecette,
                IdBis = u.IdBis,
                Quantite = u.Quantite,
                IdTries = u.IdTries
            };
        }

        public static DAL.Commentaires ToDAL(this BLL.Commentaires u)
        {
            if (u == null)
            {
                return null;
            }
            return new DAL.Commentaires
            {
                Id = u.Id,
                Id_recette = u.Id_recette,
                Id_user = u.Id_user,
                Commentaire = u.Commentaire,
                Dates = u.Dates,

            };
        }

        public static BLL.Commentaires ToBLL(this DAL.Commentaires u)
        {
            if (u == null) { return null; }
            return new BLL.Commentaires
            {
                Id = u.Id,
                Id_recette = u.Id_recette,
                Id_user = u.Id_user,
                Commentaire = u.Commentaire,
                Dates = u.Dates,
            };
        }

        public static DAL.Categorie ToDAL(this BLL.Categorie u)
        {
            if (u == null)
            {
                return null;
            }
            return new DAL.Categorie
            {
                Id = u.Id,
                Nom = u.Nom,

            };
        }

        public static BLL.Categorie ToBLL(this DAL.Categorie u)
        {
            if (u == null) { return null; }
            return new BLL.Categorie
            {
                Id = u.Id,
                Nom = u.Nom,
            };
        }
    }
}
