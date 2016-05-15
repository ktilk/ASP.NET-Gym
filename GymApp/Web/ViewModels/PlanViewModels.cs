using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain;
using Domain.Identity;

namespace Web.ViewModels
{
    public class PlanCreateEditViewModel
    {
        public Plan Plan { get; set; }
        public string PlanName { get; set; }
        public string PlanDescription { get; set; }
        public string PlanInstructions { get; set; }
        public SelectList PlanTypeSelectList { get; set; }
        public SelectList PlanSelectList { get; set; }

        public WorkoutInPlan WorkoutInPlan { get; set; }
        //public List<WorkoutInPlan> WorkoutInPlanList { get; set; }

        public Workout Workout { get; set; }
        public SelectList WorkoutSelectList { get; set; }

        public ExerciseInWorkout ExerciseInWorkout { get; set; }
        public List<ExerciseInWorkout> ExerciseInWorkoutList { get; set; }
        //public Exercise Exercise { get; set; }

        public SelectList ExerciseSelectList { get; set; }

        public UserInt User { get; set; }
        public UserInPlan UserInPlan { get; set; }
        public UserRoleInPlan UserRoleInPlan { get; set; }
    }

    public class PlanIndexViewModel
    {
        public List<Plan> Plans { get; set; }
    }
}