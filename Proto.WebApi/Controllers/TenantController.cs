using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net;
using System.Web.Http;
using Proto.Domain.Queries.Tenants;
using Proto.Domain.QueryHandlers;
using Proto.Model.Entities;
using System.Web.Routing;

namespace Proto.WebApi.Controllers
{
    [RoutePrefix("api/tenant")]
    public class TenantController : ApiController
    {
        readonly IQueryHandler<GetTenantByIdQuery, Tenant> _getTenant;
        readonly IQueryHandler<GetTenantsQuery, IEnumerable<Tenant>> _getTenants;

        public TenantController(
            IQueryHandler<GetTenantByIdQuery, Tenant> getTenant,
            IQueryHandler<GetTenantsQuery, IEnumerable<Tenant>> getTenants)
        {
            _getTenant = getTenant;
            _getTenants = getTenants;
        }

        // GET api/<controller>
        [HttpGet]
//        [Route("Get")]
        public IHttpActionResult Get()
        {
            var query = new GetTenantsQuery {PageIndex = 1, PageSize = 10};

            if (_getTenants != null) 
                return Ok(_getTenants.Handle(query));

            throw new HttpResponseException(HttpStatusCode.NotFound);
        }

        // GET api/<controller>/5
        //[HttpGet("{id:int}", RouteName = "GetTenantById")]
        [HttpGet]
//        [Route("GetTenantById")]
        public Tenant Get(int id)
        {
            var query = new GetTenantByIdQuery {TenatId = id};

            if (_getTenants != null) 
                return _getTenant.Handle(query);

            throw new HttpResponseException(HttpStatusCode.NotFound);
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