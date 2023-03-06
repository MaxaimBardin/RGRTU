namespace my_new_app
{
    public abstract class Client
    {
        public int ClientId { get; set; }
        public string? NameClient { get; set; }
        public string? SurnameClient { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public int MentorId { get; set; }

        public Mentor? Mentors { get; set; }
    }
}