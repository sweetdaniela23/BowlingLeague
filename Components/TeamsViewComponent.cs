using BowlingLeague.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingLeague.Components
{
    public class TeamsViewComponent : ViewComponent
    {
        private BowlersDbContext _context { get; set; }
        public TeamsViewComponent (BowlersDbContext temp)
        {
            _context = temp;
        }
        public IViewComponentResult Invoke()
        {
            var teams = _context.Bowlers
                .Select(x => x.TeamID)
                .Distinct()
                .OrderBy(x => x);

            return View(teams);
        }
    }
}
