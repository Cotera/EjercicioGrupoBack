using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPlantillas.Services
{
	interface ITipoDocumentoService
	{
		TipoDocumento Create(TipoDocumento tipoDoc);

		TipoDocumento Read(long Id);

		IQueryable<TipoDocumento> Read();

		void Update(TipoDocumento tipoDoc);

		TipoDocumento Delete(long Id);
	}
}
