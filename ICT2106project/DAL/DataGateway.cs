using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ICT2106project.DAL
{
    public class DataGateway<T> : IDataGateway<T> where T : class
    {
        internal LibraryManagementContext db = new LibraryManagementContext();
        internal DbSet<T> data = null;

        public DataGateway()
        {
            this.data = db.Set<T>();
        }

        public IEnumerable<T> SelectAll()
        {
            return data.ToList();
        }

        public T SelectById(int? id)
        {
            if (id == null)
            {
                return null;
            }
            T obj = data.Find(id);
            if (obj == null)
            {
                return null;
            }
            return obj;
        }

        public void Insert(T obj)
        {
            data.Add(obj);
            db.SaveChanges();
        }

        public void Update(T obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
        }

        public T Delete(int? id)
        {
            T obj = data.Find(id);
            data.Remove(obj);
            db.SaveChanges();
            return obj;
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}