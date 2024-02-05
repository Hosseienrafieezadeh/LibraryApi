namespace book.Entitis
{
    public class Shelf
    {
      
        public int Id { get; set; }
        public string Title { get; set; }
        
        public HashSet<Book> Books { get; set; }
    }
}
