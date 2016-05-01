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
using Web.ViewModels;

namespace Web.Controllers
{
    public class WorkoutsController : BaseController
    {
        //private DataBaseContext db = new DataBaseContext();
        private readonly IUOW _uow;

        public WorkoutsController(IUOW uow)
        {
            _uow = uow;
        }

        // GET: Workouts
        public ActionResult Index(WorkoutIndexViewModel vm)
        {
            vm.Workouts = _uow.Workouts.All.Where(w => w.Tracked == false).ToList();
            return View(vm);
        }

        // GET: Workouts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Workout workout = _uow.Workouts.GetById(id);
            if (workout == null)
            {
                return HttpNotFound();
            }
            return View(workout);
        }

        // GET: Workouts/Create
        public ActionResult Create()
        {
            var vm = new WorkoutCreateEditViewModel();
            vm.PlansSelectList = new SelectList(_uow.Plans.All.Select(p => new {p.PlanId, PlanName = p.PlanName.Value}).ToList(), nameof(Plan.PlanId), nameof(Plan.PlanName));
            vm.ExercisesSelectList = new SelectList(_uow.Exercises.All.Select(p => new { p.ExerciseId, ExerciseName = p.ExerciseName }).ToList(), nameof(Exercise.ExerciseId), nameof(Exercise.ExerciseName));
            return View(vm);
        }

        // POST: Workouts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(WorkoutCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                vm.Workout.Tracked = false; // this workout row is not tracked, but created(new trackable workout)
                _uow.Workouts.Add(vm.Workout);
                _uow.Commit();
                return RedirectToAction(nameof(Index));
            }

            vm.PlansSelectList = new SelectList(_uow.Plans.All.Select(p => new { p.PlanId, PlanName = p.PlanName.Value }).ToList(), nameof(Plan.PlanId), nameof(Plan.PlanName), vm.Workout.PlanId);
            vm.ExercisesSelectList = new SelectList(_uow.Exercises.All.Select(p => new { p.ExerciseId, ExerciseName = p.ExerciseName }).ToList(), nameof(Exercise.ExerciseId), nameof(Exercise.ExerciseName), vm.Exercise.ExerciseId);

            return View(vm);
        }

        // GET: Workouts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Workout workout = _uow.Workouts.GetById(id);
            if (workout == null)
            {
                return HttpNotFound();
            }
            var vm = new WorkoutCreateEditViewModel {Workout = workout};
            vm.PlansSelectList = new SelectList(_uow.Plans.All.Select(p => new { p.PlanId, PlanName = p.PlanName.Value }).ToList(), nameof(Plan.PlanId), nameof(Plan.PlanName), vm.Workout.PlanId);
            return View(vm);
        }

        // POST: Workouts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(WorkoutCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _uow.Workouts.Update(vm.Workout);
                _uow.Commit();
                return RedirectToAction(nameof(Index));
            }
            vm.PlansSelectList = new SelectList(_uow.Plans.All.Select(p => new { p.PlanId, PlanName = p.PlanName.Value }).ToList(), nameof(Plan.PlanId), nameof(Plan.PlanName), vm.Workout.PlanId);
            return View(vm);
        }

        // GET: Workouts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Workout workout = _uow.Workouts.GetById(id);
            if (workout == null)
            {
                return HttpNotFound();
            }
            return View(workout);
        }

        // POST: Workouts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _uow.Workouts.Delete(id);
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
