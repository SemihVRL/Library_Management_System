using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using Library_Management_System.Models.Entity;

namespace Library_Management_System.Repository
{
    public class GenericRepository<T> where T : class,new()
    {
        Db_Library_ManagementEntities1 db= new Db_Library_ManagementEntities1();

        public List<T> List()
        {
            return db.Set<T>().ToList();
        }

        public void Add(T p)
        {
            db.Set<T>().Add(p);
            db.SaveChanges();
        }

        public void Remove(T p)
        {
            db.Set<T>().Remove(p);
            db.SaveChanges();
        }

        public T Find(Expression<Func<T,bool>> where)
        {
            return db.Set<T>().FirstOrDefault(where);
        }

        public void Update(T p)
        {
            db.SaveChanges();
        }
    }
}