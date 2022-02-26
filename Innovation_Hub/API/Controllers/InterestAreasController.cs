using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static API.Entities.InterestArea;

namespace API.Controllers
{
    public class InterestAreasController : BaseApiController
    {
        private readonly DataContext _context;

        public InterestAreasController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("interest_areas")]
        public IEnumerable<string> InterestAreas()
        {
            return Enum.GetNames(typeof(InterestAreaEnum));
        }
    }
}