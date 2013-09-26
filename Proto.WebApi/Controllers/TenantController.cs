using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net;
using System.Web.Http;
using Proto.Domain.Queries.Tenants;
using Proto.Domain.QueryHandlers;
using Proto.Model.Entities;

namespace Proto.WebApi.Controllers
{
    [RoutePrefix("api/tenants")]
    public class TenantController : ApiController
    {
        IQueryHandler<GetTenantByIdQuery, Tenant> getTenant;
        IQueryHandler<GetTenantsQuery, IEnumerable<Tenant>> getTenants;

        public TenantController(
            IQueryHandler<GetTenantByIdQuery, Tenant> getTenant,
            IQueryHandler<GetTenantsQuery, IEnumerable<Tenant>> getTenants)
        {
            this.getTenant = getTenant;
            this.getTenants = getTenants;
        }

        // GET api/<controller>
        [HttpGet(RouteName = "GetTenant")]
        public IEnumerable<Tenant> Get()
        {
            var query = new GetTenantsQuery {PageIndex = 1, PageSize = 10};

            if (getTenants != null) return getTenants.Handle(query);
            throw new HttpResponseException(HttpStatusCode.NotFound);
        }

        // GET api/<controller>/5
        [HttpGet("{id:int}", RouteName = "GetTenantById")]
        public Tenant Get(int id)
        {
            var query = new GetTenantByIdQuery {TenatId = id};

            if (getTenants != null) return getTenant.Handle(query);
            throw new HttpResponseException(HttpStatusCode.NotFound);
        }   

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}