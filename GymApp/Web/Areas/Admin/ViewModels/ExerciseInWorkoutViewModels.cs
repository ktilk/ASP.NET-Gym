using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain;

namespace Web.Areas.Admin.ViewModels
{
    public class ExerciseInWorkoutIndexViewModel
    {
        public List<ExerciseInWorkout> ExerciseInWorkouts { get; set; }
    }
    public class ExerciseInWorkoutCreateEditViewModel
    {
        public ExerciseInWorkout ExerciseInWorkout { get; set; }
        public SelectList ExerciseSelectList { get; set; }
        public SelectList WorkoutSelectList { get; set; }
    }
}