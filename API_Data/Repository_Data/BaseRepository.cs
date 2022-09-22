using Api_Data.Context;
using Api_Domain.Entities;
using Api_Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api_Data.Repository_Data
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly MyContext _context;
        private DbSet<T> _dataset;
        public BaseRepository(MyContext context)
        {
            _context = context;
            _dataset = _context.Set<T>();  
        }
        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                var result = await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(id));
                if (result == null)
                    return false;

                _dataset.Remove(result);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<T> InsertAsync(T item)
        {
            try
            {
                // Se o id for vazio recebe um novo guid
                if(item.Id == Guid.Empty)
                {
                    item.Id = Guid.NewGuid();
                }

                item.CreateAt = DateTime.UtcNow;
                _dataset.Add(item);
                // salva no banco de dados
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return item;
        }

        // 
        public async Task<bool> ExistAsync(Guid id)
        {
            return await _dataset.AnyAsync(p => p.Id.Equals(id));
        }

        public async Task<T> SelectAsync(Guid id)
        {
            try
            {
                return await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(id));

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IEnumerable<T>> SelectAsync()
        {
            try
            {
                // Obs: esse caso não é muito bom utilizar para numeros de elevados registros, o ideal é usar sempre where
                return await _dataset.ToListAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        public async Task<T> UpdateAsync(T item)
        {
            try
            {
                // O cliente passa o id, será feita a busca no banco, se encontrar colocará o registro na varaiável
                var result = await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(item.Id));
                // Garante que dados de fora entrem no banco de dados
                if (result == null)
                    return null;
                // Recebe a data atual
                item.UpdateAt = DateTime.UtcNow;
                // Forca sempre receber o dado do result
                item.CreateAt = result.CreateAt;
                // Setar os valores, cruzar
                _context.Entry(result).CurrentValues.SetValues(item);
                //Salavar no banco, faz o commit ou rowback
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return item;
        }

       
    }
}
