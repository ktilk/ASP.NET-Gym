using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace DAL.Interfaces
{
    public interface IPlanRepository : IEFRepository<Plan>
    {
        /// <summary>
        /// Get all Plans for this user id
        /// </summary>
        /// <param name="userId">user ID to filter by</param>
        /// <returns>List of plans, belonging to this user id</returns>
        //List<Plan> GetAllForUser(int userId);
    }
}
