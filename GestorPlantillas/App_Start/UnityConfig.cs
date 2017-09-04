using GestorPlantillas.Repository;
using GestorPlantillas.Service;
using GestorPLantillas.Repository;
using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;

namespace GestorPlantillas
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();
            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
            container.RegisterType<IPlantillasRepository, PlantillasRepository>();
            container.RegisterType<IPlantillasService, PlantillasService>();
			container.RegisterType<ITipoDocumentoRepository, TipoDocumentoRepository>();
			container.RegisterType<ITipoDocumentoService, TipoDocumentoService>();
		}
    }
}