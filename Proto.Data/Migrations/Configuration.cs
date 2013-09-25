using Proto.Model.Entities;

namespace Proto.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Proto.Data.ClientManagementContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Proto.Data.ClientManagementContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //


            context.Set<ContactType>().AddOrUpdate(
                ct => ct.Name,
                new ContactType { Name = "consultant" },
                new ContactType { Name = "lawyer" }
            );

            context.Set<Tenant>().AddOrUpdate(
                _ => _.Name,
                new Tenant
                {
                    AccountNumber = "123",
                    Active = 1,
                    BillingAddress = new Address()
                    {
                        Street = "123 foo dr.",
                        City = "foo place",
                        State = "tx",
                        Zip = "123"
                    },
                    ContactTypeId = 1,
                    Description = "foo immigration",
                    Email = "foo@immigration.com",
                    ModifiedDate = DateTime.Now,
                    Name = "foo",
                    OfficePhone = "5551234561",
                    PrimaryContactFirstName = "foo",
                    PrimaryContactLastName = "bar",
                    PrimaryContactPhone = "5556782341"
                }
            );
        }
    }
}
