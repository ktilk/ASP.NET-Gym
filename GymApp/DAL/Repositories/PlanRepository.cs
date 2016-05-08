using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using Domain;

namespace DAL.Repositories
{
    public class PlanRepository : EFRepository<Plan>, IPlanRepository
    {
        public PlanRepository(IDbContext dbContext) : base(dbContext)
        {
        }
        //public List<Plan> GetAllForUser(int userId)
        //{
        //    return DbSet.Where(p => p.Users. == userId).OrderBy(o => o.PlanDescription).Include(c => c.Workouts).ToList();
        //}
    }
}
