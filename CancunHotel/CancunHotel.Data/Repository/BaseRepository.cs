using CancunHotel.Data.Context;
using CancunHotel.Domain.Interfaces.Repositories;
using CancunHotel.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CancunHotel.Data.Repository
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly CancunHotelContext Db;
        protected readonly DbSet<T> DbSet;

        public BaseRepository(CancunHotelContext context)
        {
            Db = context;
            DbSet = Db.Set<T>();
        }

        public async Task<IQueryable<T>> GetByAllAsync()
        {
            try
            {
                return DbSet.AsQueryable();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            try
            {
                return await DbSet.SingleOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<T> InsertAsync(T obj)
        {
            try
            {
                if (obj.Id == Guid.Empty)
                {
                    obj.Id = Guid.NewGuid();
                }

                if (obj.CreatedIn == DateTime.MinValue)
                {
                    obj.CreatedIn = DateTime.Now;
                }

                DbSet.Add(obj);

                await Db.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return obj;
        }

        public async Task<T> UpdateAsync(T obj)
        {
            try
            {
                var current = await DbSet.SingleOrDefaultAsync(x => x.Id == obj.Id);
                if (current == null)
                {
                    return null;
                }

                obj.CreatedIn = current.CreatedIn;
                obj.UpdatedIn = DateTime.Now;

                Db.Entry(current).CurrentValues.SetValues(obj);

                await Db.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return obj;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                var current = await DbSet.SingleOrDefaultAsync(x => x.Id == id);
                if (current == null)
                {
                    return false;
                }

                DbSet.Remove(current);
                await Db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return true;
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
