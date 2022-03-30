using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Quiz_api.Data;
using Quiz_api.Models;

namespace Quiz_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        private readonly DataContext context;
        public QuizController(DataContext context)
        {
            this.context = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var quiz =  await context.Quizzes.FindAsync(id);
           var options = await context.Options.Where(x=> x.QuizID == id).AsNoTracking().ToListAsync();

            quiz.options = options;
            if( quiz == null){
                return NotFound();
            }
            
            return Ok(quiz);
        }
    }

}