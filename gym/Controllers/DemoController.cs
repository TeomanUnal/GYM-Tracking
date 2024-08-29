using gym.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace gym.Controllers
{
    [Authorize]//3.adım:

    public class DemoController : Controller
    {
        private readonly gymContext _context;

        public DemoController(gymContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IActionResult Index()
        {
            var memberships = _context.Memberships
                .Include(m => m.Member) // Member ilişkisini yükle
                .GroupBy(m => m.MembershipType)
                .Select(g => new MembershipViewModel
                {
                    MembershipId = g.First().MembershipId,
                    MembershipType = g.Key,
                    Members = g.Where(m => m.Member != null)
                               .Select(m => new MemberViewModel
                               {
                                   MemberId = m.Member.MemberId,
                                   FirstName = m.Member.FirstName
                               }).ToList()
                }).ToList();

            var model = new Cascade
            {
                MembershipList = memberships
            };

            return View(model);
        }
    }
}
