using GestorPlantillas;
using GestorPlantillas.Models;
using GestorPlantillas.Repository;
using GestorPlantillas.Service;
using System;
using System.Linq;

namespace GestorPlantillas.Service
{
    public class PlantillasService : IPlantillasService
    {
        private IPlantillasRepository PlantillasRepository;
        public PlantillasService(IPlantillasRepository _PlantillasRepository)
        {
            this.PlantillasRepository = _PlantillasRepository;
        }
        public Plantilla Create(Plantilla Plantilla)
        {
            using (var context = new ApplicationDbContext())
            {
                ApplicationDbContext.applicationDbContext = context;
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Plantilla = PlantillasRepository.Create(Plantilla);
                        context.SaveChanges();
                        dbContextTransaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        dbContextTransaction.Rollback();
                        throw new Exception("He hecho rollback de la transaccion", ex);
                    }

                }
                return Plantilla;
            }
        }

        public IQueryable<Plantilla> ReadPlantillas()
        {
            using (var context = new ApplicationDbContext())
            {
                IQueryable<Plantilla> Plantillas;
                ApplicationDbContext.applicationDbContext = context;
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Plantillas = PlantillasRepository.ReadPlantillas();
                        context.SaveChanges();
                        dbContextTransaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        dbContextTransaction.Rollback();
                        throw new Exception("He hecho rollback de la transaccion", ex);
                    }

                }
                return Plantillas;
            }
        }

        public Plantilla GetPlantilla(long id)
        {
            using (var context = new ApplicationDbContext())
            {
                Plantilla Plantilla;
                ApplicationDbContext.applicationDbContext = context;
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Plantilla = PlantillasRepository.Read(id);
                        context.SaveChanges();
                        dbContextTransaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        dbContextTransaction.Rollback();
                        throw new Exception("He hecho rollback de la transaccion", ex);
                    }

                }
                return Plantilla;
            }
        }

        public void PutPlantilla(Plantilla Plantilla)
        {
            using (var context = new ApplicationDbContext())
            {
                ApplicationDbContext.applicationDbContext = context;
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        PlantillasRepository.PutPlantilla(Plantilla);
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

        public Plantilla Delete(long id)
        {
            Plantilla resultado;
            using (var context = new ApplicationDbContext())
            {
                ApplicationDbContext.applicationDbContext = context;
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        resultado = PlantillasRepository.Delete(id);
                        context.SaveChanges();
                        dbContextTransaction.Commit();
                    }
                    catch(NoEncontradoException)
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