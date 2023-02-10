using System;

namespace web.net_lab1.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public DateTime CreationDate { get; set; }
        public int DirectorId { get; set; }


        private static int _id = 1;
        public Movie(string name, string genre, int directorId)
        {
            Id = _id++;
            Name = name;
            Genre = genre;
            DirectorId = directorId;
            CreationDate = DateTime.Now;
        }
    }

}
