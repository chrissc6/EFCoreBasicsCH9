using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using EFCoreBasicsCH9.EfStructures;
using EFCoreBasicsCH9.Entities;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace EFCoreBasicsCH9
{
    class C_SortingPagingQueries
    {
        private AwDbContext _context = null;

        public C_SortingPagingQueries()
        {
        }

        public void RunSamples()
        {

        }

        internal void GetPersonAndRelatedData()
        {
            //Get collections (many of many to one)
            //Left outer join
            _ = _context.Person.Include(x => x.EmailAddress);

            //Get parent (one of many to one)
            _ = _context.Person.Include(x => x.BusinessEntity);

            //Get chain of related
            //SELECT * FROM PERSON LEFT OUTER JOIN EMPLOYEE ON FK LEFT OUTER JOIN SALEPERSON TO EMPLOYEE
            //_ = _context.Person.Include(x => x.Employee).ThenInclude(x => x.SalesPerson);
            var q = _context.Person.Include(x => x.Employee).ThenInclude(x => x.SalesPerson);
            q.ToList();
        }

        internal void ExplicitlyLoadRelatedData()
        {
            var p = _context.Person.FirstOrDefault(x => x.BusinessEntityId == 1);
            _context.Entry(p).Reference(p => p.Employee).Load();
            _context.Entry(p).Collection(p => p.EmailAddress).Load();
        }

        internal void CreateProjections()
        {
            //Create list of anonymous objects 
            var newAnonList = _context.Person
                .Select(x => new
                {
                    x.FirstName,
                    x.MiddleName,
                    x.LastName
                }).ToList();

            IQueryable<ICollection<EmailAddress>> result1 = _context.Person.Select(x => x.EmailAddress);

            //Select many flattens the list
            IQueryable<EmailAddress> result2 = _context.Person.SelectMany(x => x.EmailAddress);

            //var newVMList = _context.Person
            //    .Select(x => new PersonViewModel
            //    {
            //        FirstName = x.FirstName,
            //        MiddleName = x.MiddleName,
            //        LastName = x.LastName
            //    }).ToList();

            List<PersonViewModel> newVMList = _context.Person
                .Select(x => new PersonViewModel
                {
                    FirstName = x.FirstName,
                    MiddleName = x.MiddleName,
                    LastName = x.LastName
                }).ToList();
        }

        //Subset of the person class 
        //Could have more models all squished together
        public class PersonViewModel
        {
            public string FirstName { get; set; }
            public string MiddleName { get; set; }
            public string LastName { get; set; }
        }

        private void ResetContext()
        {

            _context = new AwDbContextFactory().CreateDbContext(null);
        }
    }
}
