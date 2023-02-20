using Geo.DAL.context;
using Geo.DAL.repositories.interfaces;
using Geo.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

namespace Geo.DAL.repositories.implementation
{
    public class MapsRepository : IMapsRepository
    {
        private readonly GeoDBContext _dbContext;

        public MapsRepository(GeoDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ObservableCollection<Map> GetAll() =>
            new ObservableCollection<Map>
            (
                _dbContext.Maps
                    .Include(m => m.Routes)
                    .Include(m => m.Region)
            );

        public Map? GetOneById(int id) =>
            _dbContext.Maps
                .Where(e => e.Id == id)
                .Include(m => m.Routes)
                .Include(m => m.Region)
                .FirstOrDefault();

        public void Create(Map map)
        {
            _dbContext.Maps.Add(map);
            _dbContext.SaveChanges();
        }

        public void Update(Map map)
        {
            _dbContext.Maps.Update(map);
            _dbContext.SaveChanges();
        }

        public void Remove(Map map)
        {
            _dbContext.Maps.Remove(map);
            _dbContext.SaveChanges();
        }
        }
}
