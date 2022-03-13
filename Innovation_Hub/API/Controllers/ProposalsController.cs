using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Entities.Enums;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ProposalsController : BaseApiController
    {
        private readonly IProposalRepository _proposalRepository;
        private readonly IMapper _mapper;

        public ProposalsController(IProposalRepository proposalRepository, IMapper mapper)
        {
            _proposalRepository = proposalRepository;
            _mapper = mapper;
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
        public async Task<ActionResult<IEnumerable<IdeaDto>>> GetIdeas([FromQuery] Filter filter)
        {
            IEnumerable<Idea> ideas = await _proposalRepository.GetIdeasAsync(filter.Category);

            if (filter.OrderBy == "votes")
            {
                ideas = ideas.OrderByDescending(k => k.Votes).Skip(filter.Skip).Take(filter.Take);
            }
            else if (filter.OrderBy == "recents")
            {
                ideas = ideas.OrderByDescending(k => k.CreationDate).Skip(filter.Skip).Take(filter.Take);
            }

            return Ok(_mapper.Map<IEnumerable<IdeaDto>>(ideas));
        }

        [HttpGet("projects")]
        public async Task<ActionResult<IEnumerable<Project>>> GetProjects([FromQuery] Filter filter)
        {
            IEnumerable<Project> projects = await _proposalRepository.GetProjectsAsync(filter.Category);
            if (filter.OrderBy == "votes")
            {
                projects = projects.OrderByDescending(k => k.Votes).Skip(filter.Skip).Take(filter.Take);
            }
            else if (filter.OrderBy == "recents")
            {
                projects = projects.OrderByDescending(k => k.CreationDate).Skip(filter.Skip).Take(filter.Take);
            }
            return Ok(projects);
        }

        [HttpGet("problems")]
        public async Task<ActionResult<IEnumerable<Problem>>> GetProblems([FromQuery] Filter filter)
        {
            IEnumerable<Problem> problems = await _proposalRepository.GetProblemsAsync(filter.Category);
            if (filter.OrderBy == "votes")
            {
                problems = problems.OrderByDescending(k => k.Votes).Skip(filter.Skip).Take(filter.Take);
            }
            else if (filter.OrderBy == "recents")
            {
                problems = problems.OrderByDescending(k => k.CreationDate).Skip(filter.Skip).Take(filter.Take);
            }
            return Ok(problems);
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

        [HttpPost("postideas")]
        public async void PostIdeas(IEnumerable<Idea> ideas)
        {
            _proposalRepository.AddIdeas(ideas);
            await _proposalRepository.SaveAllAsync();
        }

        [HttpPost("postprojects")]
        public async void PostProjects(IEnumerable<Project> projects)
        {
            _proposalRepository.AddProjects(projects);
            await _proposalRepository.SaveAllAsync();
        }

        [HttpPost("postproblems")]
        public async void PostProblems(IEnumerable<Problem> problems)
        {
            _proposalRepository.AddProblems(problems);
            await _proposalRepository.SaveAllAsync();
        }

        [HttpPost("comment")]
        public async void Comment(Comment comment)
        {
            _proposalRepository.addComment(comment);
            await _proposalRepository.SaveAllAsync();
        }

        [HttpGet("upvotecomment")]
        public async Task upvoteCommentAsync(int commentId)
        {
            _proposalRepository.upvoteCommentAsync(commentId);
            await _proposalRepository.SaveAllAsync();
        }
    }
}