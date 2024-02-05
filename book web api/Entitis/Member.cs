namespace book.Entitis
{
    public class Member
    {
        public Member()
        {
            Rents = new();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; } 
        public HashSet<Rent> Rents { get; set; }
    }
}
