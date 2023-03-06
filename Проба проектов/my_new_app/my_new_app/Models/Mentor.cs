using System.Collections.Generic;

namespace my_new_app
{
    public abstract class Mentor
    {
        public int MentorId { get; set; }
        public string? NameMentor { get; set; }
        public string? Post { get; set; }
        
        public LinkedList<Client> Clients = new LinkedList<Client>();
    }
}