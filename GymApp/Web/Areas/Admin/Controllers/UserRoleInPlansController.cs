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
using Web.Helpers;

namespace Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserRoleInPlansController : BaseController
    {
        //private DataBaseContext db = new DataBaseContext();
        private readonly IUOW _uow;

        public UserRoleInPlansController(IUOW uow)
        {
            _uow = uow;
        }

        // GET: Admin/UserRoleInPlans
        public ActionResult Index()
        {
            var vm = _uow.UserRoleInPlans.All;
            return View(vm);
        }

        // GET: Admin/UserRoleInPlans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserRoleInPlan userRoleInPlan = _uow.UserRoleInPlans.GetById(id);
            if (userRoleInPlan == null)
            {
                return HttpNotFound();
            }
            return View(userRoleInPlan);
        }

        // GET: Admin/UserRoleInPlans/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/UserRoleInPlans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserRoleInPlanCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                if (vm.UserRoleInPlan == null) vm.UserRoleInPlan = new UserRoleInPlan();

                vm.UserRoleInPlan.RoleName = new MultiLangString(vm.RoleName,
                    CultureHelper.GetCurrentNeutralUICulture(), vm.RoleName,
                    nameof(vm.UserRoleInPlan) + "." + vm.UserRoleInPlan.UserRoleInPlanId + "." + nameof(vm.UserRoleInPlan.RoleName));
                _uow.UserRoleInPlans.Add(vm.UserRoleInPlan);
                _uow.Commit();
                return RedirectToAction(nameof(Index));
            }

            return View(vm);
        }

        // GET: Admin/UserRoleInPlans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserRoleInPlan userRoleInPlan = _uow.UserRoleInPlans.GetById(id);
            if (userRoleInPlan == null)
            {
                return HttpNotFound();
            }
            var vm = new UserRoleInPlanCreateEditViewModel()
            {
                UserRoleInPlan = userRoleInPlan,
                RoleName = userRoleInPlan.RoleName.Translate()
            };
            return View(vm);
        }

        // POST: Admin/UserRoleInPlans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserRoleInPlanCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                vm.UserRoleInPlan.RoleName = _uow.MultiLangStrings.GetById(vm.UserRoleInPlan.UserRoleInPlanId);
                vm.UserRoleInPlan.RoleName.SetTranslation(vm.RoleName, CultureHelper.GetCurrentNeutralUICulture(),
                    nameof(vm.UserRoleInPlan) + "." + vm.UserRoleInPlan.UserRoleInPlanId + "." + nameof(vm.UserRoleInPlan.RoleName));
                _uow.UserRoleInPlans.Update(vm.UserRoleInPlan);
                _uow.Commit();
                return RedirectToAction(nameof(Index));
            }
            return View(vm);
        }

        // GET: Admin/UserRoleInPlans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserRoleInPlan userRoleInPlan = _uow.UserRoleInPlans.GetById(id);
            if (userRoleInPlan == null)
            {
                return HttpNotFound();
            }
            return View(userRoleInPlan);
        }

        // POST: Admin/UserRoleInPlans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _uow.UserRoleInPlans.Delete(id);
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
