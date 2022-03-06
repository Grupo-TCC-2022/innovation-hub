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

        [HttpGet("idea/{id}")]
        public async Task<ActionResult<Idea>> GetIdea(int id)
        {
            return Ok(await _proposalRepository.GetIdeaByIdAsync(id));
        }

        [HttpGet("project/{id}")]
        public async Task<ActionResult<Project>> GetProject(int id)
        {
            return Ok(await _proposalRepository.GetProjectByIdAsync(id));
        }

        [HttpGet("problem/{id}")]
        public async Task<ActionResult<Problem>> GetProblem(int id)
        {
            return Ok(await _proposalRepository.GetProblemByIdAsync(id));
        }

        [HttpGet("ideas")]
        public async Task<ActionResult<IEnumerable<Idea>>> GetIdeas()
        {
            return Ok(await _proposalRepository.GetIdeasAsync());
        }

        [HttpGet("projects")]
        public async Task<ActionResult<IEnumerable<Project>>> GetProjects()
        {
            return Ok(await _proposalRepository.GetProjectsAsync());
        }

        [HttpGet("problems")]
        public async Task<ActionResult<IEnumerable<Problem>>> GetProblems()
        {
            return Ok(await _proposalRepository.GetProblemsAsync());
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