using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GardenNote.Models;
using GardenNote.Services;
using Microsoft.AspNet.Identity;

namespace GardenNote.Web.Controllers
{
    [Authorize]
    public class NoteController : Controller
    {
        // GET: Note
        public ActionResult Index()
        {
            //temp data was -- var model = new NoteListItem[0];  return View(model);}  -- replaced with what is below

            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new NoteService(userId);
            var model = service.GetNotes();

            return View(model);
        }
        
        public ActionResult Create()
        {
            return View();
        
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NoteCreate model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }
                var userId = Guid.Parse(User.Identity.GetUserId());
                        var service = new NoteService(userId);
                        service.CreateNote(model);

                        return RedirectToAction("Index");

        }

    }
}
