using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using API.Entities.Enums;
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
            return await _context.Ideas.Include(p => p.Comments).Include(p => p.TeamMembers).ThenInclude(p => p.AppUser).ThenInclude(p => p.InterestAreas).FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<IEnumerable<Idea>> GetIdeasAsync(InterestAreaEnum? category)
        {
            if (category != null)
            {
                return await _context.Ideas.Where(p => p.Category.Equals(category)).Include(p => p.Comments).Include(p => p.TeamMembers).ThenInclude(p => p.AppUser).ThenInclude(p => p.InterestAreas).ToListAsync();
            }
            else
            {
                return await _context.Ideas.Include(p => p.Comments).Include(p => p.TeamMembers).ThenInclude(p => p.AppUser).ThenInclude(p => p.InterestAreas).ToListAsync();
            }
        }

        public async Task<Problem> GetProblemByIdAsync(int id)
        {
            return await _context.Problems.Include(p => p.Comments).Include(p => p.TeamMembers).ThenInclude(p => p.AppUser).ThenInclude(p => p.InterestAreas).FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<IEnumerable<Problem>> GetProblemsAsync(InterestAreaEnum? category)
        {
            if (category != null)
            {
                return await _context.Problems.Where(p => p.Category.Equals(category)).Include(p => p.Comments).Include(p => p.TeamMembers).ThenInclude(p => p.AppUser).ThenInclude(p => p.InterestAreas).ToListAsync();
            }
            else
            {
                return await _context.Problems.Include(p => p.Comments).Include(p => p.TeamMembers).ThenInclude(p => p.AppUser).ThenInclude(p => p.InterestAreas).ToListAsync();
            }
        }

        public async Task<Project> GetProjectByIdAsync(int id)
        {
            return await _context.Projects.Include(p => p.Comments).Include(p => p.Phases).Include(p => p.Socials).Include(p => p.TeamMembers).ThenInclude(p => p.AppUser).ThenInclude(p => p.InterestAreas).FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<IEnumerable<Project>> GetProjectsAsync(InterestAreaEnum? category)
        {
            if (category != null)
            {
                return await _context.Projects.Where(p => p.Category.Equals(category)).Include(p => p.Comments).Include(p => p.Phases).Include(p => p.Socials).Include(p => p.TeamMembers).ThenInclude(p => p.AppUser).ThenInclude(p => p.InterestAreas).ToListAsync();

            }
            else
            {
                return await _context.Projects.Include(p => p.Comments).Include(p => p.Phases).Include(p => p.Socials).Include(p => p.TeamMembers).ThenInclude(p => p.AppUser).ThenInclude(p => p.InterestAreas).ToListAsync();
            }
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(Proposal proposal)
        {
            _context.Entry(proposal).State = EntityState.Modified;
        }

        public void AddIdeas(IEnumerable<Idea> ideas)
        {
            foreach (Idea i in ideas)
            {
                _context.Ideas.Add(i);
            }
        }

        public void AddProjects(IEnumerable<Project> projects)
        {
            foreach (Project p in projects)
            {
                _context.Projects.Add(p);
            }
        }

        public void AddProblems(IEnumerable<Problem> problems)
        {
            foreach (Problem p in problems)
            {
                _context.Problems.Add(p);
            }
        }
    }
}