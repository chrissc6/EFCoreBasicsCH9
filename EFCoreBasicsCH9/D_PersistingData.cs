using System;
using System.Collections.Generic;
using System.Text;
using EFCoreBasicsCH9.EfStructures;
using EFCoreBasicsCH9.Entities;

namespace EFCoreBasicsCH9
{
    class D_PersistingData
    {
        private AwDbContext _context = null;

        public D_PersistingData()
        {
            ResetContext();
        }

        public void RunExamples()
        {
            AddAnItem();
            AddItems();
            AddAnObjectGraph();
        }

        public void AddAnItem()
        {
            //helper method 
            ShouldExecuteInATransaction(AddNewPerson);

            //local function
            void AddNewPerson()
            {
                //INSERT INTO PERSON and just these fields right here 
                //Also executes in server side things "row verison"
                var person = new Person
                {
                    AdditionalContactInfo = "Home",
                    FirstName = "Fname",
                    LastName = "Lname",
                    Title = "Neighbor"
                };
                _context.Person.Add(person);
                _context.SaveChanges();
            }
        }

        public void AddAnObjectGraph()
        {
            ShouldExecuteInATransaction(AddNewPerson);

            void AddNewPerson()
            {
                var person = new Person
                {
                    AdditionalContactInfo = "Home",
                    FirstName = "Fname",
                    LastName = "Lname",
                    Title = "Neighbor"
                };
                person.EmailAddress.Add(new EmailAddress
                {
                    EmailAddress1 = "foo@foo.com"
                });
                _context.Person.Add(person);
            }
        }

        public void AddItems()
        {
            ShouldExecuteInATransaction(AddNewPerson);

            void AddNewPerson()
            {
                var list = new List<Person>
                {
                    new Person
                    {
                        AdditionalContactInfo = "Home",
                        FirstName = "Fname",
                        LastName = "Lname",
                        Title = "Neighbor"
                    },
                    new Person
                    {
                        AdditionalContactInfo = "Home",
                        FirstName = "Fname",
                        LastName = "Lname",
                        Title = "Neighbor"
                    }
                };
                _context.Person.AddRange(list);
            }
        }

        public void ShouldExecuteInATransaction(Action actionToExecute)
        {
            using(var transaction = _context.Database.BeginTransaction())
            {
                actionToExecute();
                transaction.Rollback();
            }
        }

        private void ResetContext()
        {
            _context = new AwDbContextFactory().CreateDbContext(null);
        }
    }
}
