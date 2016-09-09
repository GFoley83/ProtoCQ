using Proto.Data;
using Proto.Domain.Queries.Tenants;
using Proto.Model.Entities;

namespace Proto.Domain.QueryHandlers
{
    public class GetTenantByIdQueryHandler :
        IQueryHandler<GetTenantByIdQuery, Tenant>
    {
        private readonly ClientManagementContext context;

        public GetTenantByIdQueryHandler
            (ClientManagementContext context)
        {
            this.context = context;
        }

        public Tenant Handle(GetTenantByIdQuery query)
        {
            return context.Tenants.Find(query);
        }
    }
}