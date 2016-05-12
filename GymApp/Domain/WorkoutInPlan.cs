using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class WorkoutInPlan : BaseEntity
    {
        [Key]
        [Display(ResourceType = typeof(Resources.Domain), Name = "EntityPrimaryKey")]
        public int WorkoutInPlanId { get; set; }

        public int PlanId { get; set; }
        public virtual Plan Plan { get; set; }

        public int WorkoutId { get; set; }
        public virtual Workout Workout { get; set; }
    }
}
