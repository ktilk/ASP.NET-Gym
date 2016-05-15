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
using Microsoft.AspNet.Identity;
using Web.Helpers;
using Web.ViewModels;

namespace Web.Controllers
{
    [Authorize]
    public class PlansController : BaseController
    {
        private readonly IUOW _uow;

        public PlansController(IUOW uow)
        {
            _uow = uow;
        }

        // GET: Plans
        public ActionResult Index()
        {
            //var plans = _uow.Plans.All;
            var vm = (from p in _uow.Plans.AllIncluding())
            return View(plans);
        }

        // GET: Plans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plan plan = _uow.Plans.GetById(id);
            if (plan == null)
            {
                return HttpNotFound();
            }
            return View(plan);
        }

        // GET: Plans/Create
        public ActionResult Create()
        {
            var vm = new PlanCreateEditViewModel();
            vm.PlanTypeSelectList = new SelectList(_uow.PlanTypes.All.Select(p => new { p.PlanTypeId, PlanTypeName = p.PlanTypeName.Translate() }).ToList(), nameof(PlanType.PlanTypeId), nameof(PlanType.PlanTypeName));
            vm.ExerciseSelectList = new SelectList(_uow.Exercises.All, nameof(Exercise.ExerciseId), nameof(Exercise.ExerciseName));
            vm.ExerciseInWorkoutList = new List<ExerciseInWorkout>();
            return View(vm);
        }

        // POST: Plans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PlanCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                if (vm.Plan == null) vm.Plan = new Plan();
                if (vm.UserInPlan == null) vm.UserInPlan = new UserInPlan();
                if (vm.WorkoutInPlan == null) vm.WorkoutInPlan = new WorkoutInPlan();
                if (vm.Workout == null) vm.Workout = new Workout();
                if (vm.ExerciseInWorkout == null) vm.ExerciseInWorkout = new ExerciseInWorkout();
                //if (vm.ExerciseInWorkoutList == null) vm.ExerciseInWorkoutList = new List<ExerciseInWorkout>();


                vm.Plan.PlanDescription = new MultiLangString(vm.PlanDescription, CultureHelper.GetCurrentNeutralUICulture(), vm.PlanDescription, nameof(vm.Plan) + "." + vm.Plan.PlanId + "." + nameof(vm.Plan.PlanDescription));
                vm.Plan.PlanInstructions = new MultiLangString(vm.PlanInstructions, CultureHelper.GetCurrentNeutralUICulture(), vm.PlanInstructions, nameof(vm.Plan) + "." + vm.Plan.PlanId + "." + nameof(vm.Plan.PlanInstructions));

                _uow.Plans.Add(vm.Plan);
                vm.UserInPlan.Plan = vm.Plan;
                vm.UserInPlan.UserId = User.Identity.GetUserId<int>();
                vm.UserInPlan.UserRoleInPlanId = 4; //katsetamisel jäänud hard coded 4, võib hiljem viga põhjustada 
                _uow.UserInPlans.Add(vm.UserInPlan);

                _uow.Workouts.Add(vm.Workout);

                vm.WorkoutInPlan.Plan = vm.Plan;
                vm.WorkoutInPlan.Workout = vm.Workout;
                _uow.WorkoutInPlans.Add(vm.WorkoutInPlan);

                foreach (var ex in vm.ExerciseInWorkoutList)
                {
                    vm.ExerciseInWorkout = new ExerciseInWorkout();
                    vm.ExerciseInWorkout.Workout = vm.Workout;
                    vm.ExerciseInWorkout.ExerciseId = ex.ExerciseId;
                    vm.ExerciseInWorkout.Sets = ex.Sets;
                    vm.ExerciseInWorkout.Tracked = false;
                    _uow.ExerciseInWorkouts.Add(vm.ExerciseInWorkout);
                }

                _uow.Commit();

                return RedirectToAction(nameof(Index));
            }
            //vm.PlanTypeSelectList = new SelectList(_uow.PlanTypes.All.Select(p => new { p.PlanTypeId, PlanTypeName = p.PlanTypeName.Translate() }).ToList(), nameof(PlanType.PlanTypeId), nameof(PlanType.PlanTypeName));
            //vm.ExerciseSelectList = new SelectList(_uow.Exercises.All, nameof(Exercise.ExerciseId), nameof(Exercise.ExerciseName));
            return View(vm);
        }

        // GET: Plans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plan plan = _uow.Plans.GetById(id);
            if (plan == null)
            {
                return HttpNotFound();
            }
            var vm = new PlanCreateEditViewModel();
            vm.Plan = plan;
            vm.PlanName = plan.PlanName;
            vm.PlanDescription = plan.PlanDescription.Translate();
            vm.PlanInstructions = plan.PlanInstructions.Translate();
            vm.PlanTypeSelectList = new SelectList(_uow.PlanTypes.All.Select(p => new { p.PlanTypeId, PlanTypeName = p.PlanTypeName.Translate() }).ToList(), nameof(PlanType.PlanTypeId), nameof(PlanType.PlanTypeName));
            return View(vm);
        }

        // POST: Plans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PlanCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                vm.Plan.PlanDescription = _uow.MultiLangStrings.GetById(vm.Plan.PlanDescriptionId);
                vm.Plan.PlanDescription.SetTranslation(vm.PlanDescription, CultureHelper.GetCurrentNeutralUICulture(),
    nameof(vm.Plan) + "." + vm.Plan.PlanId + "." + nameof(vm.Plan.PlanDescription));

                vm.Plan.PlanInstructions = _uow.MultiLangStrings.GetById(vm.Plan.PlanInstructionsId);
                vm.Plan.PlanInstructions.SetTranslation(vm.PlanInstructions, CultureHelper.GetCurrentNeutralUICulture(),
    nameof(vm.Plan) + "." + vm.Plan.PlanId + "." + nameof(vm.Plan.PlanInstructions));

                _uow.Plans.Update(vm.Plan);
                _uow.Commit();
                return RedirectToAction(nameof(Index));
            }

            return View(vm);
        }

        // GET: Plans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plan plan = _uow.Plans.GetById(id);
            if (plan == null)
            {
                return HttpNotFound();
            }
            return View(plan);
        }

        // POST: Plans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _uow.Plans.Delete(id);
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
