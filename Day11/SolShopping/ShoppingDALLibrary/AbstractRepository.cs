using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDALLibrary
{
    public abstract class AbstractRepository<K, T> : IRepository<K, T>
    {
        protected List<T> items = new List<T>();
        public int GenerateId()
        {
            if (items.Count == 0)
                return 1;
            int id = items.Count;
            return ++id;
        }

        public virtual T Add(T item)
        {
            items.Add(item);
            return item;
        }

        public virtual ICollection<T> GetAll()
        {

            if (items.ToList<T>().Count != 0)
                return items.ToList<T>();
            throw new NoRecordsFoundException();
        }

        public abstract T Delete(K key);

        public abstract T GetByKey(K key);

        public abstract T Update(T item);

    }
}
