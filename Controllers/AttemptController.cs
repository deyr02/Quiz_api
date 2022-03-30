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
    public class AttemptController : ControllerBase
    {
        private readonly DataContext context;
        public AttemptController(DataContext context)
        {
            this.context = context;
        }

        [HttpGet("{appUserId}/{attemptId}")]
        public async Task<IActionResult> GetAttempt(Guid appUserId, long attemptId){
            var  attempt = await context.Attempts.SingleOrDefaultAsync(x => x.AppUserId == appUserId && x.ID == attemptId);
            if(attempt == null){
                return NotFound();
            }

            var attemptLines = await context.AttemptLines.Where(x => x.AttemptID == attemptId).AsNoTracking().ToListAsync();
            attempt.Attemptlines = attemptLines;

            return Ok(attempt);
        }



        [HttpPost("{id}")]
        public async Task<IActionResult> CreateAttempt(Guid id )
        {
            int numberOfQuestions = 3;
            var appuser = await context.Users.FindAsync(id);

            if(appuser == null){
                return BadRequest("Invalid user");
            }

            Attempt attempt = new Attempt{
                AppUserId = id,
                TotalQuestions = numberOfQuestions,
                TotalCorrectAnswer =0,

            };

            context.Attempts.Add(attempt);

            var result = await context.SaveChangesAsync() >0;
            if(!result){
                return BadRequest("Failed to create attempt");
            }
            List<AttemptLines> lines = new List<AttemptLines>();
            var quizset = await QuizSet(numberOfQuestions);
        
            for (int i =0; i< quizset.Count(); i++){
                AttemptLines line = new AttemptLines(){
                    AttemptID =attempt.ID,
                    Attempt = null,
                    QuizID = quizset[i],
                    Quiz = null,
                    SelectedOption = ""
                };
                lines.Add(CopyAttemptline(line));
                context.AttemptLines.Add(line);
            }

             
           var result1 = await context.SaveChangesAsync() > 0;

            if(!result1){
                return BadRequest("Failed to create quiz questions");
            }
            return Ok(lines);
        
        }


        //retuens a random list of  quizset 
        private async Task<List<long>> QuizSet(int numberofQuestion){

            var Quizzes = await context.Quizzes.AsNoTracking().ToListAsync();
            List<long> QuizSet = new List<long>();

            Random rng = new Random();

            for(int i =0; i< numberofQuestion; i++){
                int index = rng.Next(0, Quizzes.Count());
                QuizSet.Add(Quizzes[index].ID);
                Quizzes.RemoveAt(index);
            }
            return QuizSet;

        }
    
        private AttemptLines CopyAttemptline(AttemptLines line){
            return new AttemptLines{
                AttemptID =line.AttemptID,
                    QuizID = line.QuizID,
                    SelectedOption = "",

            };
        }

    }

}