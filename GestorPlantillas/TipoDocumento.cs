using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestorPlantillas
{
	public class TipoDocumento
	{
		public long Id { get; set; }
		public String Descripcion { get; set; }
		public String Mime { get; set; }
		public String Extension { get; set; }
		public bool Estructurado { get; set; }
		public bool Editable { get; set; }
		public float Tamanio { get; set; }
	}
}