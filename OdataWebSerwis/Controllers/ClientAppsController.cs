using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using OdataWebSerwis.Models;

namespace OdataWebSerwis.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using OdataWebSerwis.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<ClientApp>("ClientApps");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class ClientAppsController : ODataController
    {
        private OdataWebSerwisContext db = new OdataWebSerwisContext();

        // GET: odata/ClientApps
        [EnableQuery]
        public IQueryable<ClientApp> GetClientApps()
        {
            return db.ClientApp;
        }

        // GET: odata/ClientApps(5)
        [EnableQuery]
        public SingleResult<ClientApp> GetClientApp([FromODataUri] string key)
        {
            return SingleResult.Create(db.ClientApp.Where(clientApp => clientApp.Id == key));
        }

        // PUT: odata/ClientApps(5)
        public IHttpActionResult Put([FromODataUri] string key, Delta<ClientApp> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ClientApp clientApp = db.ClientApp.Find(key);
            if (clientApp == null)
            {
                return NotFound();
            }

            patch.Put(clientApp);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientAppExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(clientApp);
        }

        // POST: odata/ClientApps
        public IHttpActionResult Post(ClientApp clientApp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ClientApp.Add(clientApp);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ClientAppExists(clientApp.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Created(clientApp);
        }

        // PATCH: odata/ClientApps(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] string key, Delta<ClientApp> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ClientApp clientApp = db.ClientApp.Find(key);
            if (clientApp == null)
            {
                return NotFound();
            }

            patch.Patch(clientApp);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientAppExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(clientApp);
        }

        // DELETE: odata/ClientApps(5)
        public IHttpActionResult Delete([FromODataUri] string key)
        {
            ClientApp clientApp = db.ClientApp.Find(key);
            if (clientApp == null)
            {
                return NotFound();
            }

            db.ClientApp.Remove(clientApp);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ClientAppExists(string key)
        {
            return db.ClientApp.Count(e => e.Id == key) > 0;
        }
    }
}
