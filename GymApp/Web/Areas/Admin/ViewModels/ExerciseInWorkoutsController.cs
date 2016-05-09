using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAL;
using DAL.Interfaces;
using Domain;
using Web.Areas.Admin.ViewModels;
using Web.Controllers;

namespace Web.Areas.Admin.Controllers
{
    public class ExerciseInWorkoutsController : BaseController
    {
        //private DataBaseContext db = new DataBaseContext();
        private readonly IUOW _uow;

        public ExerciseInWorkoutsController(IUOW uow)
        {
            _uow = uow;
        }

        // GET: Admin/ExerciseInWorkouts
        public ActionResult Index()
        {
            var vm = _uow.ExerciseInWorkouts.All;
            return View(vm);
        }

        // GET: Admin/ExerciseInWorkouts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExerciseInWorkout exerciseInWorkout = _uow.ExerciseInWorkouts.GetById(id);
            if (exerciseInWorkout == null)
            {
                return HttpNotFound();
            }
            return View(exerciseInWorkout);
        }

        // GET: Admin/ExerciseInWorkouts/Create
        public ActionResult Create()
        {
            var vm = new ExerciseInWorkoutCreateEditViewModel
            {
                ExerciseSelectList =
                    new SelectList(
                        _uow.Exercises.All.Select(x => new {x.ExerciseId, ExerciseName = x.ExerciseName}).ToList(),
                        nameof(Exercise.ExerciseId), nameof(Exercise.ExerciseName)),
                WorkoutSelectList =
                    new SelectList(
                        _uow.Workouts.All.Select(x => new {x.WorkoutId, WorkoutName = x.WorkoutName}).ToList(),
                        nameof(Workout.WorkoutId), nameof(Workout.WorkoutName))
            };
            return View(vm);
        }

        // POST: Admin/ExerciseInWorkouts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ExerciseInWorkoutCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _uow.ExerciseInWorkouts.Add(vm.ExerciseInWorkout);
                _uow.Commit();
                return RedirectToAction(nameof(Index));
            }

            return View(vm);
        }

        // GET: Admin/ExerciseInWorkouts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExerciseInWorkout exerciseInWorkout = _uow.ExerciseInWorkouts.GetById(id);
            if (exerciseInWorkout == null)
            {
                return HttpNotFound();
            }
            var vm = new ExerciseInWorkoutCreateEditViewModel()
            {
                ExerciseInWorkout = exerciseInWorkout
            };
            return View(vm);
        }

        // POST: Admin/ExerciseInWorkouts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ExerciseInWorkoutCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _uow.ExerciseInWorkouts.Update(vm.ExerciseInWorkout);
                _uow.Commit();
                return RedirectToAction(nameof(Index));
            }
            return View(vm);
        }

        // GET: Admin/ExerciseInWorkouts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExerciseInWorkout exerciseInWorkout = _uow.ExerciseInWorkouts.GetById(id);
            if (exerciseInWorkout == null)
            {
                return HttpNotFound();
            }
            return View(exerciseInWorkout);
        }

        // POST: Admin/ExerciseInWorkouts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _uow.ExerciseInWorkouts.Delete(id);
            _uow.Commit();
            return RedirectToAction(nameof(Index));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
            }
            base.Dispose(disposing);
        }
    }
}
