using MedotreidTest.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data;
using MedotreidTest.ViewModels;

namespace MedotreidTest.Controllers
{
    public class BookController : Controller
    {
        BookDb db = new BookDb();
        
        // GET: Book
        public ActionResult Index()
        {
            return View(db.GetBooks().ToList());
        }


        // GET: Book/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Book/Create
        [HttpPost]
        public ActionResult Create(BookViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Book book = new Book
                    {
                        Name = model.Name,
                        Author = model.Author,
                        About = model.About
                    };

                    db.AddBook(book);
                }

                    // TODO: Add insert logic here

                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Edit/5
        public ActionResult Edit(int id)
        {
            Book book = db.Book(id);

            if (book == null)
            {
                return HttpNotFound();
            }
            Debug.WriteLine(book.Author);
            BookViewModel bookView = new BookViewModel
            {
                Id = book.Id,
                Name = book.Name,
                Author = book.Author,
                About = book.About
            };
            Debug.WriteLine(bookView.Author);
            return View(bookView);
        }

        // POST: Book/Edit/5
        [HttpPost]
        public ActionResult Edit(BookViewModel model)
        {
            try
            {
                Book book = db.Book(model.Id);

                if (model.Name != book.Name)
                {
                    book.Name = model.Name;
                }

                if (model.Author != book.Author)
                {
                    book.Author = model.Author;
                }

                if (model.About != book.About)
                {
                    book.About = model.About;
                }
                Debug.WriteLine(model.Author);

                db.UpdateBook(book);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}
