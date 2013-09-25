using Proto.Domain.QueryHandlers;
using Proto.Model.Entities;

namespace Proto.Domain.Queries.Tenants
{
    public class GetTenantsQuery : IQuery<Tenant[]>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
