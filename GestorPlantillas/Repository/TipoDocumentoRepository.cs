using GestorPlantillas.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GestorPlantillas.Repository
{
	public class TipoDocumentoRepository : ITipoDocumentoRepository
	{
		public TipoDocumento Create(TipoDocumento tipoDoc)
		{
			return ApplicationDbContext.applicationDbContext.TipoDocumento.Add(tipoDoc);
		}

		public TipoDocumento Read(long Id)
		{
			return ApplicationDbContext.applicationDbContext.TipoDocumento.Find(Id);
		}

		public IQueryable<TipoDocumento> Read()
		{
			IList<TipoDocumento> lista = new List<TipoDocumento>(ApplicationDbContext.applicationDbContext.TipoDocumento);
			return lista.AsQueryable();
		}

		public void Update(TipoDocumento tipoDoc)
		{
			ApplicationDbContext.applicationDbContext.Entry(tipoDoc).State = EntityState.Modified;
		}

		public TipoDocumento Delete(long Id)
		{
			throw new NotImplementedException();
		}
	}
}