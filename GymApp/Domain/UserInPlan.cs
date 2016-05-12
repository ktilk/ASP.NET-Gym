using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Identity;

namespace Domain
{
    public class UserInPlan : BaseEntity
    {
        [Key]
        [Display(ResourceType = typeof(Resources.Domain), Name = "EntityPrimaryKey")]
        public int UserInPlanId { get; set; }

        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public virtual UserInt User { get; set; }

        public int PlanId { get; set; }
        public virtual Plan Plan { get; set; }

        public int UserRoleInPlanId { get; set; }
        public virtual UserRoleInPlan UserRoleInPlan { get; set; }
    }
}
