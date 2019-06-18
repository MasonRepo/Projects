using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DotNetProject.Data.Repo;
using DotNetProject.Domain.Models;

namespace DotNetProject.Controllers
{
    public class OrderController : Controller
    {
        private OrdersContext db = new OrdersContext();
        private FullOrderVM vm = new FullOrderVM();

        // GET: Order
        public ActionResult Index()
        {
            vm.order = db.Orders.ToList();
            vm.contact = db.Contacts.ToList();

            return View(vm);
        }

        // GET: Order/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderModel orderModel = db.Orders.Find(id);
            if (orderModel == null)
            {
                return HttpNotFound();
            }
            return View(orderModel);
        }

        // GET: Order/Create
        public ActionResult Create(int? id)
        {

            if (id == null || id == 0)
            {
                CreationVM view = new CreationVM();
                view.contacts = db.Contacts.ToList();
                return View(view);
            }

            CreationVM contact = new CreationVM() ;
            contact.contact = db.Contacts.Find(id);

            return View(contact);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreationVM orderModel)
        {
            if (ModelState.IsValid)
            {
                db.Orders.Add(orderModel.order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(orderModel);
        }

        // GET: Order/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderModel orderModel = db.Orders.Find(id);
            if (orderModel == null)
            {
                return HttpNotFound();
            }
            return View(orderModel);
        }

        // POST: Order/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,OrderNumber,OrderDate,ContactID,OrderDescription,OrderAmount")] OrderModel orderModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(orderModel);
        }

        // GET: Order/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderModel orderModel = db.Orders.Find(id);
            if (orderModel == null)
            {
                return HttpNotFound();
            }
            return View(orderModel);
        }

        // POST: Order/Delete/5
        public ActionResult DeleteConfirmed(int id)
        {
            OrderModel orderModel = db.Orders.Find(id);
            db.Orders.Remove(orderModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Contacts()
        {
            return RedirectToAction("Index", "Contact");
        }


        [AllowAnonymous]
        public ActionResult AllOrders()
        {
            return Json(db.Orders.ToList(), JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
