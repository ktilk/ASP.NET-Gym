using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain;

namespace Web.Areas.Admin.ViewModels
{
    public class WorkoutInPlanIndexViewModel
    {
        public List<WorkoutInPlan> WorkoutInPlans { get; set; }
    }

    public class WorkoutInPlanCreateEditViewModel
    {
        public WorkoutInPlan WorkoutInPlan { get; set; }
        public SelectList PlanSelectList { get; set; }
        public SelectList WorkoutSelectList { get; set; }
    }
}