namespace web.net_lab1.Models
{
  
    public class Director
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public int Age { get; set; }


        private static int _id = 1;
        public Director(string name, string surname, int age)
        {
            Id = _id++;
            Name = name;
            Surname = surname;
            Age = age;
        }
    }
}
