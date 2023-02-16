using Geo.DAL.context;
using Geo.DAL.repositories.interfaces;
using Geo.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

namespace Geo.DAL.repositories.implementation
{
    public class ExpeditionsRepository : IExpeditionsRepository
    {
        private readonly GeoDBContext _dbContext;

        public ExpeditionsRepository(GeoDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ICollection<Expedition> GetAll() =>
            new ObservableCollection<Expedition>
            (
                _dbContext.Expeditions
                    .Include(e => e.Geologists)
                    .Include(e => e.Route)
            );

        public Expedition? GetOneById(int id) =>
            _dbContext.Expeditions
                .Where(e => e.Id == id)
                .Include(e => e.Geologists)
                .Include(e => e.Route)
                .FirstOrDefault();

        public void Create(Expedition expedition) =>
            _dbContext.Expeditions.Add(expedition);

        public void Update(Expedition expedition) =>
            _dbContext.Expeditions.Update(expedition);

        public void Remove(Expedition expedition)=>
            _dbContext.Expeditions.Remove(expedition);
        
    }
}
