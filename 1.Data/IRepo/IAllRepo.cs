using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Data.IRepo
{
    public interface IAllRepo
    {
        public interface IAllRepo<TEntity> where TEntity : class
        {
            DbSet<TEntity> Entities { get; set; } // DBset tổng Các phương thức Lấy dữ liệu
                                                   
            Task<TEntity> GetByIdAsync(Guid id); // Lấy 1
            Task<IEnumerable<TEntity>> GetAllAsync(); // Lấy tất
                                                      
            Task<TEntity> AddOneAsyn(TEntity entity); // thêm 1
            Task<TEntity> AddManyAsyn(IEnumerable<TEntity> entity); // thêm một loạt
                                                                    
            Task<TEntity> DeleteOneAsyn(TEntity entity);  // Xóa 1
            Task<TEntity> DeleteManyAsyn(IEnumerable<TEntity> entity); // Xóa 1 loạt
                                                                       
            Task<TEntity> UpdateOneAsyn(TEntity entity); // Sửa 1
            Task<IEnumerable<TEntity>> UpdateManyAsyn(IEnumerable<TEntity> entity); // Sửa 1 loạt
        }
    }
}
