using BowlingLeague.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingLeague.Controllers
{
    public class HomeController : Controller
    {
        private BowlersDbContext _context { get; set; }
        public HomeController(BowlersDbContext temp)
        {
            _context = temp;
        }

        public IActionResult Index()
        {
            var blah = _context.Bowlers.ToList();
            //.FromSqlRaw("raw sql") and goes before.ToList();
            ViewBag.Bowling = blah;
            return View(blah);
        }
        public IActionResult Create()
        {
            _context.SaveChanges();
            return View("Create");
        }
        [HttpGet]
        public IActionResult Edit(int bowlerid)
        {
            var bowler = _context.Bowlers.Single(x => x.BowlerID == bowlerid);
            return View("Create", bowler);
        }
        [HttpPost]
        public IActionResult Edit(Bowler blah)
        {
            _context.Update(blah);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int bowlerid)
        {
            var bowler = _context.Bowlers.Single(x => x.BowlerID == bowlerid);
            return View(bowler);
        }
        [HttpPost]
        public IActionResult Delete(Bowler b1)
        {
            _context.Bowlers.Remove(b1);
            _context.SaveChanges();
            return View("Index");
        }
    }
}
