using System.Collections.Generic;
using ApiRestAspNet5_01.Data.Converter.Implementations;
using ApiRestAspNet5_01.Data.VO;
using ApiRestAspNet5_01.Model;
using ApiRestAspNet5_01.Repositories.Generics;
using ApiRestAspNet5_01.Repository.Implementations;
using IPersonRepository = ApiRestAspNet5_01.Repositories.Generics.IPersonRepository;

namespace ApiRestAspNet5_01.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        //private volatile int count;
        //private readonly IRepository<Person> _repository;
        private readonly IPersonRepository _repository;
        private readonly PersonConverter _converter;

        public PersonServiceImplementation(IPersonRepository repository)
        {
            _repository = repository;
            _converter = new PersonConverter();
        }

        public List<PersonVO> FindAll()
        {
            var persons = _repository.FindAll();
            return _converter.Parse(persons);

            //List<Person> persons = new List<Person>();
            //for (int i=0; i<5; i++)
            //{
            //    Person person = MockPerson(i);
            //    persons.Add(person);
            //}
            //return persons;
        }

        public PersonVO FindById(long id)
        {
            var person = _repository.FindById(id);
            return _converter.Parse(person);

            //return new Person
            //{
                //Id = IncrementAndGet(),
            //    FirstName = "Thiago",
            //    LastName = "Oliveira",
            //    Address = "Osasco - SP - Brasil",
            //    Gender = "Male"
            //};
        }

        public PersonVO Create(PersonVO person)
        {
            var personEntity = _converter.Parse(person);
            personEntity = _repository.Create(personEntity);
            return _converter.Parse(personEntity);
        }

        public PersonVO Update(PersonVO person)
        {
            var personEntity = _converter.Parse(person);
            personEntity = _repository.Update(personEntity);
            return _converter.Parse(personEntity);
        }

        public PersonVO Disable(long id)
        {
            var personEntity = _repository.Disable(id);
            return _converter.Parse(personEntity);
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
