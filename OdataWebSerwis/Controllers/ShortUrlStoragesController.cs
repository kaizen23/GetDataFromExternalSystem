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
    builder.EntitySet<ShortUrlStorage>("ShortUrlStorages");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class ShortUrlStoragesController : ODataController
    {
        private OdataWebSerwisContext db = new OdataWebSerwisContext();

        // GET: odata/ShortUrlStorages
        [EnableQuery]
        public IQueryable<ShortUrlStorage> GetShortUrlStorages()
        {
            return db.ShortUrlStorages;
        }

        // GET: odata/ShortUrlStorages(5)
        [EnableQuery]
        public SingleResult<ShortUrlStorage> GetShortUrlStorage([FromODataUri] int key)
        {
            return SingleResult.Create(db.ShortUrlStorages.Where(shortUrlStorage => shortUrlStorage.Id == key));
        }

        // PUT: odata/ShortUrlStorages(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<ShortUrlStorage> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ShortUrlStorage shortUrlStorage = db.ShortUrlStorages.Find(key);
            if (shortUrlStorage == null)
            {
                return NotFound();
            }

            patch.Put(shortUrlStorage);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShortUrlStorageExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(shortUrlStorage);
        }

        // POST: odata/ShortUrlStorages
        public IHttpActionResult Post(ShortUrlStorage shortUrlStorage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ShortUrlStorages.Add(shortUrlStorage);
            db.SaveChanges();

            return Created(shortUrlStorage);
        }

        // PATCH: odata/ShortUrlStorages(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<ShortUrlStorage> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ShortUrlStorage shortUrlStorage = db.ShortUrlStorages.Find(key);
            if (shortUrlStorage == null)
            {
                return NotFound();
            }

            patch.Patch(shortUrlStorage);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShortUrlStorageExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(shortUrlStorage);
        }

        // DELETE: odata/ShortUrlStorages(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            ShortUrlStorage shortUrlStorage = db.ShortUrlStorages.Find(key);
            if (shortUrlStorage == null)
            {
                return NotFound();
            }

            db.ShortUrlStorages.Remove(shortUrlStorage);
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

        private bool ShortUrlStorageExists(int key)
        {
            return db.ShortUrlStorages.Count(e => e.Id == key) > 0;
        }
    }
}
