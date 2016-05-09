using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class UserRoleInPlan : BaseEntity
    {
        public int UserRoleInPlanId { get; set; }

        [ForeignKey(nameof(RoleName))]
        public int? RoleNameId { get; set; }
        public virtual MultiLangString RoleName { get; set; }

        public virtual List<UserInPlan> UserInPlans { get; set; }
    }
}
