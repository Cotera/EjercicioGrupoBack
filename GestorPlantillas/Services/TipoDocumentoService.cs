using GestorPlantillas.Models;
using GestorPlantillas.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestorPlantillas.Services
{
	public class TipoDocumentoService : ITipoDocumentoService
	{
		private ITipoDocumentoRepository tipoDocumentoRepository;

		public TipoDocumentoService (ITipoDocumentoRepository _tipoDocumentoRepository)
		{
			this.tipoDocumentoRepository = _tipoDocumentoRepository;
		}

		public TipoDocumento Create(TipoDocumento tipoDoc)
		{
			using(var context = new ApplicationDbContext())
			{
				ApplicationDbContext.applicationDbContext = context;
				using (var dbContextTransaction = context.Database.BeginTransaction())
				{
					try
					{
						tipoDoc = tipoDocumentoRepository.Create(tipoDoc);
						context.SaveChanges();
						dbContextTransaction.Commit();
					}
					catch (Exception ex)
					{
						dbContextTransaction.Rollback();
						throw new Exception("He hecho rollback de la transaccion", ex);
					}

				}
				return tipoDoc;
			}
		}
		
		public IQueryable<TipoDocumento> Read()
		{
			using (var context = new ApplicationDbContext())
			{
				IQueryable<TipoDocumento> tiposDoc;
				ApplicationDbContext.applicationDbContext = context;
				using (var dbContextTransaction = context.Database.BeginTransaction())
				{
					try
					{
						tiposDoc = tipoDocumentoRepository.Read();
						context.SaveChanges();
						dbContextTransaction.Commit();
					}
					catch (Exception ex)
					{
						dbContextTransaction.Rollback();
						throw new Exception("He hecho rollback de la transaccion", ex);
					}

				}
				return tiposDoc;
			}
		}

		public TipoDocumento Read(long Id)
		{
			using (var context = new ApplicationDbContext())
			{
				TipoDocumento tipoDoc;
				ApplicationDbContext.applicationDbContext = context;
				using (var dbContextTransaction = context.Database.BeginTransaction())
				{
					try
					{
						tipoDoc = tipoDocumentoRepository.Read(Id);
						context.SaveChanges();
						dbContextTransaction.Commit();
					}
					catch (Exception ex)
					{
						dbContextTransaction.Rollback();
						throw new Exception("He hecho rollback de la transaccion", ex);
					}

				}
				return tipoDoc;
			}
		}

		public void Update(TipoDocumento tipoDoc)
		{
			using (var context = new ApplicationDbContext())
			{
				ApplicationDbContext.applicationDbContext = context;
				using (var dbContextTransaction = context.Database.BeginTransaction())
				{
					try
					{
						tipoDocumentoRepository.Update(tipoDoc);
						context.SaveChanges();
						dbContextTransaction.Commit();
					}
					catch (Exception ex)
					{
						dbContextTransaction.Rollback();
						throw new Exception("He hecho rollback de la transaccion", ex);
					}

				}
			}
		}

		public TipoDocumento Delete(long Id)
		{
			TipoDocumento resultado;
			using (var context = new ApplicationDbContext())
			{
				ApplicationDbContext.applicationDbContext = context;
				using (var dbContextTransaction = context.Database.BeginTransaction())
				{
					try
					{
						resultado = tipoDocumentoRepository.Delete(Id);
						context.SaveChanges();
						dbContextTransaction.Commit();
					}
					catch (NoEncontradoException)
					{
						dbContextTransaction.Rollback();
						throw;
					}
					catch (Exception ex)
					{
						throw new Exception("He hecho rollback de la transaccion", ex);
					}

				}
			}
			return resultado;
		}
	}
}