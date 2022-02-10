namespace WebApplication2.Models.DTOs
{
    public class CreateUserDto
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
    }
}