using System.Web.Mvc;
using Domain;
using PagedList;

namespace Web.Areas.Admin.ViewModels
{
    public class ExerciseCreateEditViewModel
    {
        public Exercise Exercise { get; set; }
        public SelectList ExerciseTypeSelectList { get; set; }
    }

    public class ExerciseIndexViewModel
    {
        public IPagedList<Exercise> Exercises { get; set; }
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
        public string SortProperty { get; set; }
        public string Filter { get; set; }
    }
}