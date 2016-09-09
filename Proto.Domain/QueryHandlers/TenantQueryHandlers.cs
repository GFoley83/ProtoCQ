﻿using System.Collections.Generic;
using System.Linq;
using Proto.Data;
using Proto.Domain.Queries.Tenants;
using Proto.Model.Entities;

namespace Proto.Domain.QueryHandlers
{
    public class TenantQueryHandlers<TContext> :
        IQueryHandler<GetTenantByIdQuery, Tenant>,
        IQueryHandler<GetTenantsQuery, IEnumerable<Tenant>>
    {
        private readonly ClientManagementContext context;

        public TenantQueryHandlers
            (ClientManagementContext context)
        {
            this.context = context;
        }

        public Tenant Handle(GetTenantByIdQuery query)
        {
            return context.Tenants.Find(query);
        }

        public IEnumerable<Tenant> Handle(GetTenantsQuery query)
        {
            return context.Tenants
                .Skip((query.PageIndex - 1)*query.PageSize)
                .Take(query.PageSize)
                .ToList();
        }
    }
}