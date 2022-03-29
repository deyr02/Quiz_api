using System.Collections.Generic;

namespace Quiz_api.Models
{
    public class Option
    {
        public long ID {get; set;}

        public string Description {get; set;}

        public bool ContiansImage {get; set;}

        public  string URL {get; set;}

        public long QuizID {get; set;}
        public Quiz  Quiz {get; set;}

        public ICollection<OptionImage> OptionImages{get; set;}
    }
}