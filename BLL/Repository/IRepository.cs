using Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        //List
        IEnumerable<T> GetAll();
        //Create
        void Insert(T entity);
        //Delete
        void Delete(T entity);
        //Update
        void Update(T entity);
        //Get
        T Get(int id);

        T GetByDefault(Expression<Func<T, bool>> exp);
        string SaveChanges();
    }
}
