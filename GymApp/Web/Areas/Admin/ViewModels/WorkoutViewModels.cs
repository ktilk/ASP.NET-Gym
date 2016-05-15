using System.Collections.Generic;
using Domain;

namespace Web.Areas.Admin.ViewModels
{
    public class WorkoutCreateEditViewModel
    {
        public Workout Workout { get; set; }
    }

    public class WorkoutIndexViewModel
    {
        public List<Workout> Workouts { get; set; }
    }
}