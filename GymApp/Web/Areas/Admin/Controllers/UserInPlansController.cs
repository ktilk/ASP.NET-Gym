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
using Domain.Identity;
using Web.Areas.Admin.ViewModels;
using Web.Controllers;

namespace Web.Areas.Admin.Controllers
{
    public class UserInPlansController : BaseController
    {
        //private DataBaseContext db = new DataBaseContext();
        private readonly IUOW _uow;

        public UserInPlansController(IUOW uow)
        {
            _uow = uow;
        }

        // GET: Admin/UserInPlans
        public ActionResult Index(UserInPlanIndexViewModel vm)
        {
            vm.UserInPlans = _uow.UserInPlans.All;
            return View(vm);
        }

        // GET: Admin/UserInPlans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserInPlan userInPlan = _uow.UserInPlans.GetById(id);
            if (userInPlan == null)
            {
                return HttpNotFound();
            }
            return View(userInPlan);
        }

        // GET: Admin/UserInPlans/Create
        public ActionResult Create()
        {
            var vm = new UserInPlanCreateEditViewModel();
            //vm.UserSelectList = new SelectList(_uow.UsersInt.All, nameof(UserInt.Id), nameof(UserInt.Email));
            vm.UserSelectList = new SelectList(_uow.UsersInt.All, nameof(UserInt.Id), nameof(UserInt.UserName));

            vm.PlanSelectList = new SelectList(_uow.Plans.All, nameof(Plan.PlanId), nameof(Plan.PlanName));
            vm.UserRoleInPlanSelectList = new SelectList(_uow.UserRoleInPlans.All, nameof(UserRoleInPlan.UserRoleInPlanId), nameof(UserRoleInPlan.RoleName));
            return View(vm);
        }

        // POST: Admin/UserInPlans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserInPlanCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _uow.UserInPlans.Add(vm.UserInPlan);
                _uow.Commit();
                return RedirectToAction(nameof(Index));
            }

            return View(vm);
        }

        // GET: Admin/UserInPlans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserInPlan userInPlan = _uow.UserInPlans.GetById(id);
            if (userInPlan == null)
            {
                return HttpNotFound();
            }
            var vm = new UserInPlanCreateEditViewModel();
            vm.UserInPlan = userInPlan;
            vm.PlanSelectList = new SelectList(_uow.Plans.All, nameof(Plan.PlanId), nameof(Plan.PlanName));
            vm.UserSelectList = new SelectList(_uow.UsersInt.All, nameof(Domain.Identity.User.Id), nameof(Domain.Identity.User.UserName));
            vm.UserRoleInPlanSelectList = new SelectList(_uow.UserRoleInPlans.All, nameof(UserRoleInPlan.UserRoleInPlanId), nameof(UserRoleInPlan.RoleName));
            return View(vm);
        }

        // POST: Admin/UserInPlans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserInPlanCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _uow.UserInPlans.Update(vm.UserInPlan);
                _uow.Commit();
                return RedirectToAction(nameof(Index));
            }
            return View(vm);
        }

        // GET: Admin/UserInPlans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserInPlan userInPlan = _uow.UserInPlans.GetById(id);
            if (userInPlan == null)
            {
                return HttpNotFound();
            }
            return View(userInPlan);
        }

        // POST: Admin/UserInPlans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _uow.UserInPlans.Delete(id);
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
