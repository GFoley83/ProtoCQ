using System.Collections.Generic;
using System.Web.Http;
using Proto.Domain.QueryHandlers;

namespace Proto.WebApi.Controllers
{
    [RoutePrefix("api/tenants")]
    public class TenantController : ApiController
    {

        public TenantController(IQueryHandler<FindUsersBySearchTextQuery, IQueryable<UserInfo>> findUsers,
        IQueryHandler<GetUsersByRolesQuery, IEnumerable<User>> getUsers,
        IQueryHandler<GetHighUsageUsersQuery, IEnumerable<UserInfo>> getHighUsage)
        {
            
        }

        // GET api/<controller>
        [HttpGet(RouteName = "GetTenant")]
        public IEnumerable<string> Get()
        {
            return new[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{id:int}", RouteName = "GetTenantById")] 
        public string Get(int id)
        {
            return "value";
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