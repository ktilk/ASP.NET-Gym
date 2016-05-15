using System.Collections.Generic;
using System.Web.Mvc;
using Domain;

namespace Web.Areas.Admin.ViewModels
{
    public class PlanCreateEditViewModel
    {
        public Plan Plan { get; set; }
        public string PlanName { get; set; }
        public string PlanDescription { get; set; }
        public string PlanInstructions { get; set; }
        public SelectList PlanTypeSelectList { get; set; }
    }

    public class PlanIndexViewModel
    {
        public List<Plan> Plans { get; set; }
    }
}