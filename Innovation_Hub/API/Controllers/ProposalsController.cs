using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ProposalsController : BaseApiController
    {
        private readonly IProposalRepository _proposalRepository;

        public ProposalsController(IProposalRepository proposalRepository)
        {
            _proposalRepository = proposalRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Proposal>>> GetProposals()
        {
            var proposals = await _proposalRepository.GetProposalsAsync();

            return Ok(proposals);
        }

        [HttpPost("postidea")]
        public async void PostIdea(Idea idea)
        {
            _proposalRepository.AddIdea(idea);
            await _proposalRepository.SaveAllAsync();
        }

        [HttpPost("postproject")]
        public async void PostProject(Project project)
        {
            _proposalRepository.AddProject(project);
            await _proposalRepository.SaveAllAsync();
        }

        [HttpPost("postproblem")]
        public async void PostProblem(Problem problem)
        {
            _proposalRepository.AddProblem(problem);
            await _proposalRepository.SaveAllAsync();
        }
    }
}