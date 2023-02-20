using Geo.DAL.context;
using Geo.DAL.repositories.interfaces;
using Geo.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

namespace Geo.DAL.repositories.implementation
{
    public class RegionsRepository : IRegionsRepository
    {
        private readonly GeoDBContext _dbContext;

        public RegionsRepository(GeoDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ObservableCollection<Region> GetAll() =>
            new ObservableCollection<Region>
            (
                _dbContext.Regions
                    .Include(r=>r.Maps)
                    .Include(r=>r.Routes)
            );

        public Region? GetOneById(int id) =>
            _dbContext.Regions
                .Where(e => e.Id == id)
                .Include(r => r.Maps)
                .Include(r => r.Routes)
                .FirstOrDefault();

        public void Create(Region region)
        {
            _dbContext.Regions.Add(region);
            _dbContext.SaveChanges();
        }

        public void Update(Region region)
        {
            _dbContext.Regions.Update(region);
            _dbContext.SaveChanges();
        }

        public void Remove(Region region)
        {
            _dbContext.Regions.Remove(region);
            _dbContext.SaveChanges();
        }
        }
}
