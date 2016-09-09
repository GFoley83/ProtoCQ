using System.Collections.Generic;
using System.Linq;
using Proto.Data;
using Proto.Domain.Queries.Tenants;
using Proto.Model.Entities;

namespace Proto.Domain.QueryHandlers
{
    public class GetTenantsQueryHandler :
        IQueryHandler<GetTenantsQuery, IEnumerable<Tenant>>
    {
        private readonly ClientManagementContext context;

        public GetTenantsQueryHandler(ClientManagementContext context)
        {
            this.context = context;
        }

        public IEnumerable<Tenant> Handle(GetTenantsQuery query)
        {

            return new List<Tenant>()
                   {
                       new Tenant()
                       {
                           AccountNumber = "Test123"
                       }
                   };
//            return context.Tenants
//                .Skip((query.PageIndex - 1)*query.PageSize)
//                .Take(query.PageSize)
//                .ToList();
        }
    }
}