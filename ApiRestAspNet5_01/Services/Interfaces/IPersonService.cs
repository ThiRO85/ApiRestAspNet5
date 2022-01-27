using ApiRestAspNet5_01.Model;
using System.Collections.Generic;

namespace ApiRestAspNet5_01.Services.Implementations
{
    public interface IPersonService
    {
        Person Create(Person person);
        Person FindById(long id);
        List<Person> FindAll();
        Person Update(Person person);
        void Delete(long id);
    }
}
