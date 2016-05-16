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
    public class Plan : BaseEntity
    {
        [Key]
        [Display(ResourceType = typeof(Resources.Domain), Name = "EntityPrimaryKey")]
        public int PlanId { get; set; }

        [Display(Name = "PlanName", ResourceType = typeof(Resources.Domain))]
        public string PlanName { get; set; }

        public int? Rating { get; set; }

        [Display(Name = "PlanDescription", ResourceType = typeof(Resources.Domain))]
        [ForeignKey(nameof(PlanDescription))]
        public int? PlanDescriptionId { get; set; }
        public virtual MultiLangString PlanDescription { get; set; }

        [Display(Name = "PlanInstructions", ResourceType = typeof(Resources.Domain))]
        [ForeignKey(nameof(PlanInstructions))]
        public int? PlanInstructionsId { get; set; }
        public virtual MultiLangString PlanInstructions { get; set; }

        public int PlanTypeId { get; set; }
        public virtual PlanType PlanType { get; set; }

        [Display(Name = "PlanDuration", ResourceType = typeof(Resources.Domain))]
        public string Duration { get; set; }

        public virtual List<UserInPlan> UserInPlans { get; set; }
        public virtual List<WorkoutInPlan> WorkoutsInPlans { get; set; }
    }
}
