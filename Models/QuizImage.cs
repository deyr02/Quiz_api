namespace Quiz_api.Models
{
    public class QuizImage
    {
         public long ID {get; set;}
        public string URL {get; set;}

        public long QuizID {get; set;}
        public Quiz Quiz {get; set;}
    }
}