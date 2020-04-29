using System;
using System.Linq;
using EFCoreBasicsCH9.EfStructures;
using EFCoreBasicsCH9.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EFCoreBasicsCH9
{
    class A_ChangeTracking
    {
        private AwDbContext _context = null;

        public A_ChangeTracking()
        {
        }

        public void RunSamples()
        {
            ResetContext();
            Console.WriteLine("*** Create new entity ***");
            var person = new Person
            {
                AdditionalContactInfo = "Home",
                FirstName = "George",
                LastName = "Washington",
                Title = "Founding"
            };
            var newEntityEntry = _context.Entry(person);
            DisplayEntityStatus(newEntityEntry);


            //Don't need to reset context since context is still clean
            //ResetContext();
            DisplayEntityStatus(entry:GetEntity());

            ResetContext();

            DisplayEntityStatus(entry: AddEntity(person));

            ResetContext();
            DisplayEntityStatus(entry: DeleteEntity());

            ResetContext();
            EntityEntry entry = EditEntity();
            DisplayEntityStatus(entry);
            DisplayModifiedPropertyStatus(entry);
        }

        internal EntityEntry AddEntity(Person person)
        {
            Console.WriteLine("*** Add Entity *** ");

            _context.Person.Add(person);
            return _context.ChangeTracker.Entries().First();
        }

        internal EntityEntry DeleteEntity()
        {
            Console.WriteLine("*** Delete Entity *** ");
            var person = _context.Person.Find(1);
            //This isnt in memory => retrieved from database
            _context.Entry(person).State = EntityState.Deleted;
            //This must be in memory => retrieved from database
            _context.Person.Remove(person);
            _context.SaveChanges();
            return _context.ChangeTracker.Entries().First();
        }

        internal EntityEntry EditEntity()
        {
            Console.WriteLine("*** Edit Entity *** ");
            var person = _context.Person.Find(2);
            person.LastName = "Franklin";
            _context.Person.Update(person);
            _context.SaveChanges();
            return _context.ChangeTracker.Entries().First();
        }

        internal EntityEntry GetEntity()
        {
            Console.WriteLine("*** Get Entity *** ");
            var person = _context.Person.Find(1);

            //qeury with no tracking
            //var person2 = _context.Person.Where(x => x.BusinessEntityId == 5).AsNoTracking().FirstOrDefault();

            return _context.ChangeTracker.Entries().First();
        }

        private void DisplayEntityStatus(EntityEntry entry)
        {
            Console.WriteLine($"Entity State => {entry.State}");
        }

        private void DisplayModifiedPropertyStatus(EntityEntry entry)
        {
            Console.WriteLine("*** Changed Properties");
            foreach (var prop in entry.Properties
                .Where(x => !x.IsTemporary && x.IsModified))
            {
                Console.WriteLine(
                    $"Property: {prop.Metadata.Name}\r\n\t Orig Value: {prop.OriginalValue}\r\n\t Curr Value: {prop.CurrentValue}");
            }
        }

        private void ResetContext()
        {
            //meant for design time
            _context = new AwDbContextFactory().CreateDbContext(null);
        }
    }
}
