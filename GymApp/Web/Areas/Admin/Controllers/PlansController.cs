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
using Web.Controllers;
using Web.Helpers;
using Web.ViewModels;

namespace Web.Areas.Admin.Controllers
{
    public class PlansController : BaseController
    {
        //private DataBaseContext db = new DataBaseContext();
        private readonly IUOW _uow;

        public PlansController(IUOW uow)
        {
            _uow = uow;
        }

        // GET: Plans
        public ActionResult Index(PlanIndexViewModel vm)
        {
            vm.Plans = _uow.Plans.All;
            return View(vm);
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
            vm.PlanTypeSelectList = new SelectList(_uow.PlanTypes.All.Select(p => new {p.PlanTypeId, PlanTypeName = p.PlanTypeName.Translate()}).ToList(), nameof(PlanType.PlanTypeId), nameof(PlanType.PlanTypeName));
            return View(vm);
        }

        // POST: Plans/Create
                // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
                // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
            [
            HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PlanCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                if (vm.Plan == null) vm.Plan = new Plan();

                vm.Plan.PlanDescription = new MultiLangString(vm.PlanDescription, CultureHelper.GetCurrentNeutralUICulture(), vm.PlanDescription, nameof(vm.Plan) + "." + vm.Plan.PlanId + "." + nameof(vm.Plan.PlanDescription));
                vm.Plan.PlanInstructions = new MultiLangString(vm.PlanInstructions, CultureHelper.GetCurrentNeutralUICulture(), vm.PlanInstructions, nameof(vm.Plan) + "." + vm.Plan.PlanId + "." + nameof(vm.Plan.PlanInstructions));

                _uow.Plans.Add(vm.Plan);
                _uow.Commit();
                return RedirectToAction(nameof(Index));
            }

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
            vm.PlanTypeSelectList = new SelectList(_uow.PlanTypes.All, nameof(PlanType.PlanTypeId), nameof(PlanType.PlanTypeName));
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
