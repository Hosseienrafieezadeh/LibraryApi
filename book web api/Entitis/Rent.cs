namespace book.Entitis
{
    public class Rent
    {
        public int Id { get; set; }
        public bool BackBook { get; set; }
        public int UserId { get; set; }
        public Member Member  { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
