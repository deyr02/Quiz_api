namespace Quiz_api.Models
{
    public class AttemptLines
    {
        public long AttemptID {get; set;}
        public Attempt Attempt {get; set;}
        public long QuizID{get; set;}
        public Quiz Quiz {get; set;}

        public bool IsAnswered {get; set;}
        public long SelectedOption {get; set;}
    }
}