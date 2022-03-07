using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcEF_CodeFirst.Models
{
    public class DatabaseContext:DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<Address> Addresses { get; set; }

        public DatabaseContext()
        {
            CreateDatabase cd = new CreateDatabase();
            Database.SetInitializer(cd);
        }

    }

    public class CreateDatabase:CreateDatabaseIfNotExists<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            for (int i = 0; i < 10; i++)
            {
                Person p = new Person();
                p.Name = FakeData.NameData.GetFirstName();
                p.Surname = FakeData.NameData.GetSurname();
                p.Age = FakeData.NumberData.GetNumber(10, 80);

                context.People.Add(p);
            }
            context.SaveChanges();

            List<Person> people = (context.People.ToList());

            foreach (var person in people)
            {
                for (int i = 0; i < 3; i++)
                {
                    Address a = new Address();
                    a.Person = person;
                    a.MailingAddress = FakeData.PlaceData.GetAddress();
                    context.Addresses.Add(a);
                }

            }
            
            context.SaveChanges();
        }
    }
}