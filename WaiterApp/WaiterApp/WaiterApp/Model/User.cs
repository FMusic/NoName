namespace Model
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public UserEnum UserEnum { get; set; }
        public int PlaceId { get; set; }

        public string EmployeeName { get
            {
                return FirstName + LastName;
            } }
    }
}
