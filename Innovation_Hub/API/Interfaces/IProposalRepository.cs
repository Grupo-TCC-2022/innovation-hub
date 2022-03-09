using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Entities.Enums;
using Microsoft.AspNetCore.Mvc;

namespace API.Interfaces
{
    public interface IProposalRepository
    {
        void Update(Proposal proposal);
        Task<bool> SaveAllAsync();
        Task<IEnumerable<Idea>> GetIdeasAsync(InterestAreaEnum? category);
        Task<IEnumerable<Project>> GetProjectsAsync(InterestAreaEnum? category);
        Task<IEnumerable<Problem>> GetProblemsAsync(InterestAreaEnum? category);
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