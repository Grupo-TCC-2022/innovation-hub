using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Interfaces
{
    public interface IProposalRepository
    {
        void Update(Proposal proposal);
        Task<bool> SaveAllAsync();
        Task<IEnumerable<Idea>> GetIdeasAsync();
        Task<IEnumerable<Project>> GetProjectsAsync();
        Task<IEnumerable<Problem>> GetProblemsAsync();
        Task<Idea> GetIdeaByIdAsync(int id);
        Task<Project> GetProjectByIdAsync(int id);
        Task<Problem> GetProblemByIdAsync(int id);
        void AddIdea(Idea idea);
        void AddProject(Project project);
        void AddProblem(Problem problem);

        public void AddIdeas(List<Idea> ideas);
        public void AddProjects(List<Project> projects);
        public void AddProblems(List<Problem> problems);
    }
}