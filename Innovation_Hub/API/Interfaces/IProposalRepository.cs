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
        Task<IEnumerable<Proposal>> GetProposalsAsync();
        Task<Proposal> GetProposalByIdAsync(int id);
        Task<Proposal> GetProposalByTitleAsync(string title, string discriminator);
        void AddIdea(Idea idea);
        void AddProject(Project project);
        void AddProblem(Problem problem);
    }
}