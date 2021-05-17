using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tourax.Data.Entities;

namespace Tourax.Repositories.Interfaces
{
    public interface ITouraxRepository
    {
        public IQueryable<BobineEntity> GetBobines();
        public IQueryable<BobineEntity> GetBobineById(int idBobine);
        public Task AddBobine(BobineEntity bobine);
        public Task UpdateBobine(BobineEntity bobine);
        public Task DeleteBobine(int idBobine);
        public IQueryable<MatiereEntity> GetMatieres();
    }
}
