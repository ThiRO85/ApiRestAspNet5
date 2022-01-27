using ApiRestAspNet5_01.Model;
using System.Collections.Generic;

namespace ApiRestAspNet5_01.Services.Implementations
{
    public interface IBookService
    {
        Book Create(Book book);
        Book FindById(long id);
        List<Book> FindAll();
        Book Update(Book book);
        void Delete(long id);
    }
}
