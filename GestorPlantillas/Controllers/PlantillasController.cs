using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using GestorPlantillas.Models;
using System.Web.Http.Cors;
using GestorPlantillas.Service;
using GestorPlantillas;

namespace GestorPlantillas.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PlantillasController : ApiController
    {
        private IPlantillasService PlantillasService;
        public PlantillasController(IPlantillasService _PlantillasService)
        {
            this.PlantillasService = _PlantillasService;
        }

        // GET: api/Plantillas
        public IQueryable<Plantilla> GetPlantillas()
        {
            return this.PlantillasService.ReadPlantillas();
        }

        // GET: api/Plantillas/5
        [ResponseType(typeof(Plantilla))]
        public IHttpActionResult GetPlantilla(long id)
        {
            Plantilla Plantilla = this.PlantillasService.GetPlantilla(id);
            if (Plantilla == null)
            {
                return NotFound();
            }

            return Ok(Plantilla);
        }

        // PUT: api/Plantillas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPlantilla(long id, Plantilla Plantilla)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != Plantilla.Id)
            {
                return BadRequest();
            }


            try
            {
                this.PlantillasService.PutPlantilla(Plantilla);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (this.PlantillasService.GetPlantilla(id) == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Plantillas
        [ResponseType(typeof(Plantilla))]
        public IHttpActionResult PostPlantilla(Plantilla Plantilla)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Plantilla = this.PlantillasService.Create(Plantilla);

            return CreatedAtRoute("DefaultApi", new { id = Plantilla.Id }, Plantilla);
        }

        // DELETE: api/Plantillas/5
        [ResponseType(typeof(Plantilla))]
        public IHttpActionResult DeletePlantilla(long id)
        {
            try
            {
                return Ok(this.PlantillasService.Delete(id));
            }
            catch (NoEncontradoException e)
            {
                return NotFound();
            }



        }
    }
}