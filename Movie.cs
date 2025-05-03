namespace modul10_103022300106
{
    public class Movie
    {
        public String Title { get; set; }
        public String Director { get; set; }
        public List<String> Stars { get; set; }
        public String Description { get; set; }

        public Movie(string title, string director, List<string> stars, string description)
        {
            Title = title;
            Director = director;
            Stars = stars;
            Description = description;
        }   
    }
}
