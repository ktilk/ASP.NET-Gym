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
    public class WorkoutInPlansController : BaseController
    {
        //private DataBaseContext db = new DataBaseContext();
        private readonly IUOW _uow;

        public WorkoutInPlansController(IUOW uow)
        {
            _uow = uow;
        }

        // GET: Admin/WorkoutInPlans
        public ActionResult Index(WorkoutInPlanIndexViewModel vm)
        {
            vm.WorkoutInPlans = _uow.WorkoutInPlans.All;
            return View(vm);
        }

        // GET: Admin/WorkoutInPlans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkoutInPlan workoutInPlan = _uow.WorkoutInPlans.GetById(id);
            if (workoutInPlan == null)
            {
                return HttpNotFound();
            }
            return View(workoutInPlan);
        }

        // GET: Admin/WorkoutInPlans/Create
        public ActionResult Create()
        {
            var vm = new WorkoutInPlanCreateEditViewModel();
            vm.PlanSelectList = new SelectList(_uow.Plans.All, nameof(Plan.PlanId), nameof(Plan.PlanName));
            vm.WorkoutSelectList = new SelectList(_uow.Workouts.All, nameof(Workout.WorkoutId), nameof(Workout.WorkoutName));
            return View(vm);
        }

        // POST: Admin/WorkoutInPlans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(WorkoutInPlanCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _uow.WorkoutInPlans.Add(vm.WorkoutInPlan);
                _uow.Commit();
                return RedirectToAction(nameof(Index));
            }

            return View(vm);
        }

        // GET: Admin/WorkoutInPlans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkoutInPlan workoutInPlan = _uow.WorkoutInPlans.GetById(id);
            if (workoutInPlan == null)
            {
                return HttpNotFound();
            }
            var vm = new WorkoutInPlanCreateEditViewModel();
            vm.WorkoutInPlan = workoutInPlan;
            vm.WorkoutSelectList = new SelectList(_uow.Workouts.All, nameof(Workout.WorkoutId), nameof(Workout.WorkoutName));
            vm.PlanSelectList = new SelectList(_uow.Plans.All, nameof(Plan.PlanId), nameof(Plan.PlanName));
            return View(vm);
        }

        // POST: Admin/WorkoutInPlans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(WorkoutInPlanCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _uow.WorkoutInPlans.Update(vm.WorkoutInPlan);
                _uow.Commit();
                return RedirectToAction(nameof(Index));
            }
            return View(vm);
        }

        // GET: Admin/WorkoutInPlans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkoutInPlan workoutInPlan = _uow.WorkoutInPlans.GetById(id);
            if (workoutInPlan == null)
            {
                return HttpNotFound();
            }
            return View(workoutInPlan);
        }

        // POST: Admin/WorkoutInPlans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _uow.WorkoutInPlans.Delete(id);
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
