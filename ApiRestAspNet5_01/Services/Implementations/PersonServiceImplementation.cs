using System;
using System.Collections.Generic;
using System.Linq;
using ApiRestAspNet5_01.Context;
using ApiRestAspNet5_01.Model;
using System.Threading;

namespace ApiRestAspNet5_01.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        //private volatile int count;
        private ApplicationDbContext _context;

        public PersonServiceImplementation(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Person> FindAll()
        {
            return _context.Persons.ToList();

            //List<Person> persons = new List<Person>();
            //for (int i=0; i<5; i++)
            //{
            //    Person person = MockPerson(i);
            //    persons.Add(person);
            //}
            //return persons;
        }

        public Person FindById(long id)
        {
            return _context.Persons.SingleOrDefault(p => p.Id.Equals(id));

            //return new Person
            //{
                //Id = IncrementAndGet(),
            //    FirstName = "Thiago",
            //    LastName = "Oliveira",
            //    Address = "Osasco - SP - Brasil",
            //    Gender = "Male"
            //};
        }

        public Person Create(Person person)
        {
            try
            {
                _context.Add(person);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return person;
        }

        public Person Update(Person person)
        {
            if (!Exists(person.Id))
            {
                return new Person();
            }

            var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(person.Id));

            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(person);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            
            return person;
        }

        public void Delete(long id)
        {
            var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(id));

            if (result != null)
            {
                try
                {
                    _context.Persons.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        private bool Exists(long id)
        {
            return _context.Persons.Any(p => p.Id.Equals(id));
        }

        //private Person MockPerson(int i)
        //{
        //    return new Person
        //    {
        //        Id = IncrementAndGet(),
        //        FirstName = "Joe" + i,
        //        LastName = "ColaSanto" + i,
        //        Address = "Jundiaí - SP - Brasil" + i,
        //        Gender = "Male"
        //    };
        //}

        //private long IncrementAndGet()
        //{
        //    return Interlocked.Increment(ref count);
        //}
    }
}
