using ApiRestAspNet5_01.Context;
using ApiRestAspNet5_01.Models.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApiRestAspNet5_01.Repositories.Generics
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private ApplicationDbContext _context;
        private DbSet<T> _dataSet;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _dataSet = _context.Set<T>();
        }

        public List<T> FindAll()
        {
            return _dataSet.ToList();
        }

        public T FindById(long id)
        {
            return _dataSet.SingleOrDefault(p => p.Id.Equals(id));
        }

        public T Create(T type)
        {
            try
            {
                _dataSet.Add(type);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return type;
        }

        public T Update(T type)
        {
            var result = _dataSet.SingleOrDefault(p => p.Id.Equals(type.Id));

            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(type);
                    _context.SaveChanges();
                    return result;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                return null;
            }
        }

        public void Delete(long id)
        {
            var result = _dataSet.SingleOrDefault(p => p.Id.Equals(id));

            if (result != null)
            {
                try
                {
                    _dataSet.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public bool Exists(long id)
        {
            return _dataSet.Any(p => p.Id.Equals(id));
        }
    }
}
