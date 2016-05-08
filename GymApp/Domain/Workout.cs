using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Workout : BaseEntity
    {
        public int WorkoutId { get; set; }

        [Required]
        [MaxLength(128, ErrorMessageResourceName = "WorkoutNameLengthError", ErrorMessageResourceType = typeof(Resources.Domain))]
        [MinLength(1, ErrorMessageResourceName = "WorkoutNameLengthError", ErrorMessageResourceType = typeof(Resources.Domain))]
        public string WorkoutName { get; set; }

        [DataType(DataType.Date)]
        public DateTime? Date { get; set; }

        [DataType(DataType.Time)]
        public DateTime? StartTime { get; set; }

        [DataType(DataType.Time)]
        public DateTime? EndTime { get; set; }

        public virtual List<WorkoutInPlan> WorkoutsInPlans{ get; set; }
        public virtual List<ExerciseInWorkout> ExercisesInWorkouts { get; set; }
    }
}
