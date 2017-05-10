using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GardenNote.Models;

namespace GardenNote.Web.Controllers
{
    [Authorize]
    public class NoteController : Controller
    {
        // GET: Note
        public ActionResult Index()
        {
            //temp data
            var model = new NoteListItem[0];
            return View(model);
        }
    }
}