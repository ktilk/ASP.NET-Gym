using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain;

namespace Web.ViewModels
{
    public class WorkoutCreateEditViewModel
    {
        public Workout Workout { get; set; }
        public string WorkoutName { get; set; }
        public Exercise Exercise { get; set; }
        public SelectList ExercisesSelectList { get; set; }
        public SelectList PlansSelectList { get; set; }
    }

    public class WorkoutIndexViewModel
    {
        public List<Workout> Workouts { get; set; }
    }
}