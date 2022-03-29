namespace Quiz_api.Models
{
    public class OptionImage
    {
        public long ID {get; set;}
        public string URL {get; set;}

        public long OptionID{get; set;}
        public Option option{get; set;}
        
    }
}