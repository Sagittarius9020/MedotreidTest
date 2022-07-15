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
    public class ClientController : Controller
    {
        ClientDb db = new ClientDb();

        // GET: Client
        public ActionResult Index()
        {
            return View(db.GetClient().ToList());
        }

        // GET: Client/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Client/Create
        [HttpPost]
        public ActionResult Create(ClientViewModels model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Client client = new Client
                    {
                        Surname = model.Surname,
                        Name = model.Name,
                        SecondName = model.SecondName
                    };

                    db.AddClient(client);
                }

                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}
