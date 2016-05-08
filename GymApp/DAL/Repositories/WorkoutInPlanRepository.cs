﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using Domain;

namespace DAL.Repositories
{
    public class WorkoutInPlanRepository : EFRepository<WorkoutInPlan>, IWorkoutInPlanRepository
    {
        public WorkoutInPlanRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}
