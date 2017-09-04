using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPlantillas.Repository
{
    public interface IPlantillasRepository
    {
        Plantilla Create(Plantilla _Plantilla);
        Plantilla Delete(long id);
        void PutPlantilla(Plantilla Plantilla);
        Plantilla Read(long id);
        IQueryable<Plantilla> ReadPlantillas();
    }
}
