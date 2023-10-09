﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Bulky.DataAccess.Data;
using Bulky.DataAccess.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Bulky.DataAccess.Repository
{
    public class Repository<T>: IRepository<T> where T : class
    {
        private readonly ApplicationContext _db;
        internal DbSet<T> DbSet;

        public Repository(ApplicationContext db)
        {
            _db = db;
            this.DbSet = _db.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = DbSet;
            return query.ToList();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = DbSet;
            query = query.Where(filter);
            return query.FirstOrDefault();
        }

        public void Add(T entity)
        {
            DbSet.Add(entity);
        }

        public void Remove(T entity)
        {
           DbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
           DbSet.RemoveRange(entities);
        }
    }
}