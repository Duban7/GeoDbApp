using Geo.DAL.context;
using Geo.DAL.repositories.interfaces;
using Geo.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

namespace Geo.DAL.repositories.implementation
{
    public class GeologistsRepository : IGeologistsRepository
    {
        private readonly GeoDBContext _dbContext;

        public GeologistsRepository(GeoDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ObservableCollection<Geologist> GetAll() =>
            new ObservableCollection<Geologist>
            (
                _dbContext.Geologists
                    .Include(g=>g.Expeditions)
            );

        public Geologist? GetOneById(int id) =>
            _dbContext.Geologists
                .Where(e => e.Id == id)
                .Include(g => g.Expeditions)
                .FirstOrDefault();

        public void Create(Geologist geologist)
        {
            _dbContext.Geologists.Add(geologist);
            _dbContext.SaveChanges();
        }

        public void Update(Geologist geologist) 
        {
            _dbContext.Geologists.Update(geologist);
            _dbContext.SaveChanges(); 
        }

        public void Remove(Geologist geologist) {
            _dbContext.Geologists.Remove(geologist);
            _dbContext.SaveChanges(); 
        }
    }
}
