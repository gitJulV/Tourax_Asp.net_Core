using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tourax.Data;
using Tourax.Data.Entities;
using Tourax.Repositories.Interfaces;

namespace Tourax.Repositories
{
    public class TouraxRepository : ITouraxRepository
    {
        private readonly TouraxDbContext _touaxDbContext;

        public TouraxRepository(TouraxDbContext touraxDbContext)
        {
            _touaxDbContext = touraxDbContext;
        }
        #region Bobine
        public IQueryable<BobineEntity> GetBobines()
        {
            return _touaxDbContext.Bobines.Include(b => b.Matiere);
        }

        public IQueryable<BobineEntity> GetBobineById(int idBobine)
        {
            return _touaxDbContext.Bobines.Where(b => b.IdBobine == idBobine).Include(b => b.Matiere);
        }

        public async Task AddBobine(BobineEntity bobine)
        {
            _touaxDbContext.Bobines.Add(bobine);
            await _touaxDbContext.SaveChangesAsync();
        }

        public async Task UpdateBobine(BobineEntity bobine)
        {
            _touaxDbContext.Update(bobine);
            await _touaxDbContext.SaveChangesAsync();
        }

        public async Task DeleteBobine(int idBobine)
        {
            var bobine = GetBobineById(idBobine).FirstOrDefault();
            _touaxDbContext.Bobines.Remove(bobine);
            await _touaxDbContext.SaveChangesAsync();
        }

        #endregion

        #region Matiere
        public IQueryable<MatiereEntity> GetMatieres()
        {
            return _touaxDbContext.Matieres;
        }

        #endregion
    }
}
