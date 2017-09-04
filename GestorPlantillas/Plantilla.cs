using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestorPlantillas
{
    public class Plantilla
    {
        public long Id { get; set; }
        public String Tipo { get; set; }
        public String Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public List<long> TiposDocumento { get; set; }
    }
}