using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using AspNetWebApiTest.Models.Entity;

namespace AspNetWebApiTest.Controllers
{
    public class LogTablesAsyncApiController : ApiController
    {
        private NorthwindEntities db = new NorthwindEntities();

        // GET: api/LogTablesAsyncApi
        public IQueryable<LogTable> GetLogTable()
        {
            return db.LogTable;
        }

        // GET: api/LogTablesAsyncApi/5
        [ResponseType(typeof(LogTable))]
        public async Task<IHttpActionResult> GetLogTable(int id)
        {
            LogTable logTable = await db.LogTable.FindAsync(id);
            if (logTable == null)
            {
                return NotFound();
            }

            return Ok(logTable);
        }

        // PUT: api/LogTablesAsyncApi/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutLogTable(int id, LogTable logTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != logTable.Id)
            {
                return BadRequest();
            }

            db.Entry(logTable).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LogTableExists(id))
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

        // POST: api/LogTablesAsyncApi
        [ResponseType(typeof(LogTable))]
        public async Task<IHttpActionResult> PostLogTable(LogTable logTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.LogTable.Add(logTable);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = logTable.Id }, logTable);
        }

        // DELETE: api/LogTablesAsyncApi/5
        [ResponseType(typeof(LogTable))]
        public async Task<IHttpActionResult> DeleteLogTable(int id)
        {
            LogTable logTable = await db.LogTable.FindAsync(id);
            if (logTable == null)
            {
                return NotFound();
            }

            db.LogTable.Remove(logTable);
            await db.SaveChangesAsync();

            return Ok(logTable);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LogTableExists(int id)
        {
            return db.LogTable.Count(e => e.Id == id) > 0;
        }
    }
}