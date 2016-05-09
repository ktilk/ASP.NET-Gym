﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain;

namespace Web.Areas.Admin.ViewModels
{
    public class UserRoleInPlanCreateEditViewModel
    {
        public UserRoleInPlan UserRoleInPlan { get; set; }
        public string RoleName { get; set; }
    }

    public class UserRoleInPlanIndexViewModel
    {
        public List<UserRoleInPlan> UserRoleInPlans { get; set; } 
    }
}