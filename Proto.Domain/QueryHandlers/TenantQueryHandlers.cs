using System.Linq;
using Proto.Data;
using Proto.Domain.Queries.Tenants;
using Proto.Model.Entities;

namespace Proto.Domain.QueryHandlers
{
    public class TenantQueryHandlers<TContext> :
        IQueryHandler<GetTenantByIdQuery, Tenant>,
        IQueryHandler<GetTenantsQuery, Tenant[]>
    {
        //public IDbContext<ClientManagementContext> Context { get; private set; }
        private ClientManagementContext context;
 
        public TenantQueryHandlers
            (ClientManagementContext context)
        {
            this.context = context;
        }


        //public Tenant[] Handle(GetTenantsQuery query)
        //{
        //    Tenant[] tenants;

        //    using (var context = new ClientManagementContext())
        //    {
        //        tenants = context.Tenants.ToArray();
        //    }

        //    return tenants;
        //}
        public Tenant Handle(GetTenantByIdQuery query)
        {
            return context.Tenants.Find(query);
        }

        public Tenant[] Handle(GetTenantsQuery query)
        {
            return context.Tenants.ToArray();
        }

    }
}
