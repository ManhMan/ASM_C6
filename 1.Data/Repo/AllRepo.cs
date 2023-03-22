using _1.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static _1.Data.IRepo.IAllRepo;

namespace _1.Data.Repo
{
    public class AllRepo<TEntity> : IAllRepo<TEntity> where TEntity : class
    {
        private DatabaseContext _dbContext;
        public DbSet<TEntity> Entities { get; set; }
        public AllRepo(DatabaseContext DbContext)
        {
            this._dbContext = DbContext;
            this.Entities = _dbContext.Set<TEntity>();
        }

        public async Task<TEntity> AddManyAsyn(IEnumerable<TEntity> entity)
        {
            Collection<TEntity> result = new Collection<TEntity>();
            foreach (var item in entity) // thêm từng cái 1
            {
                Collection<TEntity> collects = result;
                collects.Add(await this.AddOneAsyn(item));
            }
            return (TEntity)(IEnumerable<TEntity>)result;
        }

        public async Task<TEntity> AddOneAsyn(TEntity entity)
        {
            await this.Entities.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> DeleteManyAsyn(IEnumerable<TEntity> entity)
        {
            Collection<TEntity> result = new Collection<TEntity>();
            foreach (var item in entity) // thêm từng cái 1
            {
                Collection<TEntity> collects = result;
                collects.Add(await this.DeleteOneAsyn(item));
            }
            return (TEntity)(IEnumerable<TEntity>)result;
        }

        public async Task<TEntity> DeleteOneAsyn(TEntity entity)
        {
            await Task.FromResult<TEntity>(this.Entities.Remove(entity).Entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await Entities.ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await Entities.FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> UpdateManyAsyn(IEnumerable<TEntity> entity)
        {
            Collection<TEntity> result = new Collection<TEntity>();
            foreach (var item in entity) // thêm từng cái 1
            {
                Collection<TEntity> collects = result;
                collects.Add(await this.UpdateOneAsyn(item));
            }
            return (IEnumerable<TEntity>)result;
        }

        public async Task<TEntity> UpdateOneAsyn(TEntity entity)
        {
            _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
