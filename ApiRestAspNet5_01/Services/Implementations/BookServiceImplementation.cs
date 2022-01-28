using ApiRestAspNet5_01.Model;
using ApiRestAspNet5_01.Repositories.Generics;
using ApiRestAspNet5_01.Repository.Implementations;
using System.Collections.Generic;

namespace ApiRestAspNet5_01.Services.Implementations
{
    public class BookServiceImplementation : IBookService
    {
        private readonly IRepository<Book> _repository;

        public BookServiceImplementation(IRepository<Book> repository)
        {
            _repository = repository;
        }

        public List<Book> FindAll()
        {
            return _repository.FindAll();            
        }

        public Book FindById(long id)
        {
            return _repository.FindById(id);           
        }

        public Book Create(Book book)
        {
            return _repository.Create(book);
        }

        public Book Update(Book book)
        {
            return _repository.Update(book);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }       
    }
}
