using System.ComponentModel.DataAnnotations;

namespace Quiz_api.Models
{
    public class AttemptLines
    {
        [Key]
        public long AttemptID {get; set;}
        
        [Key]
        public long QuizID{get; set;}
        
        public Attempt Attempt {get; set;}
        public Quiz Quiz {get; set;}


        public bool IsAnswered {get; set;}
        public string SelectedOption {get; set;}
    }
}