using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using GestorPlantillas;
using GestorPlantillas.Models;
using GestorPlantillas.Service;

namespace GestorPlantillas.Controllers
{
	[EnableCors(origins: "*", headers: "*", methods: "*")]
	public class TipoDocumentoController : ApiController
    {
		private ITipoDocumentoService tipoDocumentoService;

		public TipoDocumentoController(TipoDocumentoService _tipoDocService)
		{
			this.tipoDocumentoService = _tipoDocService;
		}


        // GET: api/TipoDocumento
        public IQueryable<TipoDocumento> GetTipoDocumento()
        {
			return this.tipoDocumentoService.Read();
        }

        // GET: api/TipoDocumento/5
        [ResponseType(typeof(TipoDocumento))]
        public IHttpActionResult GetTipoDocumento(long id)
        {
            TipoDocumento tipoDocumento = this.tipoDocumentoService.Read(id);
            if (tipoDocumento == null)
            {
                return NotFound();
            }

            return Ok(tipoDocumento);
        }

        // PUT: api/TipoDocumento/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTipoDocumento(long id, TipoDocumento tipoDocumento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tipoDocumento.Id)
            {
                return BadRequest();
            }

            try
            {
				this.tipoDocumentoService.Update(tipoDocumento);
			}
            catch (DbUpdateConcurrencyException)
            {
                if (this.GetTipoDocumento(id) == null)
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

        // POST: api/TipoDocumento
        [ResponseType(typeof(TipoDocumento))]
        public IHttpActionResult PostTipoDocumento(TipoDocumento tipoDocumento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

			this.tipoDocumentoService.Create(tipoDocumento);

            return CreatedAtRoute("DefaultApi", new { id = tipoDocumento.Id }, tipoDocumento);
        }

        // DELETE: api/TipoDocumento/5
        [ResponseType(typeof(TipoDocumento))]
        public IHttpActionResult DeleteTipoDocumento(long id)
        {
			try
			{
				return Ok(this.tipoDocumentoService.Delete(id));
			}catch (NoEncontradoException e)
			{
				return NotFound();
			}
        }
    }
}