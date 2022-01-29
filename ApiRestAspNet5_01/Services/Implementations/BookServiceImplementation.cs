using ApiRestAspNet5_01.Data.Converter.Implementations;
using ApiRestAspNet5_01.Data.VO;
using ApiRestAspNet5_01.Model;
using ApiRestAspNet5_01.Repositories.Generics;
using ApiRestAspNet5_01.Repository.Implementations;
using System.Collections.Generic;

namespace ApiRestAspNet5_01.Services.Implementations
{
    public class BookServiceImplementation : IBookService
    {
        private readonly IRepository<Book> _repository;
        private readonly BookConverter _converter;

        public BookServiceImplementation(IRepository<Book> repository)
        {
            _repository = repository;
            _converter = new BookConverter();
        }

        public List<BookVO> FindAll()
        {
            var books = _repository.FindAll();
            return _converter.Parse(books);            
        }

        public BookVO FindById(long id)
        {
            var book = _repository.FindById(id);
            return _converter.Parse(book);           
        }

        public BookVO Create(BookVO book)
        {
            var bookEntity = _converter.Parse(book);
            bookEntity = _repository.Create(bookEntity);
            return _converter.Parse(bookEntity);
        }

        public BookVO Update(BookVO book)
        {
            var bookEntity = _converter.Parse(book);
            bookEntity = _repository.Update(bookEntity);
            return _converter.Parse(bookEntity);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }       
    }
}
