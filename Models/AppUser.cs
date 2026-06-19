namespace StudentAdmissionSystem.Models
{
    public class AppUser
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Role { get; set; } // Admin / Student
    }
}
