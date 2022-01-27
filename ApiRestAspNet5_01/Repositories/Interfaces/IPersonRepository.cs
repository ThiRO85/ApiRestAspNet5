using ApiRestAspNet5_01.Model;
using System.Collections.Generic;

namespace ApiRestAspNet5_01.Repository.Implementations
{
    public interface IPersonRepository
    {
        Person Create(Person person);
        Person FindById(long id);
        List<Person> FindAll();
        Person Update(Person person);
        void Delete(long id);
        bool Exists(long id);
    }
}
