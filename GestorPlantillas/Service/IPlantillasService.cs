using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPlantillas.Service
{
    public interface IPlantillasService
    {
        Plantilla Create(Plantilla Plantilla);
        Plantilla Delete(long id);
        Plantilla GetPlantilla(long id);
        void PutPlantilla(Plantilla Plantilla);
        IQueryable<Plantilla> ReadPlantillas();
    }
}
