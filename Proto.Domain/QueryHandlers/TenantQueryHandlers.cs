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
        ClientManagementContext Context { get; set; }
 
        public TenantQueryHandlers
            (IClientManagementContext context)
        {
            Context = context as ClientManagementContext;
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
            return Context.Tenants.Find(query);
        }

        public Tenant[] Handle(GetTenantsQuery query)
        {
            return Context.Tenants.ToArray();
        }

    }
}
