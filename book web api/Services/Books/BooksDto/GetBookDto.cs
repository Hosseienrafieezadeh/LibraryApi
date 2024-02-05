namespace book_web_api.Services.Books.BooksDto
{
    public class GetBookDto
    {
        public string Name { get; set; }
        public string WriterName { get; set; }
        public string ShelfTitle { get; set; }
        public DateTime DateOfRelease { get; set; }
        public int Inventory { get; set; }
        public int RentInventory { get; set; }
    }
}
