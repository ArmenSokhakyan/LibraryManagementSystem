namespace LibraryManagementSystem.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime MembershipDate { get; set; } = DateTime.Now;

        public string Password { get; set; }
        public string Username { get; set; }

    }
}
