using GestorPlantillas;
using GestorPlantillas.Models;
using GestorPlantillas.Repository;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace GestorPLantillas.Repository
{
    public class PlantillasRepository : IPlantillasRepository
    {
        //private ApplicationDbContext db = new ApplicationDbContext();

        public Plantilla Create(Plantilla _Plantilla)
        {
            return ApplicationDbContext.applicationDbContext.Plantillas.Add(_Plantilla);
        }

        public Plantilla Delete(long id)
        {
            Plantilla Plantilla = this.Read(id);
            if(Plantilla == null)
            {
                throw new NoEncontradoException("No se ha encontrado la Plantilla  a eliminar");
            }
            return ApplicationDbContext.applicationDbContext.Plantillas.Remove(Plantilla);

        }

        public void PutPlantilla(Plantilla Plantilla)
        {
            ApplicationDbContext.applicationDbContext.Entry(Plantilla).State = EntityState.Modified;
        }

        public Plantilla Read(long id)
        {
            return ApplicationDbContext.applicationDbContext.Plantillas.Find(id);
        }

        public IQueryable<Plantilla> ReadPlantillas()
        {
            IList<Plantilla> lista = new List<Plantilla>(ApplicationDbContext.applicationDbContext.Plantillas);
            return lista.AsQueryable();
        }
    }
}