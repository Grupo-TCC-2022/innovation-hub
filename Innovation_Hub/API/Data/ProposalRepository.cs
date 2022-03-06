using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class ProposalRepository : IProposalRepository
    {

        private readonly DataContext _context;

        public ProposalRepository(DataContext context)
        {
            _context = context;
        }

        //----------------------------------------------
        public void AddIdea(Idea idea)
        {
            _context.Ideas.Add(idea);
        }

        public void AddProblem(Problem problem)
        {
            _context.Problems.Add(problem);
        }

        public void AddProject(Project project)
        {
            _context.Projects.Add(project);
        }

        //----------------------------------------------

        public async Task<Proposal> GetProposalByIdAsync(int id)
        {
            return await _context.Proposals.FindAsync(id);
        }

        public async Task<Proposal> GetProposalByTitleAsync(string title, string discriminator)
        {
            switch (discriminator.ToLower())
            {
                case "idea":
                    return await _context.Ideas.Include(p => p.Comments).SingleOrDefaultAsync(x => x.Title == title);
                case "project":
                    return await _context.Projects.Include(p => p.Comments).Include(p => p.Phases).Include(p => p.Networks).SingleOrDefaultAsync(x => x.Title == title);
                case "problem":
                    return await _context.Ideas.Include(p => p.Comments).SingleOrDefaultAsync(x => x.Title == title);
            }

            return null;
        }

        public async Task<IEnumerable<Proposal>> GetProposalsAsync()
        {
            return await _context.Proposals.Include(p => p.Comments).ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(Proposal proposal)
        {
            _context.Entry(proposal).State = EntityState.Modified;
        }
    }
}