using ApiRestAspNet5_01.Model;
using Microsoft.EntityFrameworkCore;

namespace ApiRestAspNet5_01.Context
{
    public interface IApplicationDbContext
    {
        DbSet<Person> Persons { get; set; }
    }
}