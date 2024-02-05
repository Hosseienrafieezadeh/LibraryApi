namespace book.Entitis
{
    public class Book
    {
        public Book()
        {
            Rents = new();
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public DateTime DateOfRelease { get; set; }
        public int Inventory { get; set; }
       
        public int WriterId { get; set; }
        public Writer Writer { get; set; }

        public int ShelfId { get; set; }
        public Shelf Shelf { get; set; }

        public HashSet<Rent> Rents { get; set; }
    }
}
