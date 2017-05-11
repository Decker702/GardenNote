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

            if (!ModelState.IsValid) return View(model);
            
            var service = CreateNoteService();

            if (service.CreateNote(model))
            {
                //Use TempData to store data in the session.  When you read data from there, it removes it from the session.

                TempData["SaveResult"] = "Your note was created.";
                  return RedirectToAction("Index");
            };

            
            //Overload with two strings.  Custom message.
            ModelState.AddModelError("", "Note could not be created.");

            //If it fails, we go back to the model
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var service = CreateNoteService();
            var model = service.GetNoteById(id);

            return View(model);
        }

        public ActionResult Edit (int id)
        {
            var service = CreateNoteService();
             var detail = service.GetNoteById(id);
            var model =
                new NoteEdit
                {
                    NoteId = detail.NoteId,
                    Title = detail.Title,
                    Content = detail.Content,
                    Content1 = detail.Content1
                };

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, NoteEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.NoteId != id)
            {
                ModelState.AddModelError("", "Id is a Mismatch");
                return View(model);
            }

            var service = CreateNoteService();

            if (service.UpdateNote(model))
            {
                TempData["SaveResult"] = "Your note was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your note was not updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete (int id)
        {
            var svc = CreateNoteService();
            var model = svc.GetNoteById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateNoteService();

            service.DeleteNote(id);

            TempData["SaveResult"] = "Your note was deleted";

            return RedirectToAction("Index");
        }


            /*
                  if(model.NoteId != id)
                  {
                      ModelState.AddModelError("", "Id is a Mismatch");
                      return View(model);
                  }



                             var detail = service.GetNoteById(id);
                             var model =
                                 new NoteEdit
                                 {
                                     NoteId = detail.NoteId,
                                     Title = detail.Title,
                                     Content = detail.Content,
                                     Content1 = detail.Content1
                                 };


                  return View();
              }
              */

            private NoteService CreateNoteService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new NoteService(userId);
            return service;
        }
    }
}

