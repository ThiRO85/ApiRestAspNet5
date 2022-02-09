using ApiRestAspNet5_01.Model;

namespace ApiRestAspNet5_01.Repositories.Generics
{
    public interface IPersonRepository : IRepository<Person>
    {
        Person Disable(long id);
    }
}
