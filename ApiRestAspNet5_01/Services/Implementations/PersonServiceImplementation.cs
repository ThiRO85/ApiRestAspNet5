using System.Collections.Generic;
using ApiRestAspNet5_01.Model;
using ApiRestAspNet5_01.Repository.Implementations;

namespace ApiRestAspNet5_01.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        //private volatile int count;
        private readonly IPersonRepository _repository;

        public PersonServiceImplementation(IPersonRepository repository)
        {
            _repository = repository;
        }

        public List<Person> FindAll()
        {
            return _repository.FindAll();

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
            return _repository.FindById(id);

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
            return _repository.Create(person);
        }

        public Person Update(Person person)
        {
            return _repository.Update(person);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
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
