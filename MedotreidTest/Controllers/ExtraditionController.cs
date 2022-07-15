using MedotreidTest.Models;
using MedotreidTest.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MedotreidTest.Controllers
{
    public class ExtraditionController : Controller
    {
        ExtraditionDb db = new ExtraditionDb();
        // GET: Extradition
        public ActionResult Index()
        {
            return View(db.GetExtradition().ToList());
        }

        // GET: Extradition/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Extradition/Create
        [HttpPost]
        public ActionResult Create(ExtraditionViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Extradition extradition = new Extradition
                    {
                        BookId = model.BookId,
                        ClientId = model.ClientId,
                        DateExtrdition = DateTime.Now
                    };


                    db.ExtraditionBook(extradition);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Extradition/Edit/5
        public ActionResult Edit(int id)
        {
            Extradition extradition = db.ExtraditionBook(id);
            
            if (extradition == null)
            {
                return HttpNotFound();
            }
            ExtraditionViewModel extraditionViewModel = new ExtraditionViewModel
            {
                Id = id,
                BookId = extradition.BookId,
                ClientId = extradition.ClientId
            };
            
            return View(extraditionViewModel);
        }

        // POST: Extradition/Edit/5
        [HttpPost]
        public ActionResult Edit(ExtraditionViewModel model)
        {
            try
            {
                Extradition extradition = db.ExtraditionBook(model.Id);

                extradition.DateReturn = DateTime.Now;

                db.ReturnBook(extradition);
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Extradition/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Extradition/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
