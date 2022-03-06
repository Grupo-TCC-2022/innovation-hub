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

        public async Task<Idea> GetIdeaByIdAsync(int id)
        {
            return await _context.Ideas.Include(p => p.TeamMembers).Include(p => p.Comments).FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<IEnumerable<Idea>> GetIdeasAsync()
        {
            return await _context.Ideas.Include(p => p.TeamMembers).Include(p => p.Comments).ToListAsync();
        }

        public async Task<Problem> GetProblemByIdAsync(int id)
        {
            return await _context.Problems.Include(p => p.Comments).FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<IEnumerable<Problem>> GetProblemsAsync()
        {
            return await _context.Problems.Include(p => p.Comments).ToListAsync();
        }

        public async Task<Project> GetProjectByIdAsync(int id)
        {
            return await _context.Projects.Include(p => p.TeamMembers).Include(p => p.Comments).Include(p => p.Phases).Include(p => p.Socials).FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<IEnumerable<Project>> GetProjectsAsync()
        {
            return await _context.Projects.Include(p => p.TeamMembers).Include(p => p.Comments).Include(p => p.Phases).Include(p => p.Socials).ToListAsync();
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