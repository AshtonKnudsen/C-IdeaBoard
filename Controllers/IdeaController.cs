using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using CbeltRetake.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CbeltRetake.Controllers
{
    public class IdeaController : Controller
    {
        private IdeaContext dbContext;
     
        public IdeaController(IdeaContext context)
        {
            dbContext = context;
        }
        [HttpGet]
        [Route("allideas")]
        public IActionResult Allideas()
        {
            var userid = HttpContext.Session.GetInt32("Uid");
            User userinsession = dbContext.Users
                .FirstOrDefault(i => i.userid == userid);
            ViewBag.id =userid;
            ViewBag.name = userinsession.firstname;
            if( userid == null)
            {
                return RedirectToAction("Register", "LoginReg");
            }
            List<Idea> allideas = dbContext.Ideas
                .Include(i => i.myuser)
                .Include(i => i.likes)
                    .ThenInclude(i => i.user)
                    .OrderByDescending(i => i.likes.Count())
                .ToList();
            return View(allideas);
        }
        [HttpPost]
        [Route("ideaprocess")]
        public IActionResult Ideaprocess(string description)
        {
            if(description.Length < 1)
            {
                return RedirectToAction("Allideas");
            }
            Idea newidea = new Idea();
            var uid = HttpContext.Session.GetInt32("Uid");
            User userinsession = dbContext.Users
                .FirstOrDefault(i => i.userid == uid);
            newidea.description = description;
            newidea.myuser = userinsession;
            dbContext.Add(newidea);
            dbContext.SaveChanges();
            return RedirectToAction("Allideas");
        }
        
        [HttpGet]
        [Route("likeprocess/{ideaid}")]
        public IActionResult Likeprocess(int ideaid)
        {
            Like likethis = new Like();
            var uid = HttpContext.Session.GetInt32("Uid");
            Idea ideaobj = dbContext.Ideas.FirstOrDefault(i => i.ideaid == ideaid);
            User userobj = dbContext.Users.FirstOrDefault(i => i.userid == uid);
            likethis.userid = (int)uid;
            likethis.user = userobj;
            likethis.idea = ideaobj;
            likethis.ideaid = ideaid;
            dbContext.Add(likethis);
            dbContext.SaveChanges();
            return RedirectToAction("Allideas");
        }
        [HttpGet]
        [Route("removeidea/{ideaid}")]
        public IActionResult Remoeidea(int ideaid)
        {
            Idea thisidea = dbContext.Ideas.FirstOrDefault(i => i.ideaid == ideaid);
            dbContext.Ideas.Remove(thisidea);
            dbContext.SaveChanges();
            return RedirectToAction("Allideas");
        }
        [HttpGet]
        [Route("viewpost/{ideaid}")]
        public IActionResult Viewpost(int ideaid)
        {
            var userid = HttpContext.Session.GetInt32("Uid");
            if( userid == null)
            {
                return RedirectToAction("Register", "LoginReg");
            }
            var likes = dbContext.Ideas
                .Include(i => i.myuser)
                .Include(i => i.likes)
                    .ThenInclude(i => i.user)
                .FirstOrDefault(a => a.ideaid == ideaid);
            return View(likes);
        }
        [HttpGet]
        [Route("viewuser/{userid}")]
        public IActionResult Viewuser(int userid)
        {
            var user = HttpContext.Session.GetInt32("Uid");
            if( user == null)
            {
                return RedirectToAction("Register", "LoginReg");
            }
            var thisuser = dbContext.Users
                .Include(i => i.likes)
                .FirstOrDefault(i => i.userid == userid);

            List<Idea> ideas = dbContext.Ideas
                .Where(i => i.myuser.userid == userid)
                .ToList();
                
            ViewBag.count = ideas.Count();
            return View(thisuser);
        }

    }
}
