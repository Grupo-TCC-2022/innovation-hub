using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using innovation_hub.Models;
using innovation_hub.Data;

namespace innovation_hub.Controllers
{
    public class ProposalController : Controller
    {
        private readonly DataContext _context;

        public ProposalController(DataContext context)
        {
            _context = context;
        }

        // GET: Proposal/Create
        public IActionResult Create()
        {
            return View();
        }

        // GET: Proposal/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proposal = await _context.Proposals.FindAsync(id);
            if (proposal == null)
            {
                return NotFound();
            }
            return View(proposal);
        }

        // POST: Proposal/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,AgeRestriction,Finished,Arquived,Private")] Proposal proposal, string manager)
        {
            if (id != proposal.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Proposal p = await _context.Proposals.FirstOrDefaultAsync(p => p.Id == proposal.Id);
                    AppUser user = await _context.AppUsers.FirstOrDefaultAsync(p => p.Nickname == manager);

                    bool isIn = _context.AppUserProposals.Any(p => p.AppUserId == user.Id && p.ProposalId == p.Id);

                    if(!isIn)
                    {
                        _context.AppUserProposals.Add(new AppUserProposal{
                            AppUserId = user.Id,
                            ProposalId = p.Id
                        });
                    }

                    p.ManagerId = user.Id;
                    p.Title = proposal.Title;
                    p.Description = proposal.Description;
                    p.AgeRestriction = proposal.AgeRestriction;
                    p.Finished = proposal.Finished;
                    p.Arquived = proposal.Arquived;
                    p.Private = proposal.Private;
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProposalExists(proposal.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index", "Home");
        }

        // GET: Proposal/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proposal = await _context.Proposals
                .FirstOrDefaultAsync(m => m.Id == id);
            if (proposal == null)
            {
                return NotFound();
            }

            return View(proposal);
        }

        // POST: Proposal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var proposal = await _context.Proposals.FindAsync(id);
            _context.Proposals.Remove(proposal);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProposalExists(int id)
        {
            return _context.Proposals.Any(e => e.Id == id);
        }
    }
}
