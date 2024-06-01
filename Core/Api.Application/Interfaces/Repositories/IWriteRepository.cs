using Api.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Application.Interfaces.Repositories
{
    public interface IWriteRepository<T> where T : class,IEntityBase,new()
    {
        Task AddAsync(T entity);
        Task AddRangeAsync(IList<T> entities);
        Task<T> UpdateAsync(T entity);
        Task HardDeleteAsync(T entity);//Normalde int kullanilabilir,burda id'nin turunu bilemedigimiz icin 
        Task HardDeleteRangeAsync(IList<T> entity);//Normalde int kullanilabilir,burda id'nin turunu bilemedigimiz icin 

       

    }
}
