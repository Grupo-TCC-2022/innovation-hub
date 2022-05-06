using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using innovation_hub.Data;
using innovation_hub.Models;
using innovation_hub.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace innovation_hub.Controllers
{
    public class FeedController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataContext _context;

        public FeedController(ILogger<HomeController> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,AgeRestriction,Finished,Arquived,CreationDate,Votes,Private,ProposalType")] Proposal proposal, List<string> ProposalCategories)
        {
            if (ModelState.IsValid)
            {
                // Criar lista de areas de interesse
                List<InterestArea> categories = new List<InterestArea>();

                foreach (string item in ProposalCategories)
                {
                    InterestArea category = new InterestArea();
                    category.Category = (CategoryEnum)Enum.Parse(typeof(CategoryEnum), item);
                    categories.Add(category);
                }

                proposal.Categories = categories;

                _context.Add(proposal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Index()
        {
            ViewBag.Proposals = _context.Proposals.Include(b => b.Categories).ToList();
            InterestArea interestArea = new InterestArea();
            ViewBag.Categories = interestArea.Categories;
            return View();
        }
    }
}