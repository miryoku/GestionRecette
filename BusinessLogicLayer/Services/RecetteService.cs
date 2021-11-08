using BusinessLogicLayer.Interface;
using BusinessLogicLayer.Models;
using BusinessLogicLayer.Tools;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class RecetteService : IRecetteService
    {
        private IRecetteRespository _RecetteService;

        private IIngredientRespository _serviceIngredient;

        private IUniteRespository _serviceUnite;

        private IUstensileRespository _serviceUstensile;


        private IEtapeRespository _serviceEtape;


        public RecetteService(IRecetteRespository ReceteRepo, IIngredientRespository ingredientRespository, IUniteRespository respo, IUstensileRespository serv, IEtapeRespository etapeService)
        {
            _RecetteService = ReceteRepo;
            _serviceIngredient = ingredientRespository;
            _serviceUnite = respo;
            _serviceUstensile = serv;
            _serviceEtape= etapeService;
        }
        public bool Delete(int Id)
        {
           return _RecetteService.Delete(Id);
        }

        public IEnumerable<Recette> GetAll()
        {
            return _RecetteService.GetAll().Select(x=>x.ToBLL());
        }

        public RecetteComplete GetById(int Id)
        {
            Recette recette= _RecetteService.GetById(Id).ToBLL();
            IEnumerable<Intermediaire> intermediaire = _serviceIngredient.GetByIdIntermediaire(Id).Select(x => x.ToBLL());
            List<Ingredient>ingredients = new List<Ingredient>();
            List<Unites>unites = new List<Unites>(); 
            List <IngredientQuantiteUnite> iqus = new List<IngredientQuantiteUnite>(); 
           
            foreach (var item in intermediaire)       
            {
                IngredientQuantiteUnite iqu = new IngredientQuantiteUnite();
                iqu.id = item.Id;
                ingredients.Add(_serviceIngredient.GetById(item.IdBis).ToBLL());
                unites.Add(_serviceUnite.GetById(item.IdTries).ToBLL());
                iqu.Quantite = item.Quantite;
                iqu.Ingredients = ingredients[ingredients.Count-1];
                iqu.Unites = unites[unites.Count-1];
                iqus.Add(iqu);

            }
            IEnumerable<Intermediaire> itermediaireUstensile = _serviceUstensile.GetByIdIntermediaire(Id).Select(x => x.ToBLL());
            List<Ustensiles> ustensiles = new List<Ustensiles>();
            List<UstensilesQuantite> ustensilesQuantites = new List<UstensilesQuantite>();
            foreach (var item in itermediaireUstensile)
            {
                UstensilesQuantite uq= new UstensilesQuantite();
                uq.Id= item.Id;
                ustensiles.Add(_serviceUstensile.GetById(item.IdBis).ToBLL());
                uq.Quantite = item.Quantite;
                uq.Ustensiles=ustensiles[ustensiles.Count-1];
                ustensilesQuantites.Add(uq);
            }
            IEnumerable<Intermediaire> intermediaresEtape= _serviceEtape.GetByIdTEtape(Id).Select(x => x.ToBLL());
            List<Etapes>etapes = new List<Etapes>();
            foreach (var item in intermediaresEtape)
            {
                etapes.Add(_serviceEtape.GetById(item.IdBis).ToBLL());
            }
            RecetteComplete rc=new RecetteComplete();
            rc.recette = recette;
            rc.Composant = iqus;
            rc.Ustensiles = ustensilesQuantites;
            rc.Etapes = etapes;
            return rc;
        }

        public int Insert(Recette model)
        {
            return _RecetteService.Insert(model.ToDAL());
        }

        public bool Update(Recette model)
        {
            return _RecetteService.Update(model.ToDAL());
        }
    }
}
