using Geo.DAL.context;
using Geo.DAL.repositories.interfaces;
using Geo.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

namespace Geo.DAL.repositories.implementation
{
    public class RoutesRepository : IRoutesRepository
    {
        private readonly GeoDBContext _dbContext;

        public RoutesRepository(GeoDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ICollection<Route> GetAll() =>
            new ObservableCollection<Route>
            (
                _dbContext.Routes
                    .Include(r=>r.Expeditions)
                    .Include(r=>r.Maps)
                    .Include(r=>r.Regions)
            );

        public Route? GetOneById(int id) =>
            _dbContext.Routes
                .Where(e => e.Id == id)
                .Include(r => r.Expeditions)
                .Include(r => r.Maps)
                .Include(r => r.Regions)
                .FirstOrDefault();

        public void Create(Route route) =>
            _dbContext.Routes.Add(route);

        public void Update(Route route) =>
            _dbContext.Routes.Update(route);

        public void Remove(Route route) =>
            _dbContext.Routes.Remove(route);
    }
}
