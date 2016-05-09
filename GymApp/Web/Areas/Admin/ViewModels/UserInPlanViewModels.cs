using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain;

namespace Web.Areas.Admin.ViewModels
{
    public class UserInPlanIndexViewModel
    {
        public List<UserInPlan> UserInPlans { get; set; }
    }
    public class UserInPlanCreateEditViewModel
    {
        public UserInPlan UserInPlan { get; set; }
        public SelectList UserSelectList { get; set; }
        public SelectList PlanSelectList { get; set; }
        public SelectList UserRoleInPlanSelectList { get; set; }
    }
}