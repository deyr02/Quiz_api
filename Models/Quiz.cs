using System.Collections.Generic;

namespace Quiz_api.Models
{
    public class Quiz
    {
        public long  ID {get; set;}
        public string Question {get; set;}

        public bool IsAnswerMultiple{get; set;}

        public string Answers {get; set;}

        public bool ContiansImage{get; set;}

        public string URL {get; set;}

        public ICollection<AttemptLines> attemptLines {get; set;}

        public ICollection<Option> options {get; set;}

        

    }
}