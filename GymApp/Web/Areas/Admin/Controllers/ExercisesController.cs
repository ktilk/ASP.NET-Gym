﻿using System;
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
using PagedList;
using Web.Areas.Admin.ViewModels;
using Web.Controllers;
using Web.ViewModels;

namespace Web.Areas.Admin.Controllers
{
    [Authorize]
    public class ExercisesController : BaseController
    {
        private readonly IUOW _uow;

        public ExercisesController(IUOW uow)
        {
            _uow = uow;
        }

        // GET: Exercises
        public ActionResult Index(ExerciseIndexViewModel vm)
        {
            int totalExerciseCount;
            string realSortProperty;

            //if not set, set base values
            vm.PageNumber = vm.PageNumber ?? 1;
            vm.PageSize = vm.PageSize ?? 25;

            var res = _uow.Exercises.GetAllWithFilter(vm.Filter, vm.SortProperty, vm.PageNumber.Value-1, vm.PageSize.Value, out totalExerciseCount, out realSortProperty);
            //var res = _uow.Exercises.All;

            vm.SortProperty = realSortProperty;

            vm.Exercises = new StaticPagedList<Exercise>(res, vm.PageNumber.Value, vm.PageSize.Value, totalExerciseCount);
            //var exercises = db.Exercises.Include(e => e.ExerciseType);
            return View(vm);
        }

        // GET: Exercises/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exercise exercise = _uow.Exercises.GetById(id);
            if (exercise == null)
            {
                return HttpNotFound();
            }
            return View(exercise);
        }

        // GET: Exercises/Create
        public ActionResult Create()
        {
            var vm = new ExerciseCreateEditViewModel();
            vm.ExerciseTypeSelectList = new SelectList(_uow.ExerciseTypes.All.Select(e => new {e.ExerciseTypeId, ExerciseTypeName = e.ExerciseTypeName.Translate()}).ToList(), nameof(ExerciseType.ExerciseTypeId), nameof(ExerciseType.ExerciseTypeName));
            return View(vm);
        }

        // POST: Exercises/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ExerciseCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _uow.Exercises.Add(vm.Exercise);
                _uow.Commit();
                return RedirectToAction(nameof(Index));
            }
            vm.ExerciseTypeSelectList = new SelectList(_uow.ExerciseTypes.All.Select(e => new { e.ExerciseTypeId, ExerciseTypeName = e.ExerciseTypeName.Translate() }).ToList(), nameof(ExerciseType.ExerciseTypeId), nameof(ExerciseType.ExerciseTypeName), vm.Exercise.ExerciseTypeId);
            return View(vm);
        }

        // GET: Exercises/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var exercise = _uow.Exercises.GetById(id);
            if (exercise == null)
            {
                return HttpNotFound();
            }
            var vm = new ExerciseCreateEditViewModel();
            vm.Exercise = exercise;
            vm.ExerciseTypeSelectList = new SelectList(_uow.ExerciseTypes.All.Select(e => new { e.ExerciseTypeId, ExerciseTypeName = e.ExerciseTypeName.Translate() }).ToList(), nameof(ExerciseType.ExerciseTypeId), nameof(ExerciseType.ExerciseTypeName), vm.Exercise.ExerciseTypeId);

            return View(vm);
        }

        // POST: Exercises/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ExerciseCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _uow.Exercises.Update(vm.Exercise);
                _uow.Commit();
                return RedirectToAction(nameof(Index));
            }
            vm.ExerciseTypeSelectList = new SelectList(_uow.ExerciseTypes.All.Select(e => new { e.ExerciseTypeId, ExerciseTypeName = e.ExerciseTypeName.Translate() }).ToList(), nameof(ExerciseType.ExerciseTypeId), nameof(ExerciseType.ExerciseTypeName), vm.Exercise.ExerciseTypeId);

            return View(vm);
        }

        // GET: Exercises/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exercise exercise = _uow.Exercises.GetById(id);
            if (exercise == null)
            {
                return HttpNotFound();
            }
            return View(exercise);
        }

        // POST: Exercises/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _uow.Exercises.Delete(id);
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
