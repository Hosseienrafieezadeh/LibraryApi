namespace book.Entitis
{
    public class Writer
    {
        public int Id { get; set; }
        public string Name { get; set; }
       
        public HashSet<Book> Books { get; set; }
    }
}
