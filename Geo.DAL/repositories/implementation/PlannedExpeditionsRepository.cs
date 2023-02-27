using Geo.DAL.context;
using Geo.DAL.repositories.interfaces;
using Geo.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geo.DAL.repositories.implementation
{
    public class PlannedExpeditionsRepository : IPlannedExpeditionsRepository
    {
        private readonly GeoDBContext _dbContext;

        public PlannedExpeditionsRepository(GeoDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ObservableCollection<PlannedExpedition> GetAll() =>
            new ObservableCollection<PlannedExpedition>
            (
                _dbContext.PlannedExpeditions.Include(ple=>ple.Route)
            );

        public PlannedExpedition? GetOneById(int id) =>
            _dbContext.PlannedExpeditions
                .Where(ple => ple.Id == id)
                .Include(ple => ple.Route)
                .FirstOrDefault();

        public void Create(PlannedExpedition plannedExpedition)
        {
            _dbContext.PlannedExpeditions.Add(plannedExpedition);
            _dbContext.SaveChanges();
        }

        public void Update(PlannedExpedition plannedExpedition)
        {
            _dbContext.PlannedExpeditions.Update(plannedExpedition);
            _dbContext.SaveChanges();
        }

        public void Remove(PlannedExpedition plannedExpedition)
        {
            _dbContext.PlannedExpeditions.Remove(plannedExpedition);
            _dbContext.SaveChanges();
        }
    }
}
